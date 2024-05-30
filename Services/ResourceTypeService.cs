using NaLibApi.Data;
using NaLibApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace NaLibApi.Services;

public class ResourceTypeService
{
    private readonly IMongoCollection<ResourceType> _resourceTypesCollection;

    public ResourceTypeService(
        IOptions<NoSQLDbContext> noSqlDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            noSqlDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            noSqlDatabaseSettings.Value.DatabaseName);

        _resourceTypesCollection = mongoDatabase.GetCollection<ResourceType>(
            noSqlDatabaseSettings.Value.CatalogCollectionName);
    }

    public async Task<List<ResourceType>> GetAsync() =>
        await _resourceTypesCollection.Find(_ => true).ToListAsync();

    public async Task<ResourceType?> GetAsync(string id) =>
        await _resourceTypesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ResourceType newCatalog) =>
        await _resourceTypesCollection.InsertOneAsync(newCatalog);

    public async Task UpdateAsync(string id, ResourceType updatedCatalog) =>
        await _resourceTypesCollection.ReplaceOneAsync(x => x.Id == id, updatedCatalog);

    public async Task RemoveAsync(string id) =>
        await _resourceTypesCollection.DeleteOneAsync(x => x.Id == id);
}