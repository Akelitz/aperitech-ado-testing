﻿using OpenQA.Selenium;
using TestingInADO.ViewModels;

namespace TestingInADO.PageObjects.Movies
{
    public partial class AddPage : PageBase
    {
        public AddPage(IWebDriver driver) : base(driver) { }


        public IndexPage click_save()
        {
            SaveButton.Click();
            return new IndexPage(_driver);
        }

        public AddPage set_title_to(string title)
        {
            TitleInput.Clear();
            TitleInput.SendKeys(title);
            return this;
        }

        public AddPage set_year_to(int year)
        {
            YearInput.Clear();
            YearInput.SendKeys(year.ToString());
            return this;
        }


        protected IWebElement SaveButton
            => _driver.FindElement(By.XPath("//input[@value='Save']"));

        protected IWebElement TitleInput
            => _driver.FindElement(By.Id(nameof(MovieViewModel.Title)));

        protected IWebElement YearInput
             => _driver.FindElement(By.Id(nameof(MovieViewModel.Year)));
    }
}
