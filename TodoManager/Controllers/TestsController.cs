using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using Business;

namespace TodoManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestsController : BaseController
    {
        public TestsController(PersonalManager todoManager, IConfiguration configuration, ILogger<TestsController> logger) : base(todoManager, configuration, logger)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public IActionResult Get()
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version.ToString();
            var server = Environment.MachineName;
            var result = $"Server:{server} Version: {version} - {DateTime.Now:yyyy/MM/dd HH:mm:ss}";
            Logger.LogInformation("HELLO WORLD!");
            return Ok(result);
        }
    }
}
