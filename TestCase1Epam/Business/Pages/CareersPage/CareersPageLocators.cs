using OpenQA.Selenium;

namespace TestCase1Epam.Business.Pages
{
    public partial class CareersPage
    {
        private readonly By JobSearchKeyword = By.Id("new_form_job_search-keyword");
        private readonly By LocationsList = By.ClassName("select2-selection__rendered");
        private readonly By PickAllLocations = By.CssSelector("li[title='All Locations']");
        // private readonly By RemoteCheckbox = By.XPath("//label[contains(@class,'checkbox-custom-label') and contains(.,'Remote')]");
        private readonly By RemoteCheckbox = By.CssSelector("label[for='id-93414a92-598f-316d-b965-9eb0dfefa42d-remote']");
        private readonly By FindButton = By.CssSelector("button.job-search-button-transparent-23");
    }
}
