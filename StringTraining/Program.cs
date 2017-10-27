using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace StringTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            exercise2();
        }

        static void exercise1()
        {
            foreach (var line in FixedWidth.GetFormattedTable())
            {
                Console.WriteLine(line);
            }
        }

        static void exercise2()
        {
            var client = new WebClient { Encoding = Encoding.UTF8 };
            var htmlText = client.DownloadString("https://en.wikipedia.org/wiki/Unicode");

            File.WriteAllText("Unicode.1.html", htmlText, Encoding.Unicode);

            var fileBytes = File.ReadAllBytes("Unicode.1.html");
            var shorterFileBytes = new byte[fileBytes.Length - 2];
            Array.Copy(fileBytes, 2, shorterFileBytes, 0, shorterFileBytes.Length);
            File.WriteAllBytes("Unicode.2.html", shorterFileBytes);

            var finalText = File.ReadAllText("Unicode.2.html", Encoding.UTF8);
            File.WriteAllText("Unicode.3.html", finalText, Encoding.Unicode);
        }
    }
}
