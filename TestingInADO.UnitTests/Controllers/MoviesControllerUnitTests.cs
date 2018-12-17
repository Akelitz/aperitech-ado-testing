using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingInADO.Models;
using TestingInADO.Repositories;
using TestingInADO.Services;
using TestingInADO.ViewModels;

namespace TestingInADO.Controllers
{
    [TestClass]
    public class MoviesControllerUnitTests
    {
        [TestMethod]
        public async Task when_no_year_is_provided_then_the_full_list_of_movies_is_returned()
        {
            //Arrange
            var years = new List<int> { 2017, 2018 };
            var movies = new List<MovieModel> { new MovieModel { Id = 1, Title = "Uno", Year = 2017 }, new MovieModel { Id = 2, Title = "Due", Year = 2018 } };
            IMovieRepository repository = Substitute.For<IMovieRepository>();
            repository.LoadAllYearsAsync().Returns(years);
            repository.LoadAllMoviesAsync().Returns(movies);
            IStarsCalculator starsCalculator = Substitute.For<IStarsCalculator>();
            starsCalculator.GetStarsFromRatings(Arg.Any<List<RatingComponent>>()).Returns(3);
            MoviesController controller = new MoviesController(repository, starsCalculator);

            //Act
            IActionResult actualResult = await controller.Index(null);

            //Assert
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            repository.Received(1).LoadAllYearsAsync();
            repository.Received(1).LoadAllMoviesAsync();
            repository.DidNotReceive().LoadMoviesByYearAsync(Arg.Any<int>());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            actualResult.Should().BeOfType<ViewResult>();
            ViewResult viewResult = (ViewResult)actualResult;
            viewResult.ViewData.Model.Should().BeAssignableTo<MoviesIndexViewModel>();
            MoviesIndexViewModel viewModel = (MoviesIndexViewModel)viewResult.ViewData.Model;
            viewModel.IsYear.Should().Be(false);
            viewModel.Years.Should().BeEquivalentTo(years);
            viewModel.Movies.Should().HaveCount(2);
            viewModel.Movies.First().Id.Should().Be(movies.First().Id);
            viewModel.Movies.First().Title.Should().Be(movies.First().Title);
            viewModel.Movies.First().Year.Should().Be(movies.First().Year);
            viewModel.Movies.First().Stars.Should().Be(3);
            viewModel.Movies.Last().Id.Should().Be(movies.Last().Id);
            viewModel.Movies.Last().Title.Should().Be(movies.Last().Title);
            viewModel.Movies.Last().Year.Should().Be(movies.Last().Year);
            viewModel.Movies.Last().Stars.Should().Be(3);
        }

        [TestMethod]
        public async Task when_a_year_is_provided_then_the_list_of_movies_for_that_year_is_returned()
        {
            //Arrange
            var years = new List<int> { 2017, 2018 };
            var movies = new List<MovieModel> { new MovieModel { Id = 1, Title = "Uno", Year = 2017 } };
            IMovieRepository repository = Substitute.For<IMovieRepository>();
            repository.LoadAllYearsAsync().Returns(years);
            repository.LoadMoviesByYearAsync(2017).Returns(movies);
            IStarsCalculator starsCalculator = Substitute.For<IStarsCalculator>();
            starsCalculator.GetStarsFromRatings(Arg.Any<List<RatingComponent>>()).Returns(3);
            MoviesController controller = new MoviesController(repository, starsCalculator);

            //Act
            IActionResult actualResult = await controller.Index(2017);

            //Assert
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            repository.Received(1).LoadAllYearsAsync();
            repository.Received(1).LoadMoviesByYearAsync(2017);
            repository.DidNotReceive().LoadAllMoviesAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            actualResult.Should().BeOfType<ViewResult>();
            ViewResult viewResult = (ViewResult)actualResult;
            viewResult.ViewData.Model.Should().BeAssignableTo<MoviesIndexViewModel>();
            MoviesIndexViewModel viewModel = (MoviesIndexViewModel)viewResult.ViewData.Model;
            viewModel.IsYear.Should().Be(true);
            viewModel.Years.Should().BeEquivalentTo(new List<int> { 2018 });
            viewModel.Movies.Should().HaveCount(1);
            viewModel.Movies.First().Id.Should().Be(movies.First().Id);
            viewModel.Movies.First().Title.Should().Be(movies.First().Title);
            viewModel.Movies.First().Year.Should().Be(movies.First().Year);
            viewModel.Movies.First().Stars.Should().Be(3);
        }
    }
}
