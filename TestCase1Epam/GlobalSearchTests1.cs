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

        [TearDown]
        public void TearDown()
        {
            driver?.Dispose();
        }

        //[TestCase("java")]
        [TestCase("python")]
        public void ValidateUserCanSearchPosition(string keyword)
        {
            // 1. Navegar a la página principal
            driver.Navigate().GoToUrl("https://www.epam.com/");

            // 2. Aceptar cookies si aparece el botón
           
            try
            {
                var cookieBtn = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                    .Until(ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("#onetrust-accept-btn-handler, .onetrust-accept-btn-handler")));
                cookieBtn.Click();
            }
            catch { }

            // 3. Click en el Careers button
            var careersLink = wait.Until(driver => driver.FindElement(By.LinkText("Careers")));
            careersLink.Click();

            // 4. Meter los inputs de los lenguajes
            var keywordInput = wait.Until(driver => driver.FindElement(By.Id("new_form_job_search-keyword")));
            keywordInput.Clear();
            keywordInput.SendKeys(keyword);

            // 5. Seleccionar "All Locations"
            var locationDropDown = wait.Until(d => d.FindElement(By.ClassName("select2-selection__rendered")));
            locationDropDown.Click();

            var allLocationsOption = wait.Until(drive => drive.FindElement(By.CssSelector("li[title='All Locations']")));
            allLocationsOption.Click();

            // 6. Seleccionar "Remote"
            var remoteChecBox = wait.Until(d => d.FindElement(By.XPath("//label[contains(@class,'checkbox-custom-label') and contains(.,'Remote')]")));

            remoteChecBox.Click();

            // 7. Click en el Find btn
            var findButton = wait.Until(d => d.FindElement(By.CssSelector("button.job-search-button-transparent-23")));
            findButton.Click();

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

            var firstApplyButton = wait.Until(d => d.FindElement(By.XPath("(//a[contains(@class,'search-result__item-apply-23')])[1]")));
            firstApplyButton.Click();

            //paso 9 ya ver si esta la keyword en la pagina minimo una vez
            var bodyText = driver.FindElement(By.TagName("body")).Text;

            if (bodyText.ToLower().Contains(keyword.ToLower()))
            {
                Console.WriteLine($" LA KEYWORD '{keyword}' SÍ SE ENCONTRÓ.");
            }
            else
            {
                Console.WriteLine($" La keyword '{keyword}' NO se encontró en la página.");
            }

           
            Assert.That(bodyText.ToLower(), Does.Contain(keyword.ToLower()),
                $"Expected keyword '{keyword}' not found in job description.");




        }
    }
}
