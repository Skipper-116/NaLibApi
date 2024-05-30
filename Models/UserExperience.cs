using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NaLibApi.Models
{
    public sealed class UserExperience  : NaLibApi.Interfaces.ICreatedUpdatedVoidedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Company is required")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Company must be between 6 and 150 characters")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Position is required")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Position must be between 6 and 150 characters")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Description must be between 6 and 150 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Creator is required")]
        [JsonIgnore]
        public required int CreatedBy { get; set; }
        [JsonIgnore]
        public required int? UpdatedBy { get; set; }
        [JsonIgnore]
        public bool Voided { get; set; }
        [JsonIgnore]
        public int? VoidedBy { get; set; }
        [JsonIgnore]
        public DateTime? VoidedOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        [JsonIgnore]
        public User User { get; set; }

        [ForeignKey("CreatedBy")]
        [JsonIgnore]
        public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        [JsonIgnore]
        public User UpdatedByUser { get; set; }

        [ForeignKey("VoidedBy")]
        [JsonIgnore]
        public User VoidedByUser { get; set; }
    }
}
