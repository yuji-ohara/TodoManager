using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TodoManager.Model.Request;
using Business;

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
    }
}
