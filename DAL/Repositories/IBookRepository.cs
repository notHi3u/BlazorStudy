using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookId(int Id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book, int Id);
        Task<bool> DeleteBook(int Id);
        
    }
}
