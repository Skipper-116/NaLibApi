namespace NaLibApi.Models
{
    public sealed class ContactType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int CreatedBy { get; set; }
        public required int? UpdatedBy { get; set; }
        public bool Voided { get; set; }
        public int? VoidedBy { get; set; }
        public DateTime? VoidedOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
