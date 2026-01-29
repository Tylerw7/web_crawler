using System.Threading.Channels;
using ConsoleApp1.networking;
using ConsoleApp1.Parsing;
using ConsoleApp1.data;


namespace ConsoleApp1.Crawler;

public class WebCrawlerEngine
{
    private readonly Channel<string> _queue;
    private readonly CrawledSet _crawled = new();
    private readonly Database _db = new();
    private readonly int _maxPages;


    public WebCrawlerEngine(string seedUrl, int maxPages)
    {
        _queue = Channel.CreateBounded<string>(1000);
        _queue.Writer.WriteAsync(seedUrl);
        _maxPages = maxPages;

    }

    public async Task StartAsync()
    {
        var workers = Enumerable.Range(0, 10)
            .Select(_ => Task.Run(WorkerAsync))
            .ToArray();
    }

    private async Task WorkerAsync()
    {
        while (_crawled.Count < _maxPages)
        {
            var url = await _queue.Reader.ReadAsync();

            if (!_crawled.TryAdd(url))
                continue;

            var html = await PageFetcher.FetchAsync(url);
            if (string.IsNullOrEmpty(html))
                continue;

            HtmlParser.Parse(url, html, _queue, _db);        
        }
    }

}