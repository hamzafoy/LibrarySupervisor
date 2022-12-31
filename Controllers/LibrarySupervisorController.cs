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

        [HttpGet("/GetAllBooks")]
        public List<LibraryBook> Get()
        {
            return _libraryRepository.Get().ToList();
        }

        [HttpPost("/PostABook")]
        public ActionResult PostNewBook([FromBody] LibraryBook newBook)
        {
            _libraryRepository.Post(newBook);
            return Created("", newBook);
        }
    }
}