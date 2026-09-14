using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Services;

namespace TodoApi.Controllers;

/// <summary>
/// Expose les operations CRUD pour les taches.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    /// <summary>
    /// Initialise une nouvelle instance du controleur des taches.
    /// </summary>
    /// <param name="todoService">Service applicatif des taches.</param>
    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    /// <summary>
    /// Retourne toutes les taches, de la plus recente a la plus ancienne.
    /// </summary>
    /// <returns>La liste des taches existantes.</returns>
    /// <response code="200">Retourne la liste des taches.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TodoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
    {
        var todos = await _todoService.GetAllAsync();
        return Ok(todos);
    }

    /// <summary>
    /// Retourne une tache par son identifiant.
    /// </summary>
    /// <param name="id">Identifiant unique de la tache.</param>
    /// <returns>La tache demandee si elle existe.</returns>
    /// <response code="200">Retourne la tache demandee.</response>
    /// <response code="404">Aucune tache ne correspond a cet identifiant.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(TodoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TodoDto>> GetById(int id)
    {
        var todo = await _todoService.GetByIdAsync(id);

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    /// <summary>
    /// Cree une nouvelle tache.
    /// </summary>
    /// <param name="dto">Donnees necessaires a la creation de la tache.</param>
    /// <returns>La tache creee.</returns>
    /// <response code="201">La tache a ete creee.</response>
    /// <response code="400">Les donnees envoyees sont invalides.</response>
    [HttpPost]
    [ProducesResponseType(typeof(TodoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoDto>> Create(CreateTodoDto dto)
    {
        var todo = await _todoService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = todo.Id },
            todo);
    }

    /// <summary>
    /// Met a jour une tache existante.
    /// </summary>
    /// <param name="id">Identifiant unique de la tache a mettre a jour.</param>
    /// <param name="dto">Nouvelles donnees de la tache.</param>
    /// <returns>La tache mise a jour.</returns>
    /// <response code="200">La tache a ete mise a jour.</response>
    /// <response code="400">Les donnees envoyees sont invalides.</response>
    /// <response code="404">Aucune tache ne correspond a cet identifiant.</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(TodoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TodoDto>> Update(
        int id,
        UpdateTodoDto dto)
    {
        var todo = await _todoService.UpdateAsync(id, dto);

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    /// <summary>
    /// Supprime une tache existante.
    /// </summary>
    /// <param name="id">Identifiant unique de la tache a supprimer.</param>
    /// <returns>Aucun contenu si la suppression reussit.</returns>
    /// <response code="204">La tache a ete supprimee.</response>
    /// <response code="404">Aucune tache ne correspond a cet identifiant.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _todoService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
