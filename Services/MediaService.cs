using Microsoft.EntityFrameworkCore;
using MidiotecaApi.Data;
using MidiotecaApi.Dtos;
using MidiotecaApi.Models;
using MidiotecaApi.Services.Interfaces;

namespace MidiotecaApi.Services
{
    public class MediaService : IMediaService
    {
        private readonly MidiotecaApiDbContext _context;

        public MediaService(MidiotecaApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MediaResponseDto>> GetAllAsync()
        {
            var medias = await _context.MediaItems
                .Include(m => m.MediaItemGenres)
                    .ThenInclude(mg => mg.Genre)
                .ToListAsync();

            return medias.Select(m => new MediaResponseDto
            {
                Id = m.Id,
                Title = m.Title,
                GenreName = string.Join(", ", m.MediaItemGenres.Select(g => g.Genre.Name)),
                Type = m.Type
            });
        }

        public async Task<MediaResponseDto?> GetByIdAsync(Guid id)
        {
            var media = await _context.MediaItems
                .Include(m => m.MediaItemGenres)
                    .ThenInclude(mg => mg.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (media == null)
                return null;

            return new MediaResponseDto
            {
                Id = media.Id,
                Title = media.Title,
                GenreName = string.Join(", ", media.MediaItemGenres.Select(g => g.Genre.Name)),
                Type = media.Type
            };
        }

        public async Task<MediaResponseDto> CreateAsync(MediaCreateDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            MediaItem media;

            switch (dto.Type)
            {
                case MediaItem.MediaType.Book:
                    media = new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = dto.Title,
                        Type = dto.Type,
                        Author = dto.Author!,
                        Publisher = dto.Publisher!,
                        PublicationYear = dto.PublicationYear ?? 0,
                        Pages = dto.Pages,
                        MediaItemGenres = dto.GenreIds.Select(genreId => new MediaItemGenre
                        {
                            GenreId = genreId
                        }).ToList()
                    };
                    break;

                case MediaItem.MediaType.Movie:
                    media = new Movie
                    {
                        Id = Guid.NewGuid(),
                        Title = dto.Title,
                        Type = dto.Type,
                        Director = dto.Director!,
                        ReleaseYear = dto.ReleaseYear ?? 0,
                        DurationMinutes = dto.DurationMinutes,
                        MediaItemGenres = dto.GenreIds.Select(genreId => new MediaItemGenre
                        {
                            GenreId = genreId
                        }).ToList()
                    };
                    break;

                default:
                    throw new ArgumentException("Invalid media type.", nameof(dto.Type));
            }

            _context.MediaItems.Add(media);
            await _context.SaveChangesAsync();

            // Recarrega para trazer os nomes dos gêneros corretamente
            var created = await _context.MediaItems
                .Include(m => m.MediaItemGenres)
                    .ThenInclude(mg => mg.Genre)
                .FirstAsync(m => m.Id == media.Id);

            return new MediaResponseDto
            {
                Id = created.Id,
                Title = created.Title,
                Type = created.Type,
                GenreName = string.Join(", ", created.MediaItemGenres.Select(g => g.Genre.Name))
            };
        }

        public async Task<bool> UpdateAsync(Guid id, MediaUpdateDto dto)
        {
            var media = await _context.MediaItems
                .Include(m => m.MediaItemGenres)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (media == null)
                return false;

            // Evita troca de tipo entre Book/Movie (herança + migrações/validações complicam)
            if (dto.Type != media.Type)
                throw new InvalidOperationException("Changing media type is not supported.");

            media.Title = dto.Title;
            media.Type = dto.Type!.Value;

            // Atualiza os gêneros: zera e recria os vínculos
            media.MediaItemGenres.Clear();
            foreach (var genreId in dto.GenreIds)
            {
                media.MediaItemGenres.Add(new MediaItemGenre { GenreId = genreId });
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var media = await _context.MediaItems.FindAsync(id);
            if (media == null)
                return false;

            _context.MediaItems.Remove(media);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
