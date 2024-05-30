using NaLibApi.Data;
using NaLibApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace NaLibApi.Services;

public class CatalogService
{
    private readonly IMongoCollection<Catalog> _catalogsCollection;

    public CatalogService(
        IOptions<NoSQLDbContext> noSqlDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            noSqlDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            noSqlDatabaseSettings.Value.DatabaseName);

        _catalogsCollection = mongoDatabase.GetCollection<Catalog>(
            noSqlDatabaseSettings.Value.CatalogCollectionName);
    }

    public async Task<List<Catalog>> GetAsync() =>
        await _catalogsCollection.Find(_ => true).ToListAsync();

    public async Task<Catalog?> GetAsync(string id) =>
        await _catalogsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Catalog newCatalog) =>
        await _catalogsCollection.InsertOneAsync(newCatalog);

    public async Task UpdateAsync(string id, Catalog updatedCatalog) =>
        await _catalogsCollection.ReplaceOneAsync(x => x.Id == id, updatedCatalog);

    public async Task RemoveAsync(string id) =>
        await _catalogsCollection.DeleteOneAsync(x => x.Id == id);
}