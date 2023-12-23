using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDataContext _applicationDataContext;
        public BookRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }
        public async Task<Book> AddBook(Book book)
        {
            _applicationDataContext.BooksList.Add(book);
            await _applicationDataContext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int Id)
        {
            var book = _applicationDataContext.BooksList.FirstOrDefault(b => b.Id == Id);
            if (book == null)
            {
                return false;
            }
            _applicationDataContext.Remove(book);
            await _applicationDataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _applicationDataContext.BooksList.ToListAsync();
        }

        public async Task<Book> GetBookId(int Id)
        {
            var book = _applicationDataContext.BooksList.FirstOrDefault(b => b.Id == Id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        

        public async Task<Book> UpdateBook(Book book, int Id)
        {
            var oldbook = _applicationDataContext.BooksList.FirstOrDefault(_b => _b.Id == Id);
            if (oldbook == null)
            {
                return null;
            }
            oldbook.Name = book.Name;
            oldbook.Author = book.Author;
            await _applicationDataContext.SaveChangesAsync();
            return book;
        }
    }
}
