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
        public async Task<DataDTO<Todo>> Get([FromQuery] bool includeDone = false)
        {
            return new DataDTO<Todo>(await _todoService.FindTodos(includeDone));
        }

        [HttpPost]
        public async Task<DataDTO<Todo>> Create(CreateTodoDTO dto)
        {
            //TODO: Wire this up
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<DataDTO<Todo>> Update(UpdateTodoDTO dto)
        {
            //TODO: wire this up.
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<DataDTO<Todo>> Delete([FromQuery] int id)
        {
            //TODO: wire this up.
            throw new NotImplementedException();
        }
    }
}
