using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookGenreService : IBookGenreService
    {
        private readonly IMapper _mapper;
        private readonly IBookGenreRepository _bookGenreRepository;
        public BookGenreService(IMapper mapper,IBookGenreRepository bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
            _mapper = mapper;
        }
        //public async Task<BookGenreDTO> AddBookGenre(int bookId, int genreId)
        //{
        //    BookGenre bookGenre =await _bookGenreRepository.AddBookGenre(bookId, genreId);
        //    BookGenreDTO bookGenreDTO = _mapper.Map<BookGenreDTO>(bookGenre);
        //    return bookGenreDTO;
        //}
        public async Task<bool> AddBookGenre(int bookId, int genreId)
        {
            //try
            //{
                await _bookGenreRepository.AddBookGenre(bookId, genreId);
                return true;
            //}
            //catch (Exception ex) 
            //{ 
            //    return false; 
            //}

        }

        public async Task<bool> DeleteBookGenre(int bookId, int genreId)
        {
            return await _bookGenreRepository.DeleteBookGenre(bookId, genreId);
        }

        public async Task<List<BookDTO>> GetBooksByGenre(int genreId)
        {
            List<Book> books = await _bookGenreRepository.GetBooksByGenre(genreId);
            List<BookDTO> result = _mapper.Map<List<BookDTO>>(books);
            return result;
        }

        public async Task<List<GenreDTO>> GetGenresByBook(int bookId)
        {
            List<Genre> genres = await _bookGenreRepository.GetGenresByBook(bookId);
            List<GenreDTO> genreDTOs = _mapper.Map<List<GenreDTO>>(genres);
            return genreDTOs;
        }
    }
}
