using System.Configuration;

namespace TestCase1Epam.Core.Config
{
    public static class TestSettings
    {
        public static string Browser => Get("browser", "chrome");
        public static int ExplicitWait => int.Parse(Get("explicitWaitSec", "10"));
        public static string Downloads => Get("Downloads", @"Artifacts\ProjectDownloads");

        public static string Get (string key, string defaultValue) =>
            ConfigurationManager.AppSettings[key] ?? defaultValue;
    }
}
