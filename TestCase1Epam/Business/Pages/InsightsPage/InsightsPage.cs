using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase1Epam.Busisness.Pages;

namespace TestCase1Epam.Business.Pages
{
    public partial class InsightsPage : BasePage

    {
        public InsightsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {}      
        public void ClickSwipeButton()
        {
            for (int i = 0; i < 2; i++)
            {
                Click(SwipeButton);
            }
        }

        public void ClickReadMoreButton()
        {
           Click(ReadMoreButton);
        }

        public string TakeCarouselElementTitle()
        {  
           return WaitAndFind(CarouselElementTitle).Text.Trim(); 
        }

        public string TakeArticleTitle()
        {
                return WaitAndFind(ArticleTitle).Text.Trim();            
        }
    }
}
