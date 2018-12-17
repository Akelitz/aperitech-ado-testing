using OpenQA.Selenium;

namespace TestingInADO.PageObjects.Movies
{
    public partial class IndexPage : PageBase
    {
        public IndexPage(IWebDriver driver) : base(driver) { }

        public IndexPage filter_by_year(int year)
        {
            GetYearLink(year).Click();
            return this;
        }

        public bool is_movies_page()
        {
            return PageHeader.Text.Trim() == "Movies"
                && MoviesTable != null
                && MoviesTable.FindElements(By.TagName("tr")).Count > 30;
        }

        public bool is_movies_page_for_year(int year)
        {
            return PageHeader.Text == $"Movies in {year}"
                && MoviesTable.FindElements(By.TagName("tr")).Count == 4
                && AllYearsLink != null;
        }

        public bool movie_exists(string title)
            => GetMovieRow(title) != null;


        public AddPage add_movie()
        {
            AddNewMovieLink.Click();
            return new AddPage(_driver);
        }

        public DeletePage delete_movie(int id)
        {
            GetMovieDeleteLink(id).Click();
            return new DeletePage(_driver);
        }

        public EditPage edit_movie(int id)
        {
            GetMovieEditLink(id).Click();
            return new EditPage(_driver);
        }

        public DetailsPage navigate_to_movie(int id)
        {
            GetMovieDetailsLink(id).Click();
            return new DetailsPage(_driver);
        }


        protected IWebElement AddNewMovieLink
            => _driver.FindElement(By.LinkText("Add New"));

        protected IWebElement AllYearsLink
            => _driver.FindElement(By.Id("Years")).TryFindElement(By.LinkText("All"));

        protected IWebElement MoviesTable
            => _driver.FindElement(By.Id("Movies"));

        protected IWebElement PageHeader
            => _driver.FindElement(By.XPath("//h2"));

        protected IWebElement GetMovieDeleteLink(int id)
            => _driver.TryFindElement(By.Id($"Movie{id}"))?.FindElement(By.LinkText("Delete"));

        protected IWebElement GetMovieDetailsLink(int id)
            => _driver.TryFindElement(By.Id($"Movie{id}"))?.FindElement(By.LinkText("Details"));

        protected IWebElement GetMovieEditLink(int id)
            => _driver.TryFindElement(By.Id($"Movie{id}"))?.FindElement(By.LinkText("Edit"));

        protected IWebElement GetMovieRow(string title)
            => MoviesTable.TryFindElement(By.XPath($"//tr/td[text()='{title}']"));

        protected IWebElement GetYearLink(int year)
            => _driver.FindElement(By.Id("Years")).TryFindElement(By.LinkText(year.ToString()));
    }
}
