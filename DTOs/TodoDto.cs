namespace TodoApi.DTOs;

/// <summary>
/// Representation publique d'une tache retournee par l'API.
/// </summary>
public class TodoDto
{
    /// <summary>
    /// Identifiant unique de la tache.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>
    /// Titre court de la tache.
    /// </summary>
    /// <example>Apprendre .NET 9</example>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description optionnelle de la tache.
    /// </summary>
    /// <example>Creer une API Todo avec SQL Server.</example>
    public string? Description { get; set; }

    /// <summary>
    /// Indique si la tache est terminee.
    /// </summary>
    /// <example>false</example>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Date de creation UTC de la tache.
    /// </summary>
    /// <example>2026-09-14T10:00:00Z</example>
    public DateTime CreatedAt { get; set; }
}
