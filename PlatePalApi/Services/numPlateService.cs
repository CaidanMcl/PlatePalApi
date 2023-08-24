using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlatePalApi.Models;

namespace PlatePalApi.Services
{
    public class numPlateService
    {
        private readonly IMongoCollection<NumberPlate> _numCollection;

        public numPlateService(
            IOptions<NumberPlateDatabaseSettings> numberPlateDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                numberPlateDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                numberPlateDatabaseSettings.Value.DatabaseName);

            _numCollection = mongoDatabase.GetCollection<NumberPlate>(
                numberPlateDatabaseSettings.Value.numberPlatesCollectionName);
        }

        public async Task<List<NumberPlate>> GetAsync() =>
            await _numCollection.Find(_ => true).ToListAsync();

        public async Task<NumberPlate?> GetAsync(string id) =>
            await _numCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(NumberPlate newNplate) =>
            await _numCollection.InsertOneAsync(newNplate);

        public async Task UpdateAsync(string id, NumberPlate updatesPnum) =>
            await _numCollection.ReplaceOneAsync(x => x.Id == id, updatesPnum);

        public async Task RemoveAsync(string id) =>
            await _numCollection.DeleteOneAsync(x => x.Id == id);
    }
}
