namespace NaLibApi.Data
{
    public class NoSQLDbContext
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CatalogCollectionName { get; set; } = null!;
        public string ResourceTypeCollectionName { get; set; } = null!;
        public string CatalogEventCollectionName { get; set; } = null!;
    }
}
