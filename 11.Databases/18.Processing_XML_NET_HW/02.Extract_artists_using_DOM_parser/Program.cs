namespace _02.Extract_artists_using_DOM_parser
{
    using System;
    using System.Collections;
    using System.Xml;

    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            Hashtable albumsCount = new Hashtable();

            XmlNode catalogueNode = doc.DocumentElement;
            foreach (XmlNode album in catalogueNode.ChildNodes)
            {
                var artist = album["artist"].InnerText;

                if (albumsCount.ContainsKey(artist))
                {
                    albumsCount[artist] = (int)albumsCount[artist] + 1;
                }
                else
                {
                    albumsCount.Add(artist, 1);
                }
            }

            foreach (DictionaryEntry artist in albumsCount)
            {
                Console.WriteLine("Artist: {0}, songs count: {1}", artist.Key, artist.Value);
            }
        }
    }
}