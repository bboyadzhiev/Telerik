namespace _03.Extract_artists_using_XPath
{
    using System;
    using System.Collections;
    using System.Xml;

    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalogue.xml");
            string xPathQuery = "/catalogue/album";

            Hashtable albumsCount = new Hashtable();

            XmlNodeList catalogueNodeList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode album in catalogueNodeList)
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