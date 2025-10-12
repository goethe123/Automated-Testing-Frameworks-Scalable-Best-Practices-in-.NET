using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestCase1Epam.Core.Utils;

namespace TestCase1Epam.Business.Pages
{
    public partial class ArtificialInteligencePage : WebDriverHelper
    {
        public ArtificialInteligencePage(IWebDriver driver) : base(driver) { }

        public string ClickServiceButtonAndGetText(By locator)
        {
            var element = WaitAndFind(locator);
            string elementText = element.Text.Trim().ToLower();
            element.Click();
            return elementText;
        }

        public string GetPageTitle()
        {
            var titleElement = WaitAndFind(ResultingPageTitle);
            return titleElement.Text.Trim().ToLower();
        }
        public bool OurRelatedExperticeValidation()
        {
            var OURESection = WaitAndFind(OurRelatedExpertiseElement);
            if (OURESection == null)
            {
                return false;
            }
            else 
            { return true; }
        }

    }
}
