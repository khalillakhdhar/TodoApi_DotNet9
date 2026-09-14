using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs;

/// <summary>
/// Donnees envoyees pour creer une tache.
/// </summary>
public class CreateTodoDto
{
    /// <summary>
    /// Titre court de la tache.
    /// </summary>
    /// <example>Apprendre .NET 9</example>
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description optionnelle de la tache.
    /// </summary>
    /// <example>Creer une API REST avec Entity Framework Core et Swagger.</example>
    [MaxLength(1000)]
    public string? Description { get; set; }
}
