using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using log4net;
using TestCase1Epam.Core.Config;
using TestCase1Epam.Core.Drivers;
using TestCase1Epam.Core.Utils;

namespace TestCase1Epam.Core.Hooks
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected readonly ILog Log = LogManager.GetLogger(typeof(BaseTest));

        [SetUp]
        public void SetUpBase()
        {
            Driver =  WebDriverSingleton.Instance;
            Wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(TestSettings.ExplicitWait));
            Log.Info("Driver intialized Correctly");
        }

        [TearDown]
        public void TearDownBase()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotPath = ScreenShotHelper.TakeScreenShot(Driver, TestContext.CurrentContext.Test.Name);
                Log.Error($"Test failed, screenshot in {screenshotPath}");
            }
        }
        [OneTimeTearDown]
        public void AfterAll() => WebDriverSingleton.Quit();
    }
}
