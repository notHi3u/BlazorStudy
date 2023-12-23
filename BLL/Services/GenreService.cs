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
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _repository;
        public GenreService(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _repository = genreRepository;
        }
        public async Task<GenreDTO> AddGenre(GenreDTO genreDTO)
        {
            Genre genreDAL = _mapper.Map<Genre>(genreDTO);
            Genre addedGenreDAL =  await _repository.AddGenre(genreDAL);
            GenreDTO addedGenreDTO = _mapper.Map<GenreDTO>(addedGenreDAL);
            return addedGenreDTO;
        }

        public async Task<bool> DeleteGenre(int Id)
        {
            return await _repository.DeleteGenre(Id);
        }

        public async Task<List<GenreDTO>> GetAllGenres()
        {
            List<Genre> genres = await _repository.GetAllGenres();
            List<GenreDTO> genreDTOs = _mapper.Map<List<GenreDTO>>(genres);
            return genreDTOs;
        }

        public async Task<GenreDTO> GetGenreById(int Id)
        {
            Genre genre = await _repository.GetGenreById(Id);
            GenreDTO genreDTO = _mapper.Map<GenreDTO>(genre);
            return genreDTO;
        }

        public async Task<GenreDTO> UpdateGenre(GenreDTO genre, int Id)
        {
            Genre genre1 = _mapper.Map<Genre>(genre);
            Genre genre2 = await _repository.UpdateGenre(genre1, Id);
            GenreDTO genreDTO = _mapper.Map<GenreDTO>(genre2);
            return genreDTO;
        }
    }
}
