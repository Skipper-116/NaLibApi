using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using NaLibApi.Models;

namespace NaLibApi.Models;

public class ResourceStatus  : Interfaces.ICreatedUpdatedVoidedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
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

        [ForeignKey("CreatedBy")]
        [JsonIgnore]
        public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        [JsonIgnore]
        public User UpdatedByUser { get; set; }

        [ForeignKey("VoidedBy")]
        [JsonIgnore]
        public User VoidedByUser { get; set; }

        [ForeignKey("ProcessedBy")]
        [JsonIgnore]
        public User ProcessedByUser { get; set; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<MemberRent> MemberRents { get; set; }
    }