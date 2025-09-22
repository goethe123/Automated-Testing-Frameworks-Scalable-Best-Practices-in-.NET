using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Pages
{
    public partial class HomePage
    {

        private readonly By CookiesButton = By.CssSelector("#onetrust-accept-btn-handler, .onetrust-accept-btn-handler");
        private readonly By CareersButton = By.LinkText("Careers");
        private readonly By SearchIconButton =  By.CssSelector(".header-search__button.header__icon");
        private readonly By FindButton = By.CssSelector("button.custom-search-button");
        private readonly By AboutButton = By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[4]/span[1]/a");
        private readonly By InsightsButton = By.XPath("//*[@id=\"wrapper\"]/div[2]/div[1]/header/div/div/nav/ul/li[3]/span[1]/a");

    }
}
