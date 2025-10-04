using OpenQA.Selenium;
using TestCase1Epam.Core.Utils;

namespace TestCase1Epam.Business.Pages
{
    public partial class SearchPage : WebDriverHelper
    {
        public SearchPage(IWebDriver driver) : base(driver) { }

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