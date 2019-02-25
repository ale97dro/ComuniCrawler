using KokeScraper.src;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KokeScraper
{
    /// <summary>
    /// This class check only the rightness of the input parameters and then call the real scraping tool.
    /// Then, print or save the result
    /// </summary>
    class Program
    {
        //TODO LIST
        // 1) print on .txt file the result
        // 2) print on .xml file the result

        static void Main(string[] args)
        {
            Console.WriteLine("Koke - Scraping software by Alessandro Bianchi");
            Console.WriteLine("Retrieve from www.comuni-italiani.it informations about province' cities\n");
            

            Scraper scrape = Scraper.CreateScraper();

            //dynamic result;
            //if (args.Length == 1)
            //{
            //    result = scrape.scrape(args[0]);
            //    result.Wait(); //wait for the result
            //}
            //else
            //{
            //    result = scrape.scrape(args);
            //    result.Wait(); //wait for the result
            //}


            dynamic result = scrape.scrape(args.Where(val => !val.Equals("-txt") && !val.Equals("-xml")).ToArray());
            result.Wait();
           

            switch(args[args.Length-1])
            {
                case "-txt":
                    new TextWriter().Write(result.Result);
                    break;
                case "-xml":
                    //xml
                    new XmlWriter().Write(result.Result);
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
