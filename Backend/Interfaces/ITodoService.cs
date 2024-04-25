
using Backend.Dtos;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAll();
        Todo AddTodo(TodoDto todo);
        Task<List<Todo>> GetFactorial();
    }
}
