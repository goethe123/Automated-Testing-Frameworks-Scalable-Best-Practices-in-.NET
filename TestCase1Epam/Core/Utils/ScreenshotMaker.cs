using OpenQA.Selenium;
using System.Drawing.Imaging;
namespace TestCase1Epam.Core.Utils

{

    public static class ScreenshotMaker
    {
        private static string NewScreenshotName =>  "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff") + ".png";


        private static string SanitizeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }
            return name;
        }

        public static string TakeBrowserScreenshot(IWebDriver driver, string testName)
        {
            var safeName = SanitizeFileName(testName);
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Artifacts", "Screenshots", "Browser");
            Directory.CreateDirectory(dir);
            var screenshotPath = Path.Combine(dir, safeName + NewScreenshotName);
            var shot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(screenshotPath, shot.AsByteArray);
            return screenshotPath;
        }

        public static string TakeFullDisplayScreenshot(string testName)
        {
            var safeName = SanitizeFileName(testName);
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Artifacts", "Screenshots", "FullScreen");
            Directory.CreateDirectory(dir);
            var screenshotPath = Path.Combine(dir, safeName + NewScreenshotName);
            using (var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))

            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen
                (
                    Screen.PrimaryScreen.Bounds.X,
                    Screen.PrimaryScreen.Bounds.Y,
                    0, 0,
                    bmp.Size,
                    CopyPixelOperation.SourceCopy
                );
                bmp.Save(screenshotPath, ImageFormat.Png);
            }
            return screenshotPath;
        }
    }
}
