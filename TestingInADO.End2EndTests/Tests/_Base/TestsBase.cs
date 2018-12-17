using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestingInADO.Tests
{
    public abstract class TestsBase
    {
        protected const int I_CROODZ = 7;
        protected const int IL_VIAGGIO_DI_ARLO = 33;
        protected const int MINIONS = 1;
        protected const int PIOVONO_GNOCCHI = 27;
        protected const int RATATOUILLE = 31;

        protected Uri _baseUrl;
        protected IWebDriver _driver;

        public TestContext TestContext { get; set; }


        public void Launch(string url = "")
        {
            _baseUrl = new Uri(TestContext.Properties["appUrl"].ToString());
            var driverLocation = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (string.IsNullOrEmpty(driverLocation))
                _driver = new ChromeDriver(Environment.CurrentDirectory);
            else
                _driver = new ChromeDriver(driverLocation);
            _driver.Navigate().GoToUrl(_baseUrl + url);
        }
    }
}
