using OpenQA.Selenium;
using Reqnroll;
using TestCase1Epam.Core.Drivers;
namespace TestCase1Epam.Core.Hooks

{

    public class BaseScenario
    {
        protected readonly ScenarioContext ScenarioContext;
        protected IWebDriver Driver;

        protected BaseScenario(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        public void InitializeDriver()
        {
            Driver = WebDriverSingleton.Instance;
            ScenarioContext["Driver"] = Driver;
            Console.WriteLine("driver inicializado correctamente");
        }

        public void Cleanup()
        {
            Driver?.Quit();
            WebDriverSingleton.Quit();
            Console.WriteLine("driver cerrado correctamente");
        }

    }

}
