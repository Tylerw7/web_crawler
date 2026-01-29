using ConsoleApp1.Crawler;


class Program
{
    static async Task Main()
    {
        var crawler = new WebCrawlerEngine(
            "https://cabinetrybywettach.com",
            100
        );
    }
}