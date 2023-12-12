using TaskAPI.Models;

namespace TaskAPI.Data
{
    public interface ITodoRepo
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodoById(int id);
        Task<Todo> CreateTodo(Todo todo);
        Task UpdateTodo(int id, Todo todo);
        Task DeleteTodo(int id);
    }
}
