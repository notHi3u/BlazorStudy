using BlazorApp4v6.Shared.Models;

namespace BlazorApp4v6.Client.Services
{
    public interface IBookService
    {
        Task<List<BookUI>> GetAllBooks();
        Task<BookUI> GetBookId(int? Id);
        Task<bool> AddBook(BookUI bookDTO);
        Task<bool> UpdateBook(BookUI bookDTO);
        Task<bool> DeleteBook(int Id);
    }
}
