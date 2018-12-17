using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestingInADO.Models;

namespace TestingInADO.Services.UnitTests
{
    [TestClass]
    public class StarsCalculatorUnitTests
    {
        [TestMethod]
        public void if_ratings_are_not_provided_then_stars_are_zero()
        {
            //Arrange
            int expectedResult = 0;
            StarsCalculator calculator = new StarsCalculator();

            //Act
            int actualResult = calculator.GetStarsFromRatings(null);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void if_no_ratings_are_available_then_stars_are_zero()
        {
            //Arrange
            List<RatingComponent> ratings = new List<RatingComponent>();
            int expectedResult = 0;
            StarsCalculator calculator = new StarsCalculator();

            //Act
            int actualResult = calculator.GetStarsFromRatings(ratings);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void if_a_single_rating_is_available_then_stars_are_the_same_as_rating()
        {
            //Arrange
            List<RatingComponent> ratings = new List<RatingComponent> { new RatingComponent { Value = 3 } };
            int expectedResult = 3;
            StarsCalculator calculator = new StarsCalculator();

            //Act
            int actualResult = calculator.GetStarsFromRatings(ratings);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void if_some_ratings_are_available_then_stars_are_the_rating_average()
        {
            //Arrange
            List<RatingComponent> ratings = new List<RatingComponent> { new RatingComponent { Value = 5 }, new RatingComponent { Value = 4 }, new RatingComponent { Value = 4 }, new RatingComponent { Value = 1 } };
            int expectedResult = 3;
            StarsCalculator calculator = new StarsCalculator();

            //Act
            int actualResult = calculator.GetStarsFromRatings(ratings);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
