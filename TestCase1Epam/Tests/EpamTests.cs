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
        

        [SetUp]
        public void Setup()
        {
           

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("download.default_directory", FileHelpers.DownloadPath);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            options.AddArgument("--start-maximized");
            options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                                "AppleWebKit/537.36 (KHTML, like Gecko) " +
                                "Chrome/117.0.0.0 Safari/537.36");

            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Test #1: 
        // [TestCase("java")]
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
            careers.Scroll();

            search.OppenFirstViewAndApplyButton(4);
            Assert.That(search.ReturnResultBody().Contains(keyword.ToLower()));
            //siempre las validaciones en el test case = LISTO
        }

        // Test #2:  search validations FALLAN
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

            Assert.That(search.GetResultsText(), Is.All.Contains(keyword.ToLower()),
                $"All the results does not contain the keyword: {keyword}");
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
            string filePath = Path.Combine(FileHelpers.DownloadPath, expectedFileName);
            bool fileExists = FileHelpers.WaitForFileToBeDownloaded(filePath, 15);
            Assert.That(fileExists, Is.True, $"File '{expectedFileName}' was not downloaded.");
        }



        //este metodo de wait debria de ir en en otra clase llamada utils y jalarlo aca, tambien se puede meter alla el file path= LISTO
        //for = si no ha terminado de descargarse el archivo espera medio segundo hasta / es un * 2 por que espera medio segundo entonces espera un segundo
        //completo, buscar otros metodos de espera (librerias) este funciona pero esta muy piedra
        //basepage para todos los metodos que se comparten entre paginas, clicks, waits, inputs, etc todo para no crear siempre los metodos en cada object
    

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
