using OpenQA.Selenium;

namespace TestingInADO.PageObjects.Movies
{
    public partial class DetailsPage : PageBase
    {
        public DetailsPage(IWebDriver driver) : base(driver) { }


        public bool is_movie_page_for(string title)
            => PageHeader.Text == title;


        public DeletePage delete()
        {
            DeleteLink.Click();
            return new DeletePage(_driver);
        }

        public EditPage edit()
        {
            EditLink.Click();
            return new EditPage(_driver);
        }

        protected IWebElement DeleteLink
            => _driver.FindElement(By.LinkText("Delete"));

        protected IWebElement EditLink
            => _driver.FindElement(By.LinkText("Edit"));

        protected IWebElement PageHeader
            => _driver.FindElement(By.XPath("//h2"));
    }
}
