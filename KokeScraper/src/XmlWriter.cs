using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;

namespace KokeScraper.src
{
    class XmlWriter : FileWriter
    {
        public void Write(List<List<HtmlNode>> list, string[] paths)
        {
            if (list.Count != paths.Length)
                throw new WritingException("Nodes number and paths number are different!");

            for (int i=0;i<paths.Length;i++)
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", System.Text.Encoding.Unicode.WebName, null);
                XmlElement root = doc.CreateElement("NodesList");

                doc.AppendChild(declaration);
                doc.AppendChild(root);


                foreach (HtmlNode n in list[i])
                {
                    XmlElement city = doc.CreateElement("City");
                    city.InnerText = n.InnerHtml;

                    root.AppendChild(city);
                }

                doc.Save(paths[i] + ".xml");
            }

            Console.WriteLine("Printed XML");
        }
    }
}
