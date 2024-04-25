using Backend.Dtos;
using Backend.Interfaces;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todo;
        public TodoController(TodoService todo)
        {
            _todo = todo;
        }
        // GET: api/<TodoController>
        [HttpGet("todos")]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            return Ok(_todo.GetAll());
        }

        // POST api/<TodoController>
        [HttpPost("todo")]
        public ActionResult<Todo> Post([FromBody] TodoDto todo)
        {
            if(todo ==  null) throw new ArgumentNullException(nameof(todo));
            var res = _todo.AddTodo(todo);
            return Ok(res);
        }
        [HttpGet("factorial")]
        public async Task<ActionResult<long>> GetFactorialsAsync()
        {
            var res = await _todo.GetFactorial();
            return Ok(res);
        }
    }
}
