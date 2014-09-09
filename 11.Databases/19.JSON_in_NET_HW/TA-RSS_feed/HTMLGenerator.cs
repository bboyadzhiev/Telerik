namespace TA_RSS_feed
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using TA_RSS_feed.Models;

    internal class HTMLGenerator
    {
        private static void Main(string[] args)
        {
            var xmlOutput = @"..\..\..\qa.xml";
            var htmlOutput = @"..\..\..\qa.html";
            var rssLink = "http://forums.academy.telerik.com/feed/qa.rss";

            var webClient = new WebClient();
            webClient.DownloadFile(rssLink, xmlOutput);

            var xmlNode = XElement.Load(xmlOutput);
            string xmlToJson = JsonConvert.SerializeXNode(xmlNode, Newtonsoft.Json.Formatting.Indented);

            var jsonRSS = JObject.Parse(xmlToJson);

            var pocoRSS = JsonConvert.DeserializeObject<RssFeed>(xmlToJson);

            GenerateHTMLPage(htmlOutput, pocoRSS);

            Process.Start(htmlOutput);
        }

        private static void GenerateHTMLPage(string htmlOutput, RssFeed pocoRSS)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<html><body>");
            html.Append("<h1>" + pocoRSS.Rss.Channel.Title + "</h1>");
            html.Append("<h5>" + pocoRSS.Rss.Channel.Description + "</h5>");
            html.Append("<ul>");

            foreach (var item in pocoRSS.Rss.Channel.Item)
            {
                html.AppendLine("<li>Question: <strong>" + item.Title + "</strong> Category: " + item.Category + "</li>");
            }

            html.Append("</ul>");
            html.Append("</html></body>");

            var fileStream = new FileStream(htmlOutput, FileMode.Create);
            using (fileStream)
            {
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.WriteLine(html);
                }
            }

            Console.WriteLine("Webpage generated : " + htmlOutput);
        }
    }
}