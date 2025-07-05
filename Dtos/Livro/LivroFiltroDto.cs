using Midioteca.Dtos.Livro;

public class LivroFiltroDto
{
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public int? AnoPublicacao { get; set; }
    public int Pagina { get; set; } = 1;
    public int TamanhoPagina { get; set; } = 10;
}
