using System;
using System.Collections.Generic;
using System.Linq;
using TestingInADO.Models;
using TestingInADO.Services;

namespace TestingInADO.ViewModels
{
    public class MoviesIndexViewModel
    {
        public bool IsYear { get; }

        public ICollection<MovieViewModel> Movies { get; }

        public IEnumerable<int> Years { get; }

        public MoviesIndexViewModel(ICollection<MovieModel> movies, IEnumerable<int> years, bool isYear, IStarsCalculator starsCalculator)
        {
            Movies = movies?.Select(m => new MovieViewModel(m, starsCalculator))?.ToList() ?? throw new ArgumentNullException(nameof(movies));
            Years = years ?? throw new ArgumentNullException(nameof(years));
            IsYear = isYear;
        }
    }
}
