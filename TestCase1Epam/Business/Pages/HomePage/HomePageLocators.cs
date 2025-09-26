using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
