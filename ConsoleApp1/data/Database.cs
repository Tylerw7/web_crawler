using MongoDB.Driver;


namespace ConsoleApp1.data;

public class Database
{
    private readonly IMongoCollection<Webpage> _collection;

    public Database()
    {
        var uri = Environment.GetEnvironmentVariable("MONGODB_URI");
        var client = new MongoClient(uri);

        var db = client.GetDatabase("webCrawlerArchive");
        _collection = db.GetCollection<Webpage>("webpages");

        _collection.DeleteMany(_ => true);
    }

    public void Insert(Webpage page)
    {
        _collection.InsertOne(page);
    }
}