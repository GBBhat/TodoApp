
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using TaskAPI.Models;

namespace TaskAPI.Data
{
    public class TodoRepo : ITodoRepo
    {
        private readonly TaskContext _context;

        public TodoRepo(TaskContext taskContext)
        {
            _context = taskContext;
        }

        public async Task<Todo> CreateTodo(Todo todo)
        {
            var query = @"insert into todo (name, duedate, Completed) values(@name, @duedate, @completed)" +
                "select cast(scope_identity() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("name", todo.Name, DbType.String);
            parameters.Add("duedate", todo.DueDate, DbType.Date);
            parameters.Add("completed", todo.Completed, DbType.String);

            using(var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTodo = new Todo
                {
                    Id = id,
                    Name = todo.Name,
                    DueDate = todo.DueDate,
                    Completed = todo.Completed
                };
                return createdTodo;
            }

        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            var query = @"select * from todo";
            using(var connection = _context.CreateConnection())
            {
                var todos = await connection.QueryAsync<Todo>(query);
                return todos.ToList();
            }            
        }

        public async Task<Todo> GetTodoById(int id)
        {
            var query = @"select * from todo where id = @id";
            using(var connection = _context.CreateConnection())
            {
                var todo = await connection.QueryFirstOrDefaultAsync<Todo>(query, new { id});

                return todo;
            }
        }

        public async Task UpdateTodo(int id,Todo todo)
        {
            var query = @"update todo set name=@name, duedate=@duedate, completed=@Completed where id=@id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("name", todo.Name, DbType.String);
            parameters.Add("duedate", todo.DueDate, DbType.Date);
            parameters.Add("completed", todo.Completed, DbType.String);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteTodo(int id)
        {
            var query = @"delete from todo where id = @id";
           
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
