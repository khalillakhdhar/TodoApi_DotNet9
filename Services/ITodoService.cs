using TodoApi.DTOs;

namespace TodoApi.Services;

public interface ITodoService
{
    Task<IEnumerable<TodoDto>> GetAllAsync();

    Task<TodoDto?> GetByIdAsync(int id);

    Task<TodoDto> CreateAsync(CreateTodoDto dto);

    Task<TodoDto?> UpdateAsync(int id, UpdateTodoDto dto);

    Task<bool> DeleteAsync(int id);
}
