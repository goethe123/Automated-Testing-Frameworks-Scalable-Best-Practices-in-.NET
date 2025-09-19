using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestCase1Epam.Pages;

namespace TestCaseEpam.Tests
{
    [TestFixture]
    public class GlobalSearchTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string downloadPath;

        [SetUp]
        public void Setup()
        {
            downloadPath = @"C:\Users\GoetheRamirez\Downloads";

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("download.default_directory", downloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);

            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Test #1: 
        [TestCase("java")]
        [TestCase("python")]
        public void ValidateUserCanSearchPosition(string keyword)
        {
            var home = new HomePage(driver, wait);
            var careers = new CareersPage(driver, wait);
            var search = new SearchPage(driver, wait);

            driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.GoToCareers();

            careers.SearchJob(keyword);
            careers.SelectAllLocations();
            careers.SelectRemote();
            careers.ClickFind();

            search.OpenFirstApplyLink();
            Assert.That(search.DescriptionContainsKeyword(keyword), Is.True);
            //siempre las validaciones en el test case
        }

        // Test #2:  search validations
        [TestCase("automation")]
        [TestCase("blockchain")]
        [TestCase("cloud")]
        public void Validate_Global_Search_Returns_Correct_Results(string keyword)
        {
            var home = new HomePage(driver, wait);
            var search = new SearchPage(driver, wait);

            driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();

            home.OpenSearch();
            home.Search(keyword);

            Assert.That(search.ResultsContainKeyword(keyword), Is.True);
        }

        //  Test #3: File download Validation
        [TestCase("EPAM_Corporate_Overview_Sept_25.pdf")]
        public void Validate_File_Download(string expectedFileName)
        {
            var home = new HomePage(driver, wait);
            var about = new AboutPage(driver, wait);

            driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            about.GoToAbout();
            about.ScrollToDownloadButton();
            about.ClickDownload();

            string filePath = Path.Combine(downloadPath, expectedFileName);
            bool fileExists = WaitForFile(filePath, 15);

            Assert.That(fileExists, Is.True, $"File '{expectedFileName}' was not downloaded.");
        }

        private bool WaitForFile(string filePath, int seconds)
        {
            for (int i = 0; i < seconds * 2; i++)
            {
                if (File.Exists(filePath) && !File.Exists(filePath + ".crdownload"))
                    return true;
                Thread.Sleep(500);
            }
            return false;

            //este metodo de wait debria de ir en en otra clase llamada utils y jalarlo aca, tambien se puede meter alla el file path
            //for = si no ha terminado de descargarse el archivo espera medio segundo hasta / es un * 2 por que espera medio segundo entonces espera un segundo
            //completo, buscar otros metodos de espera (librerias) este funciona pero esta muy piedra
            //basepage para todos los metodos que se comparten entre paginas, clicks, waits, inputs, etc todo para no crear siempre los metodos en cada object
        }

        //TestCase 4

        [Test]
        public void ValidateCarouselTitle()
        {
            var home = new HomePage(driver, wait);
            var insights = new InsightsPage(driver, wait);

            driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            insights.GoToInsights();

            insights.ClickSwipeButton();

            string CarouselTitle = insights.FindArticleTitle();
            insights.ClickReadMoreButton();
            string ArticleTitle = insights.TakeNewTitle();

            Assert.That(ArticleTitle, Is.EqualTo(CarouselTitle),$" The Article's Title ('{ArticleTitle}') does not match with the Carousel's title ('{CarouselTitle}').");
            //asi es como se deben de hacer las validaciones, se jala el metodo y luego la validacion en test
        }

            
        

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
