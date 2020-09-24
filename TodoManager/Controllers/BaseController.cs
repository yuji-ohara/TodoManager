using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Business;

namespace TodoManager.Controllers
{
    public class BaseController : Controller
    {
        public ILogger Logger;
        public IConfiguration Configuration;
        public readonly PersonalManager TodoManager;
        public BaseController(PersonalManager todoManager, IConfiguration configuration, ILogger logger)
        {
            Logger = logger;
            Configuration = configuration;
            TodoManager = todoManager;
        }

        protected async Task<IActionResult> AsyncMethods(Func<Task<IActionResult>> action, [CallerMemberName] string controller = "", [CallerFilePath] string method = "")
        {
            try
            {
                return await Task.Run(action);
            }
            catch (ArgumentException argumentException)
            {
                Logger.LogError($"{controller}.{method}:{argumentException.Message}");
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                Logger.LogError($"{controller}.{method}:{ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
