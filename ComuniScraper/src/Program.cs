using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComuniScraper
{
    /// <summary>
    /// This class check only the rightness of the input parameters and then call the real crawler.
    /// Finally, wait for the user next decision
    /// </summary>
    class Program
    {
        //TODO LIST
        // 1) print on .txt file the result
        // 2) print on .xml file the result

        static void Main(string[] args)
        {
            Console.WriteLine("Koke - Scraping software by Alessandro Bianchi");

            Scraper scrape = Scraper.CreateScraper();

            dynamic result;

            if (args.Length == 1)
            {
                result = scrape.scrape(args[0]);
                result.Wait(); //wait for the result
            }
            else
            {
                result = scrape.scrape(args);
                result.Wait(); //wait for the result
            }

            if(args[args.Length-1].Equals("-txt"))
            {

            }
            else
            {
                if(args[args.Length-1].Equals("-xml"))
                {

                }
            }

            switch(args[args.Length-1])
            {
                case "-txt":
                    //txt
                    break;
                case "-xml":
                    //xml
                    break;
                default:
                    PrintResult(result);
                    break; 
            }

            Console.ReadKey();
        }

        static void PrintResult(Task<List<HtmlNode>> list)
        {
            foreach (HtmlNode x in list.Result)
                Console.WriteLine(x.InnerHtml);
        }

        static void PrintResult(Task<List<List<HtmlNode>>> list)
        {
            foreach(List<HtmlNode> l in list.Result)
                foreach (HtmlNode x in l)
                    Console.WriteLine(x.InnerHtml);
        }
    }
}
