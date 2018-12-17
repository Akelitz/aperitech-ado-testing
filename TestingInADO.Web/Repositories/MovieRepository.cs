using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingInADO.Data;
using TestingInADO.Models;

namespace TestingInADO.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddMovie(MovieModel movie)
        {
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMovie(MovieModel movie)
        {
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
        }

        public async Task EditMovie()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<MovieModel>> LoadAllMoviesAsync()
            => await _db.Movies
                .Include(m => m.Ratings)
                .OrderBy(m => m.Title)
                .ToListAsync();

        public async Task<IEnumerable<int>> LoadAllYearsAsync()
            => await _db.Movies
                .Select(m => m.Year)
                .Distinct()
                .OrderBy(y => y)
                .ToListAsync();

        public async Task<MovieModel> LoadMovieByIdAsync(int id)
            => await _db.Movies
                .Include(m => m.Ratings)
                .SingleOrDefaultAsync(m => m.Id == id);

        public async Task<ICollection<MovieModel>> LoadMoviesByYearAsync(int year)
            => await _db.Movies
                .Include(m => m.Ratings)
                .Where(m => m.Year == year)
                .OrderBy(m => m.Title)
                .ToListAsync();
    }
}
