using HtmlAgilityPack;
using System.Threading.Channels;
using ConsoleApp1.data;


namespace ConsoleApp1.Parsing;


public static class HtmlParser
{
    public static void Parse(string url, string html, Channel<string> queue, Database db)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var title = doc.DocumentNode
            .SelectSingleNode("//title")?.InnerText ?? "";

        var body = doc.DocumentNode
            .SelectSingleNode("//body")?.InnerText ?? "";

        db.Insert(new Webpage
        {
            Url = url,
            Title = title,
            Content = body[..Math.Min(500, body.Length)]
        });

        var links = doc.DocumentNode.SelectNodes("//a[@href]");
        if (links == null) return;

        foreach (var link in links)
        {
            var href = link.GetAttributeValue("href", "");
            if (href.StartsWith("http"))
            {
                queue.Writer.TryWrite(href);
            }
        }        
    }
}