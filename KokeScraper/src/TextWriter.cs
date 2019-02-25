using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;

namespace KokeScraper.src
{
    class TextWriter : FileWriter
    {
        public void Write(List<List<HtmlNode>> list, string[] paths)
        {
            if (list.Count != paths.Length)
                throw new WritingException("Nodes number and paths number are different!");

            for(int i = 0; i<paths.Length;i++)
            {
                StreamWriter writer = new StreamWriter(paths[i] + ".txt", false, Encoding.Unicode);

                foreach(HtmlNode n in list[i])
                    writer.WriteLine(n.InnerHtml);
                writer.Close();
            }

            Console.WriteLine("Printed TXT");
        }
    }
}
