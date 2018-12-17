using OpenQA.Selenium;

namespace TestingInADO
{
    public static class IWebElementExtensions
    {
        public static IWebElement TryFindElement(this IWebElement element, By by)
        {
            try
            {
                return element.FindElement(by);
            }
            catch
            {
                return null;
            }
        }
    }
}
