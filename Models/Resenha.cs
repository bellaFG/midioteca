using Midioteca.Models;

public class Resenha : Entity
{
    public string Titulo { get; set; } = string.Empty;
    public string Texto { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public Guid ConsumoMidiaId { get; set; }
    public ConsumoMidia ConsumoMidia { get; set; }
}
