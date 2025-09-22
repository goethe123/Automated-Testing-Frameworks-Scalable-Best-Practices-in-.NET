using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestCase1Epam.Pages
{
    public partial class AboutPage : BasePage
    {
        public AboutPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        { }
        public void ClickDownloadButton()
        {
            ScrollToDownloadButton();
            ClickDownload();
        }

        private void ScrollToDownloadButton()
        {
            var downloadButton = WaitToExist(DownloadButton);
            Actions.MoveToElement(downloadButton).Perform();
            
        }

        private void ClickDownload()
        {

            Click(DownloadButton);

            //variable de uso unico
        }
    }
}
