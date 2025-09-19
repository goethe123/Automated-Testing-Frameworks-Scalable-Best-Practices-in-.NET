using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Pages
{
    internal class InsightsPage : BasePage

    {
        public InsightsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {}

        public void GoToInsights()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[3]/span[1]/a"))).Click();
            //ya no traerse xpath completisimo
        }

        public void ClickSwipeButton()
        {
            for (int i = 0; i < 2; i++)
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"main\"]/div[1]/div[1]/div/div[2]/button[2]"))).Click();
                Thread.Sleep(1000);
                //nunca usar thread.sleep(puede saltarse el elemento esperado) espera innecesaria
            }
        }

        public void ClickReadMoreButton()
        {
             Wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"main\"]/div[1]/div[1]/div/div[1]/div[1]/div/div[6]/div/div/div/div[2]/a"))).Click();
        }

        public string FindArticleTitle()
        {
           
           return WaitAndFind(By.XPath("//*[@id=\"main\"]/div[1]/div[1]/div/div[1]/div[1]/div/div[6]/div/div/div/div[1]/div[2]")).Text.Trim(); ;
            
        }

        public string TakeNewTitle()
        {
          
                return  WaitAndFind(By.CssSelector("div.text.section b")).Text.Trim(); 
            
        }
    }
}
