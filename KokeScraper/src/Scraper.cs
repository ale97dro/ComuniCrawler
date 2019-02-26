using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KokeScraper
{
    /// <summary>
    /// This class is performing the scraping operation
    /// </summary>
    class Scraper
    {
        private static Scraper scraper = null;

        private Scraper()
        {

        }

        public static Scraper CreateScraper()
        {
            if (scraper == null)
                scraper = new Scraper();

            return scraper;
        }

        private async Task<HtmlDocument> LoadSource(string website, string encoding)
        {
            HttpClient http = new HttpClient();
            var response = await http.GetByteArrayAsync(website);
            String source = Encoding.GetEncoding(encoding).GetString(response, 0, response.Length - 1); //PAY ATTENTION: if you need to change the source, remember to check the encoding charset (you can find it in the HTML page)
            source = WebUtility.HtmlDecode(source);
            HtmlDocument resultat = new HtmlDocument();
            resultat.LoadHtml(source);

            return resultat;
        }

        //private async Task<List<HtmlNode>> scrape(string website, string encoding)
        //{
        //    HtmlDocument resultat = await LoadSource(website, encoding);

        //    //Look for all the <table> tag in the source
        //    List<HtmlNode> tables = resultat.DocumentNode.Descendants()
        //        .Where(x => (x.Name == "table"))
        //        .ToList();

        //    //tables[3] the one that contains the important information

        //    //var td = tables[3]
        //    //    .Descendants()
        //    //    .Where(x => (x.Name == "td" && x.GetAttributeValue("width", null).Equals("40%")))
        //    //    .ToList();

        //    //a.GetType().GetGenericArguments()[0] //get the generic type of var a

        //    //Look for all the <a> tag in the source (this source was previously filtered)
        //    List<HtmlNode> a = tables[3]
        //        .Descendants()
        //        .Where(x => (x.Name == "a"))
        //        .ToList();

        //    return a;
        //}

        public async Task<List<List<HtmlNode>>> ScrapeComuniItaliani(string[] websites, string encoding)
        {
            List<List<HtmlNode>> results = new List<List<HtmlNode>>();

            foreach (string website in websites)
            {
                // results.Add(await scrape(website, encoding));

                HtmlDocument resultat = await LoadSource(website, encoding);

                //Look for all the <table> tag in the source
                List<HtmlNode> tables = resultat.DocumentNode.Descendants()
                    .Where(x => (x.Name == "table"))
                    .ToList();

                //tables[3] the one that contains the important information

                //var td = tables[3]
                //    .Descendants()
                //    .Where(x => (x.Name == "td" && x.GetAttributeValue("width", null).Equals("40%")))
                //    .ToList();

                //a.GetType().GetGenericArguments()[0] //get the generic type of var a

                //Look for all the <a> tag in the source (this source was previously filtered)
                List<HtmlNode> a = tables[3]
                    .Descendants()
                    .Where(x => (x.Name == "a"))
                    .ToList();

                results.Add(a);
            }

            return results;
        }
    }
}
