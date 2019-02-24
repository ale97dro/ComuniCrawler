using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComuniCrawler
{
    /// <summary>
    /// This class is performing the crawling operation
    /// </summary>
    class Crawler
    {
        public static async void crawl(string path)
        {
            var a = await Internet.IndexAsync(path);

            foreach (HtmlNode x in a)
                Console.WriteLine(x.InnerHtml);
        }
    }
}
