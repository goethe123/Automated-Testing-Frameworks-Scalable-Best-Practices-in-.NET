using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Busisness.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;
        protected Actions Actions => new Actions(Driver);


        protected BasePage(IWebDriver driver, WebDriverWait wait)
        {
            Driver = driver;
            Wait = wait;
        }
        

        protected IWebElement WaitAndFind(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitToClickable(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected IWebElement WaitToExist(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementExists(locator));
        }
        protected void Click(By locator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }
       



        //para todas las clases dependeran de base page, metodos que compartiran siempre se declaran aqui, solo los hijos acceden a ella
    }
}
