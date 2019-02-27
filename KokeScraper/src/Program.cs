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
        /// <summary>
        /// ATTENTION: AT THIS MOMENT, DOESN'T EXIST ANY WAY TO CHOOSE THE RIGHT SCRAPING ALGHORITM ACCORDING TO THE INPUT URLS
        /// </summary>
        /// <param name="args">List of urls and (optional) file format in which save results</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Koke - Scraping software by Alessandro Bianchi");
            Console.WriteLine("Retrieve from www.comuni-italiani.it informations about province' cities\n");
            
            Scraper scrape = Scraper.CreateScraper();

            string[] paths = args.Where(val => !val.Equals("-txt") && !val.Equals("-xml")).ToArray();

            dynamic result = scrape.scrapeComuniItaliani(paths, "ISO-8859-1");
            result.Wait();

            paths = PreparePaths(paths);

            switch (args[args.Length - 1])
            {
                case "-txt":
                    new TextWriter().Write(result.Result, paths);
                    break;
                case "-xml":
                    new XmlWriter().Write(result.Result, paths);
                    break;
                default:
                    PrintResult(result);
                    break; 
            }

            //Test for Ticino cities
            //dynamic result_ticino = scrape.scrapeComuniTicino(new string[] { "https://it.wikipedia.org/wiki/Comuni_del_Canton_Ticino" }, "UTF-8");
            //result_ticino.Wait();
            //new XmlWriter().Write(result_ticino.Result, new string[] { "test.xml" });

            Console.WriteLine("Finished");
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

        static string[] PreparePaths(string[] paths)
        {
            string[] newPaths = new string[paths.Length];

            for(int i=0;i<paths.Length;i++)
            {
                StringBuilder builder = new StringBuilder();

                for (int c = 0; c < paths[i].Length; c++)
                    if (Char.IsPunctuation(paths[i][c]))
                        builder.Append("-");
                    else
                        builder.Append(paths[i][c]);

                newPaths[i] = builder.ToString();
            }
           
            return newPaths;
        }
    }
}
