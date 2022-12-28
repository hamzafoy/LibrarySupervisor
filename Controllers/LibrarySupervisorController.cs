using Microsoft.AspNetCore.Mvc;

namespace LibrarySupervisor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrarySupervisorController : ControllerBase
    {
        private readonly ILogger<LibrarySupervisorController> _logger;

        public LibrarySupervisorController(ILogger<LibrarySupervisorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return $"This is a test";
        }
    }
}