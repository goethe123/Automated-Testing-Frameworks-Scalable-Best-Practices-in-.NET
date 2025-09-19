using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestCase1Epam.Pages
{
    internal class AboutPage : BasePage
    {
        public AboutPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        { }

        public void GoToAbout()
        {
            Wait.Until(ExpectedConditions
                .ElementToBeClickable(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[4]/span[1]/a")))
                .Click();
        }

        public void ScrollToDownloadButton()
        {
            var downloadButton = Wait.Until(ExpectedConditions.ElementExists(
                By.CssSelector("a.button-ui-23.btn-focusable")));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", downloadButton);
        }

        public void ClickDownload()
        {
            // 🔹 Espera y hace clic en el botón Download
            var downloadButton = Wait.Until(ExpectedConditions
                .ElementToBeClickable(By.CssSelector("a.button-ui-23.btn-focusable")
));

            downloadButton.Click();
        }
    }
}
