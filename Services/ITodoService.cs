using TodoApi.DTOs;

namespace TodoApi.Services;

/// <summary>
/// Definit les operations applicatives disponibles pour les taches.
/// </summary>
public interface ITodoService
{
    /// <summary>
    /// Retourne toutes les taches.
    /// </summary>
    Task<IEnumerable<TodoDto>> GetAllAsync();

    /// <summary>
    /// Retourne une tache par son identifiant.
    /// </summary>
    /// <param name="id">Identifiant unique de la tache.</param>
    Task<TodoDto?> GetByIdAsync(int id);

    /// <summary>
    /// Cree une nouvelle tache.
    /// </summary>
    /// <param name="dto">Donnees de creation.</param>
    Task<TodoDto> CreateAsync(CreateTodoDto dto);

    /// <summary>
    /// Met a jour une tache existante.
    /// </summary>
    /// <param name="id">Identifiant unique de la tache.</param>
    /// <param name="dto">Donnees de mise a jour.</param>
    Task<TodoDto?> UpdateAsync(int id, UpdateTodoDto dto);

    /// <summary>
    /// Supprime une tache existante.
    /// </summary>
    /// <param name="id">Identifiant unique de la tache.</param>
    Task<bool> DeleteAsync(int id);
}
