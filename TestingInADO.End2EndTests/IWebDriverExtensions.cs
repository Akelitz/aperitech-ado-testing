using OpenQA.Selenium;

namespace TestingInADO
{
    public static class IWebDriverExtensions
    {
        public static IWebElement TryFindElement(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by);
            }
            catch
            {
                return null;
            }
        }
    }
}
