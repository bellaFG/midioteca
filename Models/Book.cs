using MidiotecaApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Book specific fields.
/// </summary>
public class Book : MediaItem
{
    [MaxLength(250)]
    public string? Author { get; set; }

    [MaxLength(200)]
    public string? Publisher { get; set; }

    public int? PublicationYear { get; set; }

    public int? Pages { get; set; }

    [NotMapped]
    public string? CustomCoverFile { get; set; }
}