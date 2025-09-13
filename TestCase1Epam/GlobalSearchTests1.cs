using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace TestCase1Epam
{
    [TestFixture]
    public class GlobalSearchTests1
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        [TestCase("java")]
        [TestCase("python")]
        public void ValidateUserCanSearchPosition(string keyword)
        {
            // 1. Navegar a la página principal
            driver.Navigate().GoToUrl("https://www.epam.com/");

            // 2. Aceptar cookies si aparece el botón
           
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                    .Until(ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("#onetrust-accept-btn-handler, .onetrust-accept-btn-handler"))).Click();
                
            }
            catch (Exception ex)
            {
                TestContext.Out.WriteLine("Cookie acceptance button not found or not clickable: ");
                TestContext.Out.WriteLine(ex.Message);
            }

            // 3. Click en el Careers button
            wait.Until(driver => driver.FindElement(By.LinkText("Careers"))).Click();
            

            // 4. Meter los inputs de los lenguajes
            var keywordInput = wait.Until(driver => driver.FindElement(By.Id("new_form_job_search-keyword")));
            keywordInput.Clear();
            keywordInput.SendKeys(keyword);

            // 5. Seleccionar "All Locations"
             wait.Until(d => d.FindElement(By.ClassName("select2-selection__rendered"))).Click();
           

             wait.Until(drive => drive.FindElement(By.CssSelector("li[title='All Locations']"))).Click();
           

            // 6. Seleccionar "Remote"
             wait.Until(d => d.FindElement(By.XPath("//label[contains(@class,'checkbox-custom-label') and contains(.,'Remote')]"))).Click();


            // 7. Click en el Find btn
           wait.Until(d => d.FindElement(By.CssSelector("button.job-search-button-transparent-23"))).Click();
            

            // 8. Encontrar el listado de resultados
           
            wait.Until(d => d.FindElements(By.CssSelector("li.search-result__item")).Count > 0);

            // encontrar job cards y verificar que si haya
            var jobCards = driver.FindElements(By.CssSelector("li.search-result__item"));
            ClassicAssert.IsTrue(jobCards.Count > 0, "No job listings found.");

            // Tomar el primer job card lo cual creo que no sirve de mucho
            var latestJob = jobCards[0];

            // Buscar el btn o link de Apply dentro del primer job
            // Esperar hasta que al menos un "View and apply" href esté disponible
            wait.Until(d => d.FindElements(By.CssSelector("a.search-result__item-apply-23")).Count > 0);

          wait.Until(d => d.FindElement(By.XPath("(//a[contains(@class,'search-result__item-apply-23')])[1]"))).Click();
           

            //paso 9 ya ver si esta la keyword en la pagina minimo una vez
            var bodyText = driver.FindElement(By.TagName("body")).Text;

            Assert.That(bodyText.ToLower(), Does.Contain(keyword.ToLower()),
                $"Expected keyword '{keyword}' not found in job description.");

        }

        [TearDown]
        public void TearDown()
        {
            driver?.Dispose();
            driver?.Quit();
        }

    }
}

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
                Message = "Element did not appeared"
            };
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
            catch (Exception ex)
            {
                TestContext.Out.WriteLine("Cookie acceptance button not found or not clickable: ");
                TestContext.Out.WriteLine(ex.Message);
            }

            // abrir buscador
           wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector(".header-search__button.header__icon"))).Click();
            

            // input búsqueda
            var searchInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("q")));
            searchInput.Clear();
            searchInput.SendKeys(keyword);

            // botón Find
             wait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("button.custom-search-button"))).Click();
           

            // esperar resultados
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".search-results__items")));

            var resultLinks = driver.FindElements(By.CssSelector(".search-results__item a"));

            // validar con LINQ
            bool allContainKeyword = resultLinks
                .Select(link => link.Text.ToLower())
                .All(text => text.Contains(keyword.ToLower()));

            Assert.That(allContainKeyword, Is.True,
                $"some results does not contain the '{keyword} keyword on its title'.\n" +
                string.Join("\n", resultLinks.Select(l => l.Text)));
        }

        //tear down
        [TearDown]
        public void Teardown()
        {
            try { driver.Quit(); } catch { }
            driver?.Dispose();
        }
    }
}

