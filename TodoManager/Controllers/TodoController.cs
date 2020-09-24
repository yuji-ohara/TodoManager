using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TodoManager.Model.Request;
using Business;

namespace TodoManager.Controllers
{
    public class TodoController : BaseController
    {
        

        public TodoController(PersonalManager todoManager, IConfiguration configuration, ILogger<TodoController> logger) : base(todoManager, configuration, logger)
        {
        }

        public async Task<IActionResult> GetTodos([FromQuery] TodoFilter filters)
        {
            return await AsyncMethods(async () => {
                var result = await TodoManager.GetAll();

                return Ok(result);
            });
        }
    }
}
