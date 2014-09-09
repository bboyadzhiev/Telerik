namespace _08.Extract_albums_xml
{
    using System.Text;
    using System.Xml;

    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlDocument inputXml = new XmlDocument();
            inputXml.Load("../../../catalogue.xml");

            var outputXMLPath = @"..\..\albums.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            //FileInfo newFile = new FileInfo(filePath);

            XmlNode catalogueNode = inputXml.DocumentElement;

            using (XmlTextWriter writer = new XmlTextWriter(outputXMLPath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                foreach (XmlNode album in catalogueNode)
                {
                    var albumTitle = album["name"].InnerText;
                    var artistName = album["artist"].InnerText;

                    writer.WriteStartElement("album");
                    writer.WriteElementString("title", albumTitle);
                    writer.WriteElementString("artist", artistName);
                    writer.WriteEndElement();
                    //Console.WriteLine("{0} - {1}", albumTitle, artistName);
                }
                writer.WriteEndDocument();
            }
            //   Process.Start(outputXMLPath);
        }
    }
}