using BLL.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllGenres();
        Task<GenreDTO> GetGenreById(int Id);
        Task<GenreDTO> AddGenre(GenreDTO genre);
        Task<GenreDTO> UpdateGenre(GenreDTO genre, int Id);
        Task<bool> DeleteGenre(int Id);
    }
}
