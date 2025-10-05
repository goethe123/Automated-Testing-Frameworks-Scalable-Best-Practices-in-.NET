using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestCase1Epam.Business.Pages
{
    public partial class ArtificialInteligencePage
    {
       public readonly By ResponsibleAIButton = By.CssSelector("a.button-ui-23[href*='/services/artificial-intelligence/responsible-ai']");
       public readonly By GenerativeAiButton = By.CssSelector("a.button-ui-23[href*='/services/artificial-intelligence/generative-ai']");
       public readonly By ResultingPageTitle = By.CssSelector("span.museo-sans-500.gradient-text");
       public readonly By OurRelatedExpertiseElement = By.XPath("//span[contains(@class,'museo-sans-light') and contains(text(),'Our Related Expertise')]");

    }
}
