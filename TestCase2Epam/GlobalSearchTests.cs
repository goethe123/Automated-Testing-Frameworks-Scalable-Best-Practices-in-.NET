using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace TestCase2Epam
{
    [TestFixture]
    public class GlobalSearchTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        // Usar WebDriverManager para descargar el ChromeDriver correcto
        new WebDriverManager.DriverManager().SetUpDriver(
            new WebDriverManager.DriverConfigs.Impl.ChromeConfig()
        );

        driver = new ChromeDriver(options);

        // Implicit wait
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
        {
            PollingInterval = TimeSpan.FromMilliseconds(250),
            Message = "Elemento no apareció a tiempo."
        };
    }

        [TearDown]
        public void Teardown()
        {
            try { driver.Quit(); } catch { }
            driver?.Dispose(); 
        }

        [TestCase("automation")]
        [TestCase("blockchain")]
        [TestCase("cloud")]
        public void Validate_Global_Search_Returns_Correct_Results(string keyword)
        {
            driver.Navigate().GoToUrl("https://www.epam.com");

            // aceptar cookies si aparecen
            try
            {
                var cookieBtn = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                    .Until(ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("#onetrust-accept-btn-handler, .onetrust-accept-btn-handler")));
                cookieBtn.Click();
            }
            catch { }

            // abrir buscador
            var searchIcon = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector(".header-search__button.header__icon")));
            searchIcon.Click();

            // input búsqueda
            var searchInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("q")));
            searchInput.Clear();
            searchInput.SendKeys(keyword);

            // botón Find
            var findButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("button.custom-search-button")));
            findButton.Click();

            // esperar resultados
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".search-results__items")));

            var resultLinks = driver.FindElements(By.CssSelector(".search-results__item a"));

            // validar con LINQ
            bool allContainKeyword = resultLinks
                .Select(link => link.Text.ToLower())
                .All(text => text.Contains(keyword.ToLower()));

            Assert.That(allContainKeyword, Is.True,
                $"Algunos resultados NO contienen la palabra '{keyword}'.\n" +
                string.Join("\n", resultLinks.Select(l => l.Text)));
        }
    }
}
