using AngleSharp.Common;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace TestCase1Epam.Pages
{
    public class CareersPage : BasePage
    {
        public CareersPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public void SearchJob(string keyword)
        {
            var input = WaitAndFind(By.Id("new_form_job_search-keyword"));
            input.Clear();
            input.SendKeys(keyword);
        }

        public void SelectAllLocations()
        {
            Click(By.ClassName("select2-selection__rendered"));
            Click(By.CssSelector("li[title='All Locations']"));
        }

        public void SelectRemote()
        {
            Click(By.XPath("//label[contains(@class,'checkbox-custom-label') and contains(.,'Remote')]"));
        }

        public void ClickFind()
        {
            Click(By.CssSelector("button.job-search-button-transparent-23"));
        }

        public void ScrollResults()
        {
            var actions = new Actions(Driver);
            actions.ScrollByAmount(0, 600).Perform(); // Actions API scroll
        }
    }
}
