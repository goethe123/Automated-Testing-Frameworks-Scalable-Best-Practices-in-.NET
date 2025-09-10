using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

class EpamSearchEnter
{
    static void Main()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        IWebDriver driver = new ChromeDriver(options);
        try
        {
            driver.Navigate().GoToUrl("https://www.epam.com");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250),
                Message = "Algún elemento no apareció a tiempo."
            };

            // (Opcional) aceptar cookies si tapa la UI
            try
            {
                var cookieBtn = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                    .Until(ExpectedConditions.ElementToBeClickable(
                        By.CssSelector("#onetrust-accept-btn-handler, .onetrust-accept-btn-handler")));
                cookieBtn.Click();
            }
            catch { /* no hay banner */ }

            // Abrir el buscador
            var searchIcon = wait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector(".header-search__button.header__icon")));
            searchIcon.Click();

            // Esperar panel + input
            wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector(".header-search__panel")));

            var searchInput = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.Name("q")));

            // Escribir y enviar Enter
            searchInput.Clear();
            searchInput.SendKeys("Automation" + Keys.Enter);

            // Confirmar que hay resultados
            wait.Until(d =>
                d.Url.Contains("/search", StringComparison.OrdinalIgnoreCase) ||
                d.FindElements(By.CssSelector("[class*='search-results']")).Count > 0
            );

            // (Opcional) pequeña espera visual antes de cerrar
            System.Threading.Thread.Sleep(1500);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ ERROR: {ex.Message}");
        }
        finally
        {
            try { driver.Quit(); }
            catch
            {
                try { driver.Close(); } catch { /* ignore */ }
                driver.Dispose();
            }
        }
    }
}
