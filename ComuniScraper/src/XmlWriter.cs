using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ComuniScraper.src
{
    class XmlWriter : FileWriter
    {
        //public void Write(List<HtmlNode> list)
        //{
        //    throw new NotImplementedException();
        //}

        public void Write(List<List<HtmlNode>> list)
        {
            Console.WriteLine("Printed XML");
        }
    }
}
