using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCase1Epam.Core.Config;

namespace TestCase1Epam.Core.Utils
{
    public abstract class WebDriverHelper
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;
        protected Actions Actions => new Actions(Driver);


        protected WebDriverHelper(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver,TimeSpan.FromSeconds(TestSettings.ExplicitWait));
        }

        protected WebDriverWait GetWait(int? seconds = null)

        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds ?? TestSettings.ExplicitWait));
        }
        

        protected IWebElement WaitAndFind(By locator, int? seconds = null)
        {
            return GetWait(seconds).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitToClickable(By locator, int? seconds = null)
        {
            return GetWait(seconds).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected IWebElement WaitToExist(By locator, int? seconds = null)
        {
            return GetWait(seconds).Until(ExpectedConditions.ElementExists(locator));
        }
        protected void Click(By locator, int? seconds = null)
        {
            GetWait(seconds).Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }
       
    }
}
