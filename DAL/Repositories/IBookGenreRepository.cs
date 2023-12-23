using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IBookGenreRepository
    {
        Task<List<Book>> GetBooksByGenre(int genreId);
        Task<List<Genre>> GetGenresByBook(int bookId);
        Task <BookGenre> AddBookGenre(int bookId, int genreId);
        Task <bool>DeleteBookGenre(int bookId, int genreId);
        //Task<BookGenre> UpdateBookGenre(int bookId, int genreId, string bookName, string genreName);
    }
}
