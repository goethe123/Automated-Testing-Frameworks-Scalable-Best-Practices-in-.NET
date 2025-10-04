using TestCase1Epam.Core.Config;

namespace TestCase1Epam.Core.Utils
{
    public  class FileHelpers
    {
        public static readonly string DownloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TestSettings.Downloads);

        static FileHelpers()
        {
            Directory.CreateDirectory(DownloadPath);
        }



        public static bool WaitForFileToBeDownloaded(string fileName, int seconds)
        {
            string filePath = Path.Combine(DownloadPath, fileName);
            for (int i = 0; i < seconds * 2; i++)
            {
                if (File.Exists(filePath) && !File.Exists(filePath + ".crdownload"))
                    return true;
                Thread.Sleep(500);
            }
            return false;
        }
    }
}

