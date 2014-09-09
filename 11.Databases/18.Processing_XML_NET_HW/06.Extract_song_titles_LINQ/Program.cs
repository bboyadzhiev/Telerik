using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _06.Extract_song_titles_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("../../../catalogue.xml");

            var titles = from song in doc.Descendants("song")
                         select song.Element("title");

            foreach (var item in titles)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
