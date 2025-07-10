using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Midioteca.Data;
using Midioteca.Dtos;
using Midioteca.Models;
using Midioteca.Services.Interfaces;
using BCrypt.Net;

namespace Midioteca.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly MidiotecaDbContext _context;

        public UsuarioService(MidiotecaDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioReadDto> CreateUsuarioAsync(UsuarioCreateDto dto)
        {
            var email = dto.Email.Trim().ToLowerInvariant();
            var nome = dto.Nome.Trim();

            if (await _context.Usuarios.AnyAsync(u => u.Email == email))
                throw new Exception("E-mail já cadastrado.");

            if (await _context.Usuarios.AnyAsync(u => u.Nome == nome))
                throw new Exception("Nome de usuário já cadastrado.");

            var hashSenha = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                SenhaHash = hashSenha,
                Ativo = true,
                CriadoEm = DateTime.UtcNow
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioReadDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<UsuarioReadDto> GetUsuarioByIdAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null || !usuario.Ativo)
                throw new Exception("Usuário não encontrado ou inativo.");

            return new UsuarioReadDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<IEnumerable<UsuarioReadDto>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios
                .Where(u => u.Ativo)
                .Select(u => new UsuarioReadDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<UsuarioReadDto> UpdateUsuarioAsync(Guid id, UsuarioUpdateDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null || !usuario.Ativo)
                throw new Exception("Usuário não encontrado ou inativo.");


            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                var email = dto.Email.Trim().ToLowerInvariant();

                if (await _context.Usuarios.AnyAsync(u => u.Id != id && u.Email == email))
                    throw new Exception("E-mail já cadastrado por outro usuário.");

                usuario.Email = email;
            }

            if (!string.IsNullOrWhiteSpace(dto.Nome))
            {
                var nome = dto.Nome.Trim();

                if (await _context.Usuarios.AnyAsync(u => u.Id != id && u.Nome == nome))
                    throw new Exception("Nome já cadastrado por outro usuário.");

                usuario.Nome = nome;
            }

            if (!string.IsNullOrWhiteSpace(dto.NovaSenha))
            {
                usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.NovaSenha);
            }

            await _context.SaveChangesAsync();

            return new UsuarioReadDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task DeleteUsuarioAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado.");


            _context.Usuarios.Remove(usuario);

            await _context.SaveChangesAsync();
        }

    }
}
