using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestingInADO.Tests;
using Pages = TestingInADO.PageObjects;

namespace TestingInADO.Movies.Tests
{
    [TestClass]
    public class MoviesEnd2EndTests : TestsBase
    {
        protected Pages.Movies.IndexPage from_the_movies_page;


        [TestInitialize]
        public void Initialize()
        {
            Launch("Movies");
            from_the_movies_page = new Pages.Movies.IndexPage(_driver);
        }


        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void as_a_user_i_can_filter_the_list_of_movies_by_year()
        {
            Assert.IsTrue(
                from_the_movies_page
                    .filter_by_year(2007)
                    .is_movies_page_for_year(2007)
            );
        }

        [TestMethod]
        public void as_a_user_i_can_see_the_details_of_a_movie()
        {
            Assert.IsTrue(
                from_the_movies_page
                    .navigate_to_movie(RATATOUILLE)
                    .is_movie_page_for("Ratatouille")
            );
        }

        [TestMethod]
        public void as_a_user_i_can_add_a_new_movie()
        {
            Assert.IsTrue(
                from_the_movies_page
                    .add_movie()
                    .set_title_to("Il piccolo principe")
                    .set_year_to(2015)
                    .click_save()
                    .movie_exists("Il piccolo principe")
            );
        }

        [TestMethod]
        public void as_a_user_i_can_edit_a_movie_starting_from_the_list()
        {
            Assert.IsTrue(
                from_the_movies_page
                    .edit_movie(PIOVONO_GNOCCHI)
                    .set_title_to("Piovono polpette")
                    .click_save()
                    .movie_exists("Piovono polpette")
            );
        }

        [TestMethod]
        public void as_a_user_i_can_delete_a_movie_starting_from_the_list()
        {
            Assert.IsFalse(
                from_the_movies_page
                    .delete_movie(IL_VIAGGIO_DI_ARLO)
                    .click_confirm()
                    .movie_exists("Il viaggio di Arlo")
            );
        }

        [TestMethod]
        public void as_a_i_can_edit_a_movie_starting_from_the_details()
        {
            Assert.IsTrue(
                from_the_movies_page
                    .navigate_to_movie(I_CROODZ)
                    .edit()
                    .set_title_to("I Croods")
                    .click_save()
                    .movie_exists("I Croods")
            );
        }

        [TestMethod]
        public void as_a_user_i_can_delete_a_movie_starting_from_the_details()
        {
            Assert.IsFalse(
                from_the_movies_page
                    .navigate_to_movie(MINIONS)
                    .delete()
                    .click_confirm()
                    .movie_exists("Minions")
            );
        }
    }
}
