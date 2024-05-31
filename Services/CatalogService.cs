using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NaLibApi.Data;
using NaLibApi.Models;

namespace NaLibApi.Services;

public class CatalogService
{
    private readonly IMongoCollection<Catalog> _catalogsCollection;

    public CatalogService(IOptions<NoSQLDbContext> noSqlDatabaseSettings)
    {
        var mongoClient = new MongoClient(noSqlDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(noSqlDatabaseSettings.Value.DatabaseName);

        _catalogsCollection = mongoDatabase.GetCollection<Catalog>(
            noSqlDatabaseSettings.Value.CatalogCollectionName
        );
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

    // search for a catalog using a search term
    // this can be all properties of the catalog
    public async Task<List<Catalog>> SearchAsync(string searchTerm)
    {
        var filters = new List<FilterDefinition<Catalog>>
        {
            Builders<Catalog>.Filter.Regex(
                x => x.Title,
                new BsonRegularExpression(searchTerm, "i")
            ),
            Builders<Catalog>.Filter.AnyIn(x => x.Authors, new[] { searchTerm }),
            Builders<Catalog>.Filter.AnyIn(x => x.Genres, new[] { searchTerm }),
            Builders<Catalog>.Filter.Regex(x => x.ISBN, new BsonRegularExpression(searchTerm, "i")),
            Builders<Catalog>.Filter.Regex(
                x => x.Language,
                new BsonRegularExpression(searchTerm, "i")
            ),
            Builders<Catalog>.Filter.Regex(
                x => x.Publisher,
                new BsonRegularExpression(searchTerm, "i")
            ),
            Builders<Catalog>.Filter.AnyIn(x => x.Subjects, new[] { searchTerm }),
            Builders<Catalog>.Filter.ElemMatch(
                x => x.Reviews,
                Builders<Review>.Filter.Regex(
                    y => y.Comments,
                    new BsonRegularExpression(searchTerm, "i")
                )
            )
        };

        if (DateTime.TryParse(searchTerm, out DateTime searchDate))
        {
            filters.Add(Builders<Catalog>.Filter.Eq(x => x.PublicationDate.Date, searchDate.Date));
        }

        var searchFilter = Builders<Catalog>.Filter.Or(filters);

        return await _catalogsCollection.Find(searchFilter).ToListAsync();
    }
}
