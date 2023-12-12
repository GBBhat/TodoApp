using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Data;
using TaskAPI.Dtos;
using TaskAPI.Models;

namespace TaskAPI.Controllers
{
    /// <summary>
    /// Todo controller handles Get, Create, Update, Delete operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepo _repository;
        private readonly IMapper _mapper;
        public TodosController(ITodoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTodos()
        {
            try
            {
                var todos = await _repository.GetAllTodos();
                if (todos == null) return NotFound();

                return Ok(_mapper.Map<IEnumerable<TodoDto>>(todos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetTodoById")]
        public async Task<ActionResult> GetTodoById(int id)
        {
            try
            {
                var todo = await _repository.GetTodoById(id);
                if (todo == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<TodoDto>(todo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTodo(TodoDto TodoDto)
        {
            try
            {
                var todo = _mapper.Map<Todo>(TodoDto);
                var createdTodo = await _repository.CreateTodo(todo);
                return CreatedAtRoute(nameof(GetTodoById), new { id = createdTodo.Id }, createdTodo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodo(int id, TodoDto TodoDto)
        {
            try
            {
                var todo = await _repository.GetTodoById(id);
                if (todo == null)
                {
                    return NotFound();
                }

                _mapper.Map(TodoDto, todo);
                await _repository.UpdateTodo(id, todo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            try
            {
                var todo = await _repository.GetTodoById(id);
                if (todo == null)
                { return  NotFound(); }

                await _repository.DeleteTodo(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
