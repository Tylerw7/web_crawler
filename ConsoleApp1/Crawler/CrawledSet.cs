using System.Collections.Concurrent;


namespace ConsoleApp1.Crawler;


public class CrawledSet
{
    private readonly ConcurrentDictionary<ulong, bool> _visited = new();

    public bool TryAdd(string url)
    {
        return _visited.TryAdd(Hash(url), true);
    }

    public int Count => _visited.Count;

    private static ulong Hash(string url)
    {
        return (ulong)url.GetHashCode();
    }
}