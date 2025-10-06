using Reqnroll;
using NUnit.Framework;
using TestCase1Epam.Business.Pages;
using TestCase1Epam.Core.Hooks;
using OpenQA.Selenium;

namespace TestCase1Epam.Tests.StepDefinitions
{
    [Binding]
    public class GlobalSearchSteps : BaseScenario
    {
        private HomePage _home;
        private CareersPage _careers;
        private SearchPage _search;

        public GlobalSearchSteps (ScenarioContext context) : base(context) 
        {
            Driver = context["Driver"] as IWebDriver;
        } 

        [Given(@"I navigate to the EPAM website")]
        public void GivenINavigateToTheEPAMWebsite()
        {
            Console.WriteLine("driver navegando a epam.com");
            Driver.Navigate().GoToUrl("https://www.epam.com/");
            _home = new HomePage(Driver);
            _careers = new CareersPage(Driver);
            _search = new SearchPage(Driver);
        }

        [Given(@"I accept cookies if present")]
        public void GivenIAcceptCookiesIfPresent()
        {
            _home.AcceptCookiesIfPresent();
        }

        [When(@"I navigate to the Careers section")]
        public void WhenINavigateToTheCareersSection()
        {
            _home.GoToCareers();
        }
        
        [When("I search for the {string} position")]
        public void WhenISearchForThePosition(string java)
        {
            _careers.SearchJob(java);
        }

        [When("I open the first View And Apply Button")]
        public void WhenIAcceptCookiesIfPresent()
        {
            _search.OppenFirstViewAndApplyButton(4);
        }

        [Then("the search Results should contain {string}")]
        public void ThenTheSearchResultsShouldContain(string java)
        {
            Assert.That(_search.ReturnResultBody().Contains(java.ToLower()));
        }

    }

}
