using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestCase1Epam.Core.Utils;

namespace TestCase1Epam.Business.Pages
{
    public partial class CareersPage : WebDriverHelper
    {
        public CareersPage(IWebDriver driver) : base(driver) { }

        public void SearchJob(string Keyword)
        {
            Scroll();
            SelectAllLocations();
            SelectRemote();
            SearchJobKeyword(Keyword);
            ClickFindButton();
        }

        public void SearchJobKeyword(string keyword)
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

        public void ClickFindButton()
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
