using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Pages
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
        

       
        protected void Click(By locator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }
       



        //para todas las clases dependeran de base page, metodos que compartiran siempre se declaran aqui, solo los hijos acceden a ella
    }
}
