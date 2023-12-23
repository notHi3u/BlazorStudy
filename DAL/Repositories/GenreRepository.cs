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
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDataContext _applicationDataContext;

        public GenreRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }
        public async Task<Genre> AddGenre(Genre genre)
        {
            _applicationDataContext.GenresList.Add(genre);
            await _applicationDataContext.SaveChangesAsync();
            return genre;
        }

        public async Task<bool> DeleteGenre(int Id)
        {
            var genre = _applicationDataContext.GenresList.FirstOrDefault(b => b.Id == Id);
            if (genre == null)
            {
                return false;
            }
            _applicationDataContext.Remove(genre);
            await _applicationDataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await _applicationDataContext.GenresList.ToListAsync();
        }

        public async Task<Genre> GetGenreById(int Id)
        {
            var genre = _applicationDataContext.GenresList.FirstOrDefault(b => b.Id == Id);
            if (genre == null)
            {
                return null;
            }
            return genre;
        }




        public async Task<Genre> UpdateGenre(Genre genre, int Id)
        {
            var oldgenre = _applicationDataContext.GenresList.FirstOrDefault(bg => bg.Id == Id);
            if (oldgenre == null)
            {
                return null;
            }
            oldgenre.Name = genre.Name;
            await _applicationDataContext.SaveChangesAsync();
            return genre;
        }
    }
}
