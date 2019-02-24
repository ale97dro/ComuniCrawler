using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComuniCrawler
{
    /// <summary>
    /// This class check only the rightness of the input parameters and then call the real crawler.
    /// Finally, wait for the user next decision
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "http://www.comuni-italiani.it/012/lista.html";


            Console.WriteLine("ComuniCrawler By Alessandro Bianchi ");

            if ((args.Length == 1) || (args[1].Equals("-c")))
            {
                Crawler.crawl(args[0]);
            }
            else
            {
                if ((args.Length == 2) && (args[1].Equals("-f")))
                {
                    Crawler.crawl(args[0]);
                    Console.WriteLine("File");
                }
            }

            

            //List<HtmlNode> list = new List<HtmlNode>();
            //Internet.IndexAsync(args[0], list);

            //foreach (var x in list)
            //    Console.WriteLine(x);

            Console.ReadKey();
        }
    }
}
