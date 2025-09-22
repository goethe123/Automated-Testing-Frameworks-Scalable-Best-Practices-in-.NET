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
    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public void AcceptCookiesIfPresent()
        {
            try
            {
                Click(CookiesButton);
            }
            catch (Exception ex)
            {
                NUnit.Framework.TestContext.Out.WriteLine($"[WARN] AcceptCookiesIfPresent failed: {ex.Message}");
            }
        }

        public void GoToCareers()
        {
            Click(CareersButton);
        }

        public void OpenSearch()
        {
            Click(SearchIconButton);
        }

        public void Search(string keyword)
        {
            var input = WaitAndFind(SearchInput);
            input.Clear();
            input.SendKeys(keyword);
            Click(FindButton);
        }

        public void GoToAbout()
        {
            WaitToClickable(AboutButton).Click();
        }

        public void GoToInsights()
        {
            WaitToClickable(InsightsButton).Click();
        }
    }

}
