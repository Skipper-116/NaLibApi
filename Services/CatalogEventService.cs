using NaLibApi.Data;
using NaLibApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace NaLibApi.Services;

public class CatalogEventService
{
    private readonly IMongoCollection<CatalogEvent> _catalogEventsCollection;

    public CatalogEventService(
        IOptions<NoSQLDbContext> noSqlDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            noSqlDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            noSqlDatabaseSettings.Value.DatabaseName);

        _catalogEventsCollection = mongoDatabase.GetCollection<CatalogEvent>(
            noSqlDatabaseSettings.Value.CatalogCollectionName);
    }

    public async Task<List<CatalogEvent>> GetAsync() =>
        await _catalogEventsCollection.Find(_ => true).ToListAsync();

    public async Task<CatalogEvent?> GetAsync(string id) =>
        await _catalogEventsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(CatalogEvent newCatalog) =>
        await _catalogEventsCollection.InsertOneAsync(newCatalog);

    public async Task UpdateAsync(string id, CatalogEvent updatedCatalog) =>
        await _catalogEventsCollection.ReplaceOneAsync(x => x.Id == id, updatedCatalog);

    public async Task RemoveAsync(string id) =>
        await _catalogEventsCollection.DeleteOneAsync(x => x.Id == id);
}