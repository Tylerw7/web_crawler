



namespace ConsoleApp1.networking;

public static class PageFetcher
{
    private static readonly HttpClient _client = new();

    public static async Task<string> FetchAsync(string url)
    {
        try
        {
            return await _client.GetStringAsync(url);
        }
        catch
        {
            return string.Empty;
        }
    }
}