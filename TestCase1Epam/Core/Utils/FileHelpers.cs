using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Core.Utils
{
    public  class FileHelpers
    {
        public static readonly string DownloadPath = @"C:\Users\GoetheRamirez\Downloads";

        public static bool WaitForFileToBeDownloaded(string filePath, int seconds)
        {
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

