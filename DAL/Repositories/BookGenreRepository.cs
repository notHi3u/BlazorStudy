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
    public class BookGenreRepository : IBookGenreRepository
    {
        private readonly ApplicationDataContext _applicationDataContext;
        public BookGenreRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }

        public async Task<BookGenre> AddBookGenre(int bookId, int genreId)
        {
            var book = _applicationDataContext.BooksList.FirstOrDefault(b => b.Id == bookId);
            var genre = _applicationDataContext.GenresList.FirstOrDefault(g => g.Id == genreId);
            if (book != null && genre != null)
            {
                // Create a new BookGenre association
                var bookGenre = new BookGenre
                {
                    bgBook = book,
                    bgGenre = genre,
                    BookId = bookId,
                    GenreId = genreId
                };

                // Add the BookGenre to the BookGenres collection of the Genre
                genre.BookGenres.Add(bookGenre);

                // Save changes to update the database
                await _applicationDataContext.SaveChangesAsync();

                return bookGenre;
            }
            return null;
        }
        public async Task<bool> DeleteBookGenre(int bookId, int genreId)
        {
            var bg = await _applicationDataContext.BookGenres.FirstOrDefaultAsync(bg => bg.BookId == bookId && bg.GenreId == genreId);
            if (bg != null)
            {
                // Remove the BookGenre from the BookGenres collection of the Genre
                _applicationDataContext.BookGenres.Remove(bg);

                // Save changes to update the database
                await _applicationDataContext.SaveChangesAsync();

                return true; // Indicates a successful deletion
            }

            return false;
        }

        public async Task<List<Book>> GetBooksByGenre(int genreId)
        {
            return await _applicationDataContext.GenresList
                .Where(g => g.Id == genreId)
                .SelectMany(g => g.BookGenres.Select(bg => bg.bgBook))
                .ToListAsync();
        }

        public async Task<List<Genre>> GetGenresByBook(int bookId)
        {
            return await _applicationDataContext.BooksList
                .Where(b => b.Id == bookId)
                .SelectMany(b => b.BookGenres.Select(bg => bg.bgGenre))
                .ToListAsync();
        }
        //public async Task<BookGenre> UpdateBookGenre(int bookId, int genreId, Book newbook, Genre newgenre)
        //{
        //    var bg = await _applicationDataContext.BookGenres.FirstOrDefaultAsync(bg => bg.BookId == bookId && bg.GenreId == genreId);
        //    if(bg == null)
        //    {
        //        return null;
        //    }
        //    bg.BookId = newbook.Id;
        //    bg.GenreId = newgenre.Id;
        //    bg.bgBook = newbook;
        //    bg.bgGenre = newgenre;
        //    await _applicationDataContext.SaveChangesAsync();
        //    return bg;
        //}
    }
}
