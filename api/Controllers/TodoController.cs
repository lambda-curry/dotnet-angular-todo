using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class DataDTO<T>
{
    public DataDTO(List<T> data)
    {
        this.data = data;

    }
    public List<T> data { get; set; }
}


namespace todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {

        private TodoService _todoService;


        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger, TodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string search = "", [FromQuery] bool includeDone = false)
        {
            return Ok(new DataDTO<Todo>(await _todoService.FindTodos(search, includeDone)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoDTO dto)
        {
            var id = await _todoService.CreateTodo(dto);
            return new ObjectResult(await _todoService.FetchTodo(id)) { StatusCode = 201 };
        }

        [HttpPut]
        public async Task<Todo> Update(UpdateTodoDTO dto)
        {
            await _todoService.UpdateTodo(dto);
            return await _todoService.FetchTodo(dto.id);
        }

        [HttpDelete]
        public async Task<bool> Delete([FromQuery] int id)
        {
            await _todoService.DeleteTodo(id);
            return true;
        }
    }
}
