using OpenQA.Selenium;

namespace TestCase1Epam.Business.Pages
{
    public partial class HomePage
    {

        private readonly By CookiesButton = By.CssSelector("#onetrust-accept-btn-handler, .onetrust-accept-btn-handler");
        private readonly By CareersButton = By.LinkText("Careers");
        private readonly By SearchIconButton =  By.CssSelector(".header-search__button.header__icon");
        private readonly By FindButton = By.CssSelector("button.custom-search-button");
        private readonly By AboutButton = By.LinkText("About");
        private readonly By InsightsButton = By.CssSelector("a.top-navigation__item-link[href='/insights']");
        private readonly By SearchInput = By.Id("new_form_search");
        private readonly By ServicesButton = By.LinkText("Services");
        private readonly By ResponsibleAiButton = By.XPath("//*[@id=\"wrapper\"]/div[2]/div[2]/div/div/header/div/div/nav/ul/li[1]/div/div/div[2]/ul[2]/li[3]/ul/li[1]/a");
            //By.XPath("//a[text()='Responsible AI ']");

    }
}
