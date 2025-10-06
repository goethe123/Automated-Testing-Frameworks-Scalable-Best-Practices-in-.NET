using OpenQA.Selenium;

namespace TestCase1Epam.Core.Drivers
{
    public static class WebDriverSingleton
    {
        private static IWebDriver? _instance;
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
           if(_instance != null)
            {
                _instance.Quit();
                _instance.Dispose();
                _instance = null;   
            }
           
            
        }
    }
}

