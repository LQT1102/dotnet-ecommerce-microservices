using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class DBContext : IDBContext
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;

        public DBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            _database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            _configuration = configuration;

            //Tạo seedData, thực tế không cần
            var productCollection = _database.GetCollection<Product>(_configuration.GetValue<string>("DatabaseSettings:ProductCollectionName"));
            CatalogContextSeed.SeedData(productCollection);
        }

        public IMongoCollection<Product> GetProductCollection()
        {
            return _database.GetCollection<Product>(_configuration.GetValue<string>("DatabaseSettings:ProductCollectionName"));
        }

        //Methods to retrieve other Collections ....
        //...
    }
}
