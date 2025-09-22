using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCase1Epam.Pages;


namespace TestCase1Epam.Pages
{
    public partial class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public IEnumerable<string> GetResultsText()
        {
            WaitAndFind(ResultsList);
            var links = Driver.FindElements(ResultListElementLink);
            return links.Select(l => l.Text.ToLower());
        }

        /* public bool ResultsContainKeyword()
    {
        WaitAndFind(ResultsList);
        var links = Driver.FindElements(ResultListElementLink);
        return links.All(l => l.Text.ToLower());*/


        //todos los asserts siempre meterlos en el test directamente, no te lo lleves a pages == listo
        //las pages son para delimitar locators de cada pagina y las acciones de cada pagina 


        //public bool DescriptionContainsKeyword(string keyword)
        //{
        //    var body = Driver.FindElement(By.TagName("body")).Text;
        //    return body.ToLower().Contains(keyword.ToLower());

        //}
        public string ReturnResultBody()
        {
            return Driver.FindElement(ResultElementBody).Text.ToLower();
        }

        public void OppenFirstViewAndApplyButton(int indice)
        {

            Click(By.XPath($"(//a[contains(@class,'search-result__item-apply-23')])[{indice}]"));
            //open apply link y pasar por parametro el indice, 
        }
    }
}