using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using YAMongo.API.Data;

namespace YAMongo.API.Controllers
{
    public class MongoController : Controller
    {
        private readonly IMongoClient _mongoClient;
        public MongoController(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        [Route("~/insert")]
        public IActionResult InsertData()
        {
            var key = Guid.NewGuid();
            var person = new Person() { Id = key, Name = $"Insert - {DateTime.Now}" };

            var database = _mongoClient.GetDatabase("foo");
            var collection = database.GetCollection<Person>("persons");
            collection.InsertOne(person);

            return Ok();
        }

        [Route("~/update")]
        public IActionResult UpdateData()
        {
            var key = Guid.NewGuid();
            var person = new Person() { Id = key, Name = $"Update - {DateTime.Now}" };
            
            var database = _mongoClient.GetDatabase("foo");
            var collection = database.GetCollection<Person>("persons");
            collection.ReplaceOne(t => t.Id == key, person, new ReplaceOptions { IsUpsert = true });
            
            return Ok();
        }

    }
}
