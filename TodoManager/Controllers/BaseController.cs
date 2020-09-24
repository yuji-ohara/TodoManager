using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TodoManager.Controllers
{
    public class BaseController : Controller
    {
        private ILogger _logger;
        private IConfiguration _configuration;

        public BaseController(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected async Task<IActionResult> AsyncMethods(Func<Task<IActionResult>> action, [CallerMemberName] string controller = "", [CallerFilePath] string method = "")
        {
            try
            {
                return await action();
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException.Message);
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
