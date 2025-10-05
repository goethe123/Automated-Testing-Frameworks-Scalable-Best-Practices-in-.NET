using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestCase1Epam.Business.Pages
{
    public partial class ServicesPage
    {
        private readonly By AiButton = By.CssSelector("a.button-ui-23[href*='/services/artificial-intelligence']");
    }
}
