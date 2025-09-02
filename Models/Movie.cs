using MidiotecaApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Movie specific fields.
/// </summary>
public class Movie : MediaItem
{
    [MaxLength(250)]
    public string? Director { get; set; }

    public int? ReleaseYear { get; set; }

    public int? DurationMinutes { get; set; }

    [NotMapped]
    public string? CustomCoverFile { get; set; }
}