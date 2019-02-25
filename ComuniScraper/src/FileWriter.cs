using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComuniScraper.src
{
    interface FileWriter
    {
        void Write(List<HtmlNode> list);
        void Write(List<List<HtmlNode>> list);
    }
}
