using OpenQA.Selenium.BiDi.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TestCase1Epam.Core.Config
{
    public static class TestSettings
    {
        public static string Browser => Get("browser", "chrome");
        public static int ExplicitWait => int.Parse(Get("explicitWaitSec", "10"));
        public static string DownloadDir => Get("DownloadDir", @"C:\Users\GoetheRamirez\Downloads");

        public static string Get (string key, string defaultValue) =>
            ConfigurationManager.AppSettings[key] ?? defaultValue;
 
    }

}
