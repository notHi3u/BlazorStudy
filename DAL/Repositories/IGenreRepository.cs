using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(int Id);
        Task<Genre> AddGenre(Genre genre);
        Task<Genre> UpdateGenre(Genre genre, int Id);
        Task<bool> DeleteGenre(int Id);
        
    }
}
