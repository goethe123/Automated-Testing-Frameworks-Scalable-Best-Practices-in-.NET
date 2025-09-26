using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCase1Epam.Busisness.Pages;

namespace TestCase1Epam.Business.Pages
{
    public partial class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public IEnumerable<string> GetResultsText()
        {
            WaitAndFind(ResultsList);
            var links = Driver.FindElements(ResultListElementLink);
            return links.Select(l => l.Text.ToLower());
        }

        public string ReturnResultBody()
        {
            return Driver.FindElement(ResultElementBody).Text.ToLower();
        }

        public void OppenFirstViewAndApplyButton(int index)
        {
            Click(ApplyButtonByIndex(index));
        }
    }
}