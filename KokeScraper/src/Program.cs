using KokeScraper.src;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine("Retrieve informations about cities and locations\n");
            
            Scraper scrape = Scraper.CreateScraper();

            //Read the type of link you have to scrape. The mode is passed as argument
            //Then set the argument to -1
            string mode = args[args.Length - 1];
            args[args.Length - 1] = "-1";

            string[] paths = args.Where(val => !val.Equals("-txt") && !val.Equals("-xml") && !val.Equals("-1")).ToArray(); //extract the web urls

           
            dynamic result;
            
            //Change the right scraping method according to the mode
            switch (mode)
            {
                case "0":
                    result = scrape.ScrapeComuniItaliani(paths, "ISO-8859-1");
                    break;
                case "1":
                    result = scrape.ScrapeComuniTicino(paths, "UTF-8");
                    break;
                default:
                    Console.WriteLine("Error! Wrong mode");
                    throw new Exception("Error! Wrong mode!");
            }

            result.Wait(); //wait for the scraping

            paths = PreparePaths(paths); //parse the web urls into filename

            switch (args[args.Length - 2]) //if you add more input parameters, remember to change the index
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
