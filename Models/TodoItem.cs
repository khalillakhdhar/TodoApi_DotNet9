namespace TodoApi.Models;

/// <summary>
/// Entite persistante representant une tache.
/// </summary>
public class TodoItem
{
    /// <summary>
    /// Identifiant unique de la tache.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Titre court de la tache.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description optionnelle de la tache.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indique si la tache est terminee.
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Date de creation UTC de la tache.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
