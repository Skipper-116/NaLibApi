namespace NaLibApi.Models
{
    public class CatalogEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string EventType { get; set; }
        public string CatalogId { get; set; }

        // json property named changes for tracking changes
        public List<Catalog> Changes { get; set; }
        public DateTime EventDate { get; set; }
        public int CreatedBy { get; set; }

        // timestamp for when the event was created
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
