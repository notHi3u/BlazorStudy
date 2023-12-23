using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp4v6.Shared;
using AutoMapper;
using BLL.DTOs;

namespace BlazorApp4v6.Shared.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BookDTO> AddBook(BookDTO book)
        {
            Book bookEntity = _mapper.Map<Book>(book);
            Book addedBookEntity = await _repository.AddBook(bookEntity);
            BookDTO addedBookDTO = _mapper.Map<BookDTO>(addedBookEntity);
            return addedBookDTO;
        }

        public async Task<bool> DeleteBook(int Id)
        {
            return await _repository.DeleteBook(Id);
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            List<Book> books = await _repository.GetAllBooks();
            List<BookDTO> bookDTOs = _mapper.Map<List<BookDTO>>(books);
            return bookDTOs;
        }

        public async Task<BookDTO> GetBookId(int Id)
        {
            Book book = await _repository.GetBookId(Id);
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }

        public async Task<BookDTO> UpdateBook(BookDTO book, int Id)
        {
            Book bookE = _mapper.Map<Book>(book);
            Book updatedBook = await _repository.UpdateBook(bookE, Id);
            BookDTO updatedBookDTO = _mapper.Map<BookDTO>(updatedBook);
            return updatedBookDTO;
        }
    }
}
