using Backend.Dtos;
using Backend.Interfaces;
using Backend.Models;
using System.Collections.Concurrent;
using System.Numerics;

namespace Backend.Services
{
    public class TodoService : ITodoService
    {
        private static List<Todo> todoStore = new List<Todo>();
        public Todo AddTodo(TodoDto todo)
        {
            var item = new Todo();
            item.Id = Guid.NewGuid();
            item.Title = todo.Title;
            item.Description = todo.Description;
            todoStore.Add(item);
            return item;
        }

        public async Task<List<Todo>> GetFactorial()
        {
            var results = new ConcurrentBag<Todo>();

            Parallel.ForEach(todoStore, async item =>
            {
                var factorial = CalculateFactorial(todoStore.IndexOf(item) + 1);
                item.Factorial = factorial;

                results.Add(item);
            });

            return results.OrderBy(x => x.CreatedAt).ToList(); 
        }
        private static long CalculateFactorial(int n)
        {
            long factorial = 1;
            for (long i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public IEnumerable<Todo> GetAll()
        {
            return todoStore.OrderBy(x => x.CreatedAt);
        }
    }
}
