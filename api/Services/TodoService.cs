

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using MySqlConnector;
using System;

namespace todo
{
    public class TodoService
    {
        private ILogger<TodoService> _logger;
        private string CONNECTION_STRING = "server=127.0.0.1;user=todo_rw;password=todo_pass;database=todo";

        public TodoService(ILogger<TodoService> logger)
        {
            this._logger = logger;
        }

        public async Task<List<Todo>> FindTodos(bool includeDone)
        {
            using (System.Data.IDbConnection db = new MySqlConnection(this.CONNECTION_STRING))
            {
                var filter = includeDone ? "" : " WHERE done = false ";
                var query = $"SELECT * FROM todo.todos {filter} ORDER BY id DESC";
                return (await db.QueryAsync<Todo>(query)).ToList();
            }
        }

        public async Task<Todo> CreateTodo(CreateTodoDTO title)
        {
            throw new NotImplementedException();
        }

        public async Task<Todo> UpdateTodo(UpdateTodoDTO update)
        {
            //TODO: no pun intended. Make this update a TODO
            throw new NotImplementedException();
        }

        public async Task<Todo> DeleteTodo(int id)
        {
            //TODO: no pun intended. Make this delete a todo.
            throw new NotImplementedException();
        }
    }
}