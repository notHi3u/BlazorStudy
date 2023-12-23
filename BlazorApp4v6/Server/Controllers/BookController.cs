using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BlazorApp4v6.Shared.DTOs;
using BlazorApp4v6.Shared.Services;
using BlazorApp4v6.Shared.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Services;

namespace BlazorApp4v6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _service;
        private readonly IBookGenreService _bookGenreService;
        public BookController(IBookService service, IMapper mapper, IBookGenreService bookGenreService)
        {
            _service = service;
            _mapper = mapper;
            _bookGenreService = bookGenreService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookUI>>> GetAllBooks()
        {
            try
            {
                var booksDTO = await _service.GetAllBooks();

                if (booksDTO == null || booksDTO.Count == 0)
                {
                    return NotFound("No books found.");
                }

                // Map booksDTO to BookUI
                var booksUI = _mapper.Map<List<BookUI>>(booksDTO);

                return Ok(booksUI);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's error handling strategy
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookUI>> GetBookById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Invalid book ID.");
                }

                var bookDTO = await _service.GetBookId(id.Value);

                if (bookDTO == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                // Map bookDTO to BookUI
                var bookUI = _mapper.Map<BookUI>(bookDTO);

                return Ok(bookUI);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's error handling strategy
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookUI>> AddBook(BookUI bookUI)
        {
            BookDTO bookDTO = _mapper.Map<BookDTO>(bookUI);
            BookDTO addedBookDTO = await _service.AddBook(bookDTO);
            BookUI addedBookUI = _mapper.Map<BookUI>(addedBookDTO);

            return Ok(addedBookUI);
        }
        [HttpPut]
        public async Task<ActionResult<BookUI>> UpdateBook(BookUI bookUI, int Id)
        {
            BookDTO bookDTO = _mapper.Map<BookDTO>(bookUI);
            BookDTO updatedBookDTO = await _service.UpdateBook(bookDTO, Id);
            BookUI updatedBookUI = _mapper.Map<BookUI>(updatedBookDTO);
            return Ok(updatedBookUI);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {
            bool status = await _service.DeleteBook(id);
            if (status == false)
                return NotFound();
            return Ok();
        }
        [HttpGet("GetBooksByGenre/{genreId}")]
        public async Task<ActionResult<List<BookUI>>> GetBooksByGenre(int genreId)
        {
            try
            {
                List<BookDTO> bookDTOs = await _bookGenreService.GetBooksByGenre(genreId);

                if (bookDTOs == null || bookDTOs.Count == 0)
                {
                    return NotFound("No books found for the given genre.");
                }

                // Map bookDTOs to BookUIs
                List<BookUI> bookUIs = _mapper.Map<List<BookUI>>(bookDTOs);

                return Ok(bookUIs);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's error handling strategy
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
