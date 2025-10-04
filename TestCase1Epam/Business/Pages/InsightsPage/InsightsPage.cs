using OpenQA.Selenium;
using TestCase1Epam.Core.Utils;

namespace TestCase1Epam.Business.Pages
{
    public partial class InsightsPage : WebDriverHelper

    {
        public InsightsPage(IWebDriver driver) : base(driver)
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
