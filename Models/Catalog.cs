public class Catalog
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string[] Authors { get; set; }
    public string Publisher { get; set; }
    public string ISBN { get; set; }
    public DateTime PublicationDate { get; set; }
    public string[] Subjects { get; set; }
    public string[] Genres { get; set; }
    public string Language { get; set; }
    public string[] Keywords { get; set; }
    public string ClassificationNumber { get; set; }
    public PhysicalDescription Description { get; set; }
    public PublicationHistory[] History { get; set; }
    public Series SeriesInfo { get; set; }
    public Holding[] Holdings { get; set; }
    public Review[] Reviews { get; set; }
    public Content[] TableOfContents { get; set; }
    public int LibraryId { get; set; }
    public string ResourceTypeId { get; set; }
}