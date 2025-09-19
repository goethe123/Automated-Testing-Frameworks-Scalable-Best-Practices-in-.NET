using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCase1Epam.Pages;

public class SearchPage : BasePage
{
    public SearchPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

    public bool ResultsContainKeyword(string keyword)
    {
        Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".search-results__items")));
        var links = Driver.FindElements(By.CssSelector(".search-results__item a"));
        return links.All(l => l.Text.ToLower().Contains(keyword.ToLower()));
    }

    public bool DescriptionContainsKeyword(string keyword)
    {
        var body = Driver.FindElement(By.TagName("body")).Text;
        return body.ToLower().Contains(keyword.ToLower());
    }

    public void OpenFirstApplyLink()
    {
        Wait.Until(d => d.FindElements(By.CssSelector("a.search-result__item-apply-23")).Count > 0);
        Click(By.XPath("(//a[contains(@class,'search-result__item-apply-23')])[1]"));
    }
}