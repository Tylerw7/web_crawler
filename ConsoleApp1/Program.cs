using HtmlAgilityPack;
using DotNetEnv;

Env.Load();


var web = new HtmlWeb();
var document = web.Load("https://cabinetrybywettach.com");
Console.WriteLine("Page loaded!");