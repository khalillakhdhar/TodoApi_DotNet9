using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs;

/// <summary>
/// Donnees envoyees pour modifier une tache.
/// </summary>
public class UpdateTodoDto
{
    /// <summary>
    /// Nouveau titre de la tache.
    /// </summary>
    /// <example>Apprendre .NET 9</example>
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Nouvelle description optionnelle de la tache.
    /// </summary>
    /// <example>Terminer la documentation Swagger.</example>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// Indique si la tache est terminee.
    /// </summary>
    /// <example>true</example>
    public bool IsCompleted { get; set; }
}
