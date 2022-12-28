using LibrarySupervisor.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LibrarySupervisor.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly SqlConnection dbConnect = new SqlConnection();
        public List<LibraryBook> Get()
        {
            throw new NotImplementedException();
        }
    }
}
