using AutoMapper;
using Midioteca.Models;
using Midioteca.Dtos.Livro;

namespace Midioteca.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<Livro, LivroReadDto>()
                .ForMember(dest => dest.GeneroNome, opt => opt.MapFrom(src => src.Genero.Nome));

            CreateMap<LivroCreateDto, Livro>();
            CreateMap<LivroUpdateDto, Livro>();
        }
    }
}
