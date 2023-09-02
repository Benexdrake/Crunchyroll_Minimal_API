using MongoDB.Driver;

namespace Server.Data
{
    public class CrunchyrollDBContext
    {
        public IMongoCollection<Models.Anime> Animes { get; set; }

        public CrunchyrollDBContext(IServiceProvider service)
        {
            var config = service.GetRequiredService<IConfiguration>();
            var client = service.GetRequiredService<MongoClient>();

            var db = client.GetDatabase(config["MongoDb:Database"]);

            Animes = db.GetCollection<Models.Anime>(config["MongoDb:Collection"]);
        }
    }
}
