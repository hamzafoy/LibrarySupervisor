using LibrarySupervisor.Models;

namespace LibrarySupervisor.Repositories
{
    public interface ILibraryRepository
    {
        List<LibraryBook> Get();
        void Post(LibraryBook book);
    }
}
