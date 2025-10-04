using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TestCase1Epam.Core.Config;
using TestCase1Epam.Core.Utils;

namespace TestCase1Epam.Core.Drivers
{
    public static class BrowserFactory
    {
        public static IWebDriver Create()
        {
            
             switch (TestSettings.Browser.ToLower())
            {
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--width=1920");
                    firefoxOptions.AddArgument("--height=1080");
                    firefoxOptions.SetPreference("browser.download.folderList", 2);
                    firefoxOptions.SetPreference("browser.download.dir", TestSettings.Downloads);
                    firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf,application/octet-stream");
                    return new FirefoxDriver(firefoxOptions);
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    edgeOptions.AddUserProfilePreference("download.default_directory", TestSettings.Downloads);
                    edgeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    edgeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                    return new EdgeDriver(edgeOptions);
                default: // Chrome
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddUserProfilePreference("download.default_directory", FileHelpers.DownloadPath);
                    options.AddUserProfilePreference("download.prompt_for_download", false);
                    options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                    return new ChromeDriver(options);
            }
        }
    }
}

