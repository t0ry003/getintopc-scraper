using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome message output
            string welcome_msg = "getintopc.com - webscrapper";
            Console.SetCursorPosition((Console.WindowWidth - welcome_msg.Length) / 2, Console.CursorTop);
            Console.WriteLine(welcome_msg);

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument pages = web.Load("https://getintopc.com/");
            var page_nr = pages.DocumentNode.SelectSingleNode("//a[@class='last']");

            int Pnum = 0;
            Int32.TryParse(page_nr.InnerText, out Pnum);

            // Pages Message Output
            string number_of_pages = "Number of pages: " + Pnum;
            Console.SetCursorPosition((Console.WindowWidth - number_of_pages.Length) / 2, Console.CursorTop);
            Console.WriteLine(number_of_pages);



            for (int page = 1; page <= Pnum; page++)
            {
                Console.WriteLine("Page: " + page);

                HtmlAgilityPack.HtmlDocument doc = web.Load("https://getintopc.com/page/" + page + "/");

                foreach (var software in doc.DocumentNode.SelectNodes("//h2[@class='title']"))
                {
                    if (software != null)
                        Console.WriteLine(software.InnerText.Replace("Free Download", " ").Replace("&#8211", " "));
                }

                Console.WriteLine("\n");
            }
        }
    }
}