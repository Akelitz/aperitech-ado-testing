using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestingInADO.Models;
using TestingInADO.Repositories;
using TestingInADO.Services;
using TestingInADO.ViewModels;

namespace TestingInADO.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repository;
        private readonly IStarsCalculator _starsCalculator;

        public MoviesController(IMovieRepository repository, IStarsCalculator starsCalculator)
        {
            _repository = repository;
            _starsCalculator = starsCalculator;
        }

        [HttpGet("{year:int?}")]
        public async Task<IActionResult> Index(int? year)
        {
            ICollection<MovieModel> movies;
            IEnumerable<int> years = await _repository.LoadAllYearsAsync();
            if (year.HasValue)
            {
                movies = await _repository.LoadMoviesByYearAsync(year.Value);
                years = years.Where(y => y != year.Value);
            }
            else
            {
                movies = await _repository.LoadAllMoviesAsync();
            }
            ViewBag.Title = "Movies" + (year.HasValue ? $" in {year.Value}" : "");
            return View(
                new MoviesIndexViewModel(movies, years, year.HasValue, _starsCalculator)
            );
        }

        [HttpGet("{id:int}/view")]
        public async Task<IActionResult> Details(int id)
        {
            MovieModel movie = await _repository.LoadMovieByIdAsync(id);
            if (movie == null)
                return NotFound();
            ViewBag.Title = movie.Title;
            return View(
                new MovieViewModel(movie, _starsCalculator)
            );
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            ViewBag.Title = "New movie";
            return View();
        }

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, [Bind("Title,Year")]  MovieViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest();
            if (ModelState.IsValid)
            {
                var model = new MovieModel
                {
                    Title = viewModel.Title,
                    Year = viewModel.Year
                };
                await _repository.AddMovie(model);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet("{id:int}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            MovieModel movie = await _repository.LoadMovieByIdAsync(id);
            if (movie == null)
                return NotFound();
            ViewBag.Title = movie.Title;
            return View(
                new MovieViewModel(movie, _starsCalculator)
            );
        }

        [HttpPost("{id:int}/edit")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Year")]  MovieViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest();
            if (id != viewModel.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                MovieModel model = await _repository.LoadMovieByIdAsync(id);
                if (model == null)
                    return NotFound();
                model.Title = viewModel.Title;
                model.Year = viewModel.Year;
                await _repository.EditMovie();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            MovieModel movie = await _repository.LoadMovieByIdAsync(id);
            if (movie == null)
                return NotFound();
            ViewBag.Title = movie.Title;
            return View(
                new MovieViewModel(movie, _starsCalculator)
            );
        }

        [HttpPost("{id:int}/delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            MovieModel movie = await _repository.LoadMovieByIdAsync(id);
            if (movie == null)
                return NotFound();
            await _repository.DeleteMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
