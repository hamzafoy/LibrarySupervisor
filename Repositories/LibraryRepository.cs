using LibrarySupervisor.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LibrarySupervisor.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly SqlConnection dbConnect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibrarySupervisorDb;Integrated Security=True;Connect Timeout=30;");
        public List<LibraryBook> Get()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPROC_LibraryBooksRead"))
                {
                    List<LibraryBook> books = new List<LibraryBook>();
                    DataTable data = new DataTable();
                    command.Connection = dbConnect;
                    command.CommandType = CommandType.StoredProcedure;
                    dbConnect.Open();
                    using (var results = command.ExecuteReader())
                    {
                        data.Load(results);
                    }
                    foreach (DataRow row in data.Rows)
                    {
                        var values = row.ItemArray;
                        LibraryBook book = new LibraryBook()
                        {
                            Title = values[0].ToString(),
                            Description = values[1].ToString(),
                            Author = values[2].ToString(),
                            Translator = values[3].ToString(),
                            PublishingHouse = values[4].ToString(),
                            Genre = values[5].ToString(),
                            ISBN = values[6].ToString()
                        };
                        books.Add(book);
                    }
                    dbConnect.Close();
                    return books;
                }
            } catch (Exception ex)
            {
                throw;
            }
        }

        public void Post(LibraryBook book)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPROC_LibraryBooksAdd"))
                {
                    command.Connection = dbConnect;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Description", book.Description);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Translator", book.Translator);
                    command.Parameters.AddWithValue("@PublishDate", book.PublishDate);
                    command.Parameters.AddWithValue("@PublishingHouse", book.PublishingHouse);
                    command.Parameters.AddWithValue("@Edition", book.Edition);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@PageCount", book.PageCount);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@SeriesNumber", book.SeriesNumber);
                    dbConnect.Open();
                    command.ExecuteNonQuery();
                    dbConnect.Close();
                }
            } catch (Exception ex)
            {
                throw;
            }
        }
    }
}
