using Microsoft.Extensions.Options;
using MongoDB.Driver;
using contact_api.Models;
namespace contact_api.Services
{
    public class PeopleServices
    {
        private readonly IMongoCollection<People> _peopleCollection;

        public PeopleServices(IOptions<PeopleDatabaseSettings> peopleServices)
        {
            var mongoClient = new MongoClient(peopleServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(peopleServices.Value.DatabaseName);

            _peopleCollection = mongoDatabase.GetCollection<People>
                (peopleServices.Value.PeopleCollectionName);

        }

        public async Task<List<People>> GetAsync() =>
            await _peopleCollection.Find(x => true).ToListAsync();
        public async Task<People> GetAsync(string id) =>
            await _peopleCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(People people) =>
            await _peopleCollection.InsertOneAsync(people);
        public async Task<People> UpdateAsync(string peopleId, People peopleUpdate)
        {
            var people = await _peopleCollection.FindOneAndUpdateAsync(
              Builders<People>.Filter.Where(pep => pep.Id == peopleId),
              Builders<People>.Update
                .Set(pep => pep.Telefone, peopleUpdate.Telefone)
                .Set(pep => pep.Email, peopleUpdate.Email)
                .Set(pep => pep.Celular, peopleUpdate.Celular));

            return people;
        }
       
        public async Task RemoveAsync(string id) =>
            await _peopleCollection.DeleteOneAsync(x => x.Id == id);
    }
}
