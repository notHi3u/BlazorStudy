
using BLL.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp4v6.Shared.Services
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookId(int Id);
        Task<BookDTO> AddBook(BookDTO book);
        Task<BookDTO> UpdateBook(BookDTO book, int Id);
        Task<bool> DeleteBook(int Id);
    }
}
