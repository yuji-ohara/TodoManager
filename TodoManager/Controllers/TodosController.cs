using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TodoManager.Model.Request;
using Business;
using Models;

namespace TodoManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodosController : BaseController
    {
        

        public TodosController(PersonalManager todoManager, IConfiguration configuration, ILogger<TodosController> logger) : base(todoManager, configuration, logger)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetTodos([FromQuery] TodoFilter filters)
        {
            return await AsyncMethods(async () => {
                var result = await TodoManager.GetAll();

                return Ok(result);
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            return await AsyncMethods(async () => {
                var result = await TodoManager.GetById(id);

                return Ok(result);
            });
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddTodo([FromBody] Todo todo)
        {
            return await AsyncMethods(async () => {
                var result = await TodoManager.Create(todo);

                return Ok(result);
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] Todo todo)
        {
            return await AsyncMethods(async () => {
                todo.Id = id;
                var result = await TodoManager.Update(todo);

                return Ok(result);
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            return await AsyncMethods(async () => {
                var result = await TodoManager.Delete(id);

                return Ok(result);
            });
        }
    }
}
