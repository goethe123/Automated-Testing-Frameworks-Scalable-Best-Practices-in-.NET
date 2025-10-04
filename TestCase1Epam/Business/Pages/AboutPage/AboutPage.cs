using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestCase1Epam.Core.Utils;

namespace TestCase1Epam.Business.Pages
{
    public partial class AboutPage : WebDriverHelper
    {
        public AboutPage(IWebDriver driver) : base(driver)
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
        }
    }
}
