using ConsoleApp1.Crawler;

using DotNetEnv;

Env.Load();

var crawler = new WebCrawlerEngine(
    "https://www.langchain.com/",
    100
);

await crawler.StartAsync();