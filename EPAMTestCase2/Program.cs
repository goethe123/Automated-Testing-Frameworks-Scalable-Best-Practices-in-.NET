using System;
using System.Linq; 
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

class EpamSearchTest
{
    static void Main(string[] args)
    {
        
        string keyword = "automation";

        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        IWebDriver driver = new ChromeDriver(options);
        try
        {
            driver.Navigate().GoToUrl("https://www.epam.com");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            try
            {
                var cookieBtn = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                    .Until(ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("#onetrust-accept-btn-handler, .onetrust-accept-btn-handler")));
                cookieBtn.Click();
            }
            catch
            {
                
            }

            // 1. Clic en el icono de búsqueda
            var searchIcon = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector(".header-search__button.header__icon")));
            searchIcon.Click();

            // 2. Esperar input y escribir la keyword
            var searchInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("q")));
            searchInput.Clear();
            searchInput.SendKeys(keyword);

            // 3. Clic en el botón "Find"
            var findButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("button.custom-search-button")));
            findButton.Click();

            // 4. Esperar que aparezcan resultados
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".search-results__items")));

            // 5. Obtener todos los links de los resultados
            var resultLinks = driver.FindElements(By.CssSelector(".search-results__item a"));

            // 6. Usar LINQ para validar que todos contienen la palabra clave
            bool allContainKeyword = resultLinks
                .Select(link => link.Text.ToLower())      // tomar el texto en minúsculas
                .All(text => text.Contains(keyword.ToLower())); // validar que todos incluyan el keyword

            if (allContainKeyword)
                Console.WriteLine($"Todos los resultados contienen la palabra '{keyword}'.");
            else
                Console.WriteLine($"Algunos resultados NO contienen la palabra '{keyword}'.");

            System.Threading.Thread.Sleep(1500);
        }
        catch (Exception ex)
        {
            Console.WriteLine($" ERROR: {ex.Message}");
        }
        finally
        {
            driver.Quit();
        }
    }
}
