using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestCase1Epam.Core.Utils;

namespace TestCase1Epam.Business.Pages
{
    public partial class ServicesPage : WebDriverHelper
    {

        public ServicesPage(IWebDriver driver) : base(driver) { }


        public void GoToArtificialInteligence()
        {
            Click(AiButton);
        }

    }
}
