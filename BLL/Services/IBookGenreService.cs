using BLL.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBookGenreService
    {
        Task<List<BookDTO>> GetBooksByGenre(int genreId);
        Task<List<GenreDTO>> GetGenresByBook(int bookId);
        Task<bool> AddBookGenre(int bookId, int genreId);
        Task<bool> DeleteBookGenre(int bookId, int genreId);
    }
}
