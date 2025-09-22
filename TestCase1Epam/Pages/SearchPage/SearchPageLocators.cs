using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Pages
{
    public partial class SearchPage
    {

        private readonly By ResultsList = By.CssSelector(".search-results__items");
        private readonly By ResultListElementLink = By.CssSelector(".search-results__item a");
        private readonly By ResultElementBody = By.TagName("body");

    }
}
