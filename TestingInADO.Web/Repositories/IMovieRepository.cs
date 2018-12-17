using System.Collections.Generic;
using System.Threading.Tasks;
using TestingInADO.Models;
using TestingInADO.ViewModels;

namespace TestingInADO.Repositories
{
    public interface IMovieRepository
    {
        Task AddMovie(MovieModel movie);

        Task DeleteMovie(MovieModel movie);

        Task EditMovie();

        Task<ICollection<MovieModel>> LoadAllMoviesAsync();

        Task<IEnumerable<int>> LoadAllYearsAsync();

        Task<MovieModel> LoadMovieByIdAsync(int id);

        Task<ICollection<MovieModel>> LoadMoviesByYearAsync(int value);
    }
}
