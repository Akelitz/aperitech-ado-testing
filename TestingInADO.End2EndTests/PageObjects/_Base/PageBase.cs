using OpenQA.Selenium;

namespace TestingInADO.PageObjects
{
    public abstract partial class PageBase
    {
        protected IWebDriver _driver;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
