using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Business.Pages
{
    public partial class InsightsPage
    {
        private readonly By SwipeButton = By.CssSelector("button.slider__right-arrow.slider-navigation-arrow");
        private readonly By CarouselElementTitle = By.XPath("//*[@id=\"main\"]/div[1]/div[1]/div/div[1]/div[1]/div/div[6]/div/div/div/div[1]/div[2]");
        private readonly By ReadMoreButton = By.LinkText("Read More");
        private readonly By ArticleTitle = (By.CssSelector("div.text.section b"));
    }
}
