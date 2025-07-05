using Midioteca.Dtos.Livro;


public interface ILivroService
{
    Task<LivroReadDto> GetLivroPorId(Guid id);
    Task<PagedResult<LivroReadDto>> GetLivros(LivroFiltroDto filtro);
    Task<LivroReadDto> CriarLivro(LivroCreateDto dto);
    Task AtualizarLivro(Guid id, LivroUpdateDto dto);
    Task DeletarLivro(Guid id);
}
