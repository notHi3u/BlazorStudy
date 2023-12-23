using AutoMapper;
using BlazorApp4v6.Shared.Models;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp4v6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenreService _service;
        private readonly IBookGenreService _bookGenreService;
        public GenreController(IGenreService service, IMapper mapper, IBookGenreService bookGenreService)
        {
            _service = service;
            _mapper = mapper;
            _bookGenreService = bookGenreService;
        }
        [HttpGet]
        public async Task<ActionResult<List<GenreUI>>> GetAllGenres()
        {
            try
            {
                var genreDTOs = await _service.GetAllGenres();
                if (genreDTOs == null || genreDTOs.Count == 0)
                {
                    return NotFound("Nogenres found.");
                }
                var genreUIs = _mapper.Map<List<GenreUI>>(genreDTOs);
                return Ok(genreUIs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreUI>> GetGenreById(int id)
        {
            try
            {
                var genreDTO = await _service.GetGenreById(id);

                if (genreDTO == null)
                {
                    return NotFound($"Genre with ID {id} not found.");
                }
                var genreUI = _mapper.Map<GenreUI>(genreDTO);
                return Ok(genreUI);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's error handling strategy
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GenreUI>> AddGenre(GenreUI genreUI)
        {
            try
            {
               GenreDTO genreDTO = _mapper.Map<GenreDTO>(genreUI);
                await _service.AddGenre(genreDTO);
                return Ok(genreUI);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's error handling strategy
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpPut]
        public async Task<ActionResult<GenreUI>> UpdateGenre(GenreUI genreUI, int Id)
        {
            GenreDTO genreDTO = _mapper.Map<GenreDTO>(genreUI);
            await _service.UpdateGenre(genreDTO, Id);
            return Ok(genreDTO);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteGenre(int Id)
        {
            await _service.DeleteGenre(Id);
            return Ok();
        }
    }
}
