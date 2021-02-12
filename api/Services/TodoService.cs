

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using MySqlConnector;

public class TodoService
{
    private ILogger<TodoService> _logger;
    private string CONNECTION_STRING = "server=127.0.0.1;user=todo_rw;password=todo_pass;database=todo";

    public TodoService(ILogger<TodoService> logger)
    {
        this._logger = logger;
    }

    public async Task<List<Todo>> FindTodos(bool includeDone = false)
    {
        using (System.Data.IDbConnection db = new MySqlConnection(this.CONNECTION_STRING))
        {
            return (await db.QueryAsync<Todo>("select * from todo.todos order by id desc")).ToList();
        }
    }

    public async Task<Todo> CreateTodo(string title)
    {
        // TODO: no pun intended. Please fill this out.
        return null;
    }

    public async Task<Todo> UpdateTodo(UpdateTodoDTO update)
    {
        //TODO: no pun intended. 
        return null;
    }

    public async Task<Todo> DeleteTodo(int id)
    {
        //TODO: no pun intended. 
        return null;
    }
}