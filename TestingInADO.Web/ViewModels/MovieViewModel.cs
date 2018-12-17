using System.ComponentModel.DataAnnotations;
using TestingInADO.Models;
using TestingInADO.Services;

namespace TestingInADO.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Rating")]
        public int Stars { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(2000,2018)]
        public int Year { get; set; }

        public MovieViewModel()
        {
        }

        public MovieViewModel(MovieModel movie, IStarsCalculator starsCalculator)
        {
            Id = movie.Id;
            Stars = starsCalculator.GetStarsFromRatings(movie.Ratings);
            Title = movie.Title;
            Year = movie.Year;
        }
    }
}
