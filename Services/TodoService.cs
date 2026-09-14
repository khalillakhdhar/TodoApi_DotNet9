using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services;

/// <summary>
/// Service applicatif responsable des operations CRUD des taches.
/// </summary>
public class TodoService : ITodoService
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initialise une nouvelle instance du service des taches.
    /// </summary>
    /// <param name="context">Contexte de donnees de l'application.</param>
    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TodoDto>> GetAllAsync()
    {
        return await _context.Todos
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new TodoDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<TodoDto?> GetByIdAsync(int id)
    {
        return await _context.Todos
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new TodoDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt
            })
            .FirstOrDefaultAsync();
    }

    /// <inheritdoc />
    public async Task<TodoDto> CreateAsync(CreateTodoDto dto)
    {
        var todo = new TodoItem
        {
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return Map(todo);
    }

    /// <inheritdoc />
    public async Task<TodoDto?> UpdateAsync(int id, UpdateTodoDto dto)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo is null)
        {
            return null;
        }

        todo.Title = dto.Title;
        todo.Description = dto.Description;
        todo.IsCompleted = dto.IsCompleted;

        await _context.SaveChangesAsync();

        return Map(todo);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo is null)
        {
            return false;
        }

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return true;
    }

    private static TodoDto Map(TodoItem todo)
    {
        return new TodoDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            IsCompleted = todo.IsCompleted,
            CreatedAt = todo.CreatedAt
        };
    }
}
