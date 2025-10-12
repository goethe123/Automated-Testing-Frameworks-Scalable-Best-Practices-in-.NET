using Reqnroll;
using NUnit.Framework;
using TestCase1Epam.Business.Pages;
using TestCase1Epam.Core.Hooks;
using OpenQA.Selenium;

namespace TestCase1Epam.Tests.StepDefinitions
{
    [Binding]
    public class ServicesAISteps : BaseScenario
    {
        private HomePage _home;
        private ServicesPage _services;
        private ArtificialInteligencePage _ai;
        string buttonText;
        string pageTitle;

        protected ServicesAISteps(ScenarioContext context) : base(context)
        {
            Driver = context["Driver"] as IWebDriver;
        }

        [Given(@"I navigate to EPAM website")]
        public void GivenINavigateToTheEPAMWebsite()
        {
            Console.WriteLine("driver navigating to epam.com");
            Driver.Navigate().GoToUrl("https://www.epam.com/");
            _home = new HomePage(Driver);
            _services = new ServicesPage(Driver);
            _ai = new ArtificialInteligencePage(Driver);
        }

        [Given(@"I accept cookies")]
        public void GivenIAcceptCookiesIfPresent()
        {
            _home.AcceptCookiesIfPresent();
        }

        [When(@"I go to the services section")]
        public void WhenIGoToTheServicesSection()
        {
            _home.GoToServices();
        }

        [When(@"I go to the Artificial Inteligence section")]
        public void WhenIGoToTheArtificialInteligenceSection()
        {
            _services.GoToArtificialInteligence();
        }

        [When(@"I click the ""(.*)"" Button")]
        public void WhenIGoToTheKeywordButton(string serviceName)
        {
            By serviceButton = serviceName switch
            {
                "Responsible AI" => _ai.ResponsibleAIButton,
                "Generative AI" => _ai.GenerativeAiButton,
                _=> throw new ArgumentException("invalid service Name")
            };
             buttonText = _ai.ClickServiceButtonAndGetText(serviceButton);
            //manda a metodo esto y solo dale el parametro del button q quieres
        }

        [Then(@"I should see the page title ""(.*)""")]
        public void ThenIShouldSeeThePageTitle(string title)
        {
            pageTitle = _ai.GetPageTitle();
            Assert.That(pageTitle, Is.EqualTo(buttonText), $"Expected page title '{pageTitle}' to match clicked button '{buttonText}'");
        }

        [Then(@"the section ""Our related Expertise"" should be visible in the page")]
        public void ThenTheSectionOurRelatedExpertiseShouldBeVisible()
        {
            bool OurExperience = _ai.OurRelatedExperticeValidation();
            Assert.That(OurExperience, Is.True);
            //meter el resultado del metodo directo en el assert
        }
    }
}
