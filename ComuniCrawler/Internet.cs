using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComuniCrawler
{
    class Internet
    {
        //dynamic: return type for var
        public static async Task<dynamic> IndexAsync(string website)
        {
            HttpClient http = new HttpClient();
            var response = await http.GetByteArrayAsync(website);
            String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
            source = WebUtility.HtmlDecode(source);
            HtmlDocument resultat = new HtmlDocument();
            resultat.LoadHtml(source);

            List<HtmlNode> tables = resultat.DocumentNode.Descendants().Where
                (x => (x.Name == "table")
                ).ToList();

            //tables[3] the one that contains the important information

            //var td = tables[3]
            //    .Descendants()
            //    .Where(x => (x.Name == "td" && x.GetAttributeValue("width", null).Equals("40%")))
            //    .ToList();

            //a.GetType().GetGenericArguments()[0] //get the generic type of var a

            var a = tables[3]
                .Descendants()
                .Where(x => (x.Name == "a"))
                .ToList();

            return a;
        }
    }
}
