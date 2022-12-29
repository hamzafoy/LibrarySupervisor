using Microsoft.AspNetCore.Mvc;
using LibrarySupervisor.Models;
using LibrarySupervisor.Repositories;

namespace LibrarySupervisor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrarySupervisorController : ControllerBase
    {
        private readonly ILogger<LibrarySupervisorController> _logger;
        private readonly ILibraryRepository _libraryRepository;

        public LibrarySupervisorController(ILogger<LibrarySupervisorController> logger, ILibraryRepository libraryRepository)
        {
            _logger = logger;
            _libraryRepository = libraryRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<LibraryBook> Get()
        {
            return _libraryRepository.Get().ToList();
        }
    }
}