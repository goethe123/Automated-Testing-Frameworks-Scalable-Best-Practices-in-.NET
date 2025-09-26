using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestCase1Epam.Business.Pages;
using NUnit.Framework;
using TestCase1Epam.Core.Hooks;

namespace TestCase1Epam.Tests
{
    [TestFixture]
    public class GlobalSearchTests : BaseTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        [SetUp]
        public void Setup()
        {
            Log.Info("Test setup intiated");
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("download.default_directory", Core.Utils.FileHelpers.DownloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Log.Info("driver intiated and browser oppened");
        }

        // Test #1: 
        [TestCase("java")]
        [TestCase("python")]
        public void ValidateUserCanSearchPosition(string keyword)
        {
            Log.Info($"1st Test, ValidateUserCanSearchPosition with {keyword} keyword");
            var home = new HomePage(driver, wait);
            var careers = new CareersPage(driver, wait);
            var search = new SearchPage(driver, wait);
            driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.GoToCareers();
            careers.SearchJob(keyword);
            search.OppenFirstViewAndApplyButton(4);
            Assert.That(search.ReturnResultBody().Contains(keyword.ToLower()));
            Log.Info("[PASS] ValidateUserCanSearchPosition passed correctly");
        }

        // Test #2:  search validations FALLAN
        [TestCase("automation")]
        [TestCase("blockchain")]
        [TestCase("cloud")]
        public void Validate_Global_Search_Returns_Correct_Results(string keyword)
        {
            Log.Info($"2nd Test, Validate_Global_Searzch_Returns_Correct_Results with {keyword} keyword");

            var home = new HomePage(driver, wait);
            var search = new SearchPage(driver, wait);
            driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.OpenSearch();
            home.Search(keyword);
            Assert.That(search.GetResultsText(), Is.All.Contains(keyword.ToLower()),
            $"All the results does not contain the keyword: {keyword}");
            Log.Info("[PASS] Validate_Global_Searzch_Returns_Correct_Results passed correctly");
        }

        //  Test #3: File download Validation
        [TestCase("EPAM_Corporate_Overview_Sept_25.pdf")]
        public void Validate_File_Download(string expectedFileName)
        {
            var home = new HomePage(driver, wait);
            var about = new AboutPage(driver, wait);
            driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.GoToAbout();
            about.ClickDownloadButton();
            string filePath = Path.Combine(Core.Utils.FileHelpers.DownloadPath, expectedFileName);
            bool fileExists = Core.Utils.FileHelpers.WaitForFileToBeDownloaded(filePath, 15);
            Assert.That(fileExists, Is.True, $"File '{expectedFileName}' was not downloaded.");
        }

        //TestCase 4
        [Test]
        public void ValidateCarouselTitle()
        {
            var home = new HomePage(driver, wait);
            var insights = new InsightsPage(driver, wait);
            driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.GoToInsights();
            insights.ClickSwipeButton();
            string CarouselTitle = insights.TakeCarouselElementTitle();
            insights.ClickReadMoreButton();
            string ArticleTitle = insights.TakeArticleTitle();
            Assert.That(ArticleTitle, Is.EqualTo(CarouselTitle), $" The Article's Title ('{ArticleTitle}') does not match with the Carousel's title ('{CarouselTitle}').");
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
