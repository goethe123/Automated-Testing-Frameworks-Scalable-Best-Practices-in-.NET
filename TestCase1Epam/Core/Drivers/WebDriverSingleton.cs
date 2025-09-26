using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Core.Drivers
{
    public static class WebDriverSingleton
    {
        private static IWebDriver _instance;
        private static readonly object _lock = new();

        public static IWebDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = BrowserFactory.Create();
                        }
                    }
                }
                return _instance;
            }
        }
        public static void Quit()
        {
            _instance.Quit();
            _instance?.Dispose();
            _instance = null;
        }
    }
}

