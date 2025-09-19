using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace TestCase1Epam.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public void AcceptCookiesIfPresent()
        {
            try
            {
                Click(By.CssSelector("#onetrust-accept-btn-handler, .onetrust-accept-btn-handler"));
            }
            catch { }
        }

        public void GoToCareers() => Click(By.LinkText("Careers"));

        public void OpenSearch()
        {
            Click(By.CssSelector(".header-search__button.header__icon"));
        }

        public void Search(string keyword)
        {
            var input = WaitAndFind(By.Name("q"));
            input.Clear();
            input.SendKeys(keyword);
            Click(By.CssSelector("button.custom-search-button"));
        }
    }

}
