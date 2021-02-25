

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

        public async Task<List<Todo>> FindTodos(string search, bool includeDone)
        {
            using (System.Data.IDbConnection db = new MySqlConnection(this.CONNECTION_STRING))
            {
                var doneFilter = includeDone ? "" : " AND done = false ";
                var filter = $@"WHERE title like '%{search}%' {doneFilter}";
                var query = $"SELECT * FROM todo.todos {filter} ORDER BY createdDate DESC";
                return (await db.QueryAsync<Todo>(query)).ToList();
            }
        }

        public async Task<Todo> FetchTodo(int id)
        {
            using (System.Data.IDbConnection db = new MySqlConnection(this.CONNECTION_STRING))
            {
                var query = $"SELECT * FROM todo.todos WHERE id = {id}";
                return (await db.QueryFirstAsync<Todo>(query));
            }
        }

        public async Task<int> CreateTodo(CreateTodoDTO dto)
        {
            using (System.Data.IDbConnection db = new MySqlConnection(this.CONNECTION_STRING))
            {
                var query = $"INSERT INTO todo.todos (title, createdDate, done) values (@title, @createdDate, @done) RETURNING id";
                return (int)(await db.QuerySingleAsync(query, dto)).id;
            }
        }

        public async Task<int> UpdateTodo(UpdateTodoDTO update)
        {

            using (System.Data.IDbConnection db = new MySqlConnection(this.CONNECTION_STRING))
            {
                var query = $"UPDATE todo.todos set title = @title, done = @done where id = @id";
                return (await db.ExecuteAsync(query, update));
            }
        }

        public async Task<int> DeleteTodo(int id)
        {
            using (System.Data.IDbConnection db = new MySqlConnection(this.CONNECTION_STRING))
            {
                var query = $"DELETE FROM todo.todos where id = {id}";
                return (await db.ExecuteAsync(query));
            }
        }
    }
}