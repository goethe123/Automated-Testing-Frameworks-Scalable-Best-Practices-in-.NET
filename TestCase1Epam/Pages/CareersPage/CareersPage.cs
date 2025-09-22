using AngleSharp.Common;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace TestCase1Epam.Pages
{
    public partial class CareersPage : BasePage
    {
        public CareersPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public void SearchJob(string keyword)
        {
            var input = WaitAndFind(JobSearchKeyword);
            input.Clear();
            input.SendKeys(keyword);
        }

        public void SelectAllLocations()
        {
            Click(LocationsList);
            Click(PickAllLocations);
        }

        public void SelectRemote()
        {
            Click(RemoteCheckbox);
        }

        public void ClickFind()
        {
            Click(FindButton);
        }
        

        public void Scroll()
        {          
            var actions = new Actions(Driver);
            actions.ScrollByAmount(0, 820).Perform(); 
        }


        
    }
}
