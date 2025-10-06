using log4net;
using OpenQA.Selenium;
using TestCase1Epam.Business.Pages;
using TestCase1Epam.Core.Hooks;

namespace TestCase1Epam.Tests
{
    [TestFixture]
    public class GlobalSearchTests : BaseTest
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        // Test #1: 
        [TestCase("java")]
        [TestCase("python")]
        public void ValidateUserCanSearchPosition(string keyword)
        {
            Log.Info($"1st Test, ValidateUserCanSearchPosition with {keyword} keyword");
            var home = new HomePage(Driver);
            var careers = new CareersPage(Driver);
            var search = new SearchPage(Driver);

            Driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.GoToCareers();
            careers.SearchJob(keyword);
            search.OppenFirstViewAndApplyButton(4);

            Assert.That(search.ReturnResultBody().Contains(keyword.ToLower()));
            Log.Info($"[PASS] ValidateUserCanSearchPosition passed correctly with the {keyword} keyword");
        }

        // Test #2:  search validations FALLAN
        [TestCase("automation")]
        [TestCase("blockchain")]
        [TestCase("cloud")]
        public void Validate_Global_Search_Returns_Correct_Results(string keyword)
        {
            Log.Info($"2nd Test, Validate_Global_Search_Returns_Correct_Results with {keyword} keyword");

            var home = new HomePage(Driver);
            var search = new SearchPage(Driver);

            Driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.OpenSearch();
            home.Search(keyword);
            Assert.That(search.GetResultsText(), Is.All.Contains(keyword.ToLower()),
            $"All the results does not contain the keyword: {keyword}");
            Log.Info("[PASS] Validate_Global_Search_Returns_Correct_Results passed correctly");
        }

        //  Test #3: File download Validation
        [TestCase("EPAM_Corporate_Overview_Sept_25.pdf")]
        public void Validate_File_Download(string expectedFileName)
        {
            var home = new HomePage(Driver);
            var about = new AboutPage(Driver);

            Driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.GoToAbout();
            about.ClickDownloadButton();
            bool fileExists = Core.Utils.FileHelpers.WaitForFileToBeDownloaded(expectedFileName, 15);
            Assert.That(fileExists, Is.True, $"File '{expectedFileName}' was not downloaded.");
            Log.Info("[PASS]  Validate_File_Download passed correctly");
        }

        //TestCase 4
        [Test]
        public void ValidateCarouselTitle()
        {
            var home = new HomePage(Driver);
            var insights = new InsightsPage(Driver);

            Driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.GoToInsights();
            insights.ClickSwipeButton();
            string CarouselTitle = insights.TakeCarouselElementTitle();
            insights.ClickReadMoreButton();
            string ArticleTitle = insights.TakeArticleTitle();
            Assert.That(ArticleTitle, Is.EqualTo(CarouselTitle), $" The Article's Title ('{ArticleTitle}') does not match with the Carousel's title ('{CarouselTitle}').");
            Log.Info("[PASS]  ValidateCarouselTitle passed correctly");
        }

        //testcase 5  locators verification

        
        [TestCase("Responsible AI")]
        [TestCase("Generative AI")]

        public void LocatorsVerification(string serviceName)
        {
            var home = new HomePage(Driver);
            var services = new ServicesPage(Driver);
            var AI = new ArtificialInteligencePage(Driver);
            
            Driver.Navigate().GoToUrl("https://www.epam.com/");
            home.AcceptCookiesIfPresent();
            home.GoToServices();
            services.GoToArtificialInteligence();
            By serviceButton = serviceName switch
             {
               "Responsible AI" => AI.ResponsibleAIButton,
               "Generative AI" => AI.GenerativeAiButton,
             };

            string buttonText = AI.ClickServiceButtonAndGetText(serviceButton);
            string pageTitle = AI.GetPageTitle();
            Assert.That(pageTitle, Is.EqualTo(buttonText),$"Expected page title '{pageTitle}' to match clicked button '{buttonText}'");
            bool OurExperience = AI.OurRelatedExperticeValidation();
            Assert.That(OurExperience, Is.True);
            Log.Info("[PASS]  ValidateCarouselTitle passed correctly");
        

        }
        
    }
}
