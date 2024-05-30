using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NaLibApi.Models
{
    public class ContactType : NaLibApi.Interfaces.ICreatedUpdatedVoidedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "User is required")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 150 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Creator is required")]
        [JsonIgnore]
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int? UpdatedBy { get; set; }
        [JsonIgnore]
        public bool Voided { get; set; }
        [JsonIgnore]
        public int? VoidedBy { get; set; }
        [JsonIgnore]
        public DateTime? VoidedOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("CreatedBy")]
        [JsonIgnore]
        public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        [JsonIgnore]
        public User UpdatedByUser { get; set; }

        [ForeignKey("VoidedBy")]
        [JsonIgnore]
        public User VoidedByUser { get; set; }

        // Collection navigation properties
        [JsonIgnore]
        public ICollection<UserContact> UserContacts { get; set; }
        [JsonIgnore]
        public ICollection<MemberContact> MemberContacts { get; set; }
    }
}
