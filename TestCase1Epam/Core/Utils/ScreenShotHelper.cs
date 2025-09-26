using OpenQA.Selenium;
using System;
using System.IO;

namespace TestCase1Epam.Core.Utils
{
    public static class ScreenshotHelper
    {
        public static string TakeScreenshot(IWebDriver driver, string testName)
        {
            var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Artifacts", "Screenshots");
            Directory.CreateDirectory(dir);
            var fullPath = Path.Combine(dir, fileName);
            var ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
            return fullPath;
        }
    }
}