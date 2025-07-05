namespace Midioteca.Dtos.Livro
{
    public class LivroReadDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int AnoPublicacao { get; set; }
        public string GeneroNome { get; set; }
    }
}
