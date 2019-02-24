using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComuniCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "http://www.comuni-italiani.it/012/lista.html";

            Internet.IndexAsync(path);

            Console.ReadKey();
        }
    }
}
