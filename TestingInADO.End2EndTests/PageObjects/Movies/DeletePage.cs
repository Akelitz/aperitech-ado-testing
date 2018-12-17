using OpenQA.Selenium;

namespace TestingInADO.PageObjects.Movies
{
    public partial class DeletePage : PageBase
    {
        public DeletePage(IWebDriver driver) : base(driver) { }


        public IndexPage click_confirm()
        {
            ConfirmButton.Click();
            return new IndexPage(_driver);
        }


        protected IWebElement ConfirmButton
            => _driver.FindElement(By.XPath("//input[@value='Confirm']"));
    }
}
