using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NaLibApi.Models
{
    public sealed class RoleAccess : NaLibApi.Interfaces.ICreatedUpdatedVoidedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Access ID is required")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Access ID must be between 6 and 150 characters")]
        public string AccessId { get; set; }
        [Required(ErrorMessage = "Allowed is required")]
        public bool Allowed { get; set; }
        public string RoleName => $"{Role?.Name}";
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
        public DateTime VoidedOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("RoleId")]
        [JsonIgnore]
        public Role Role { get; set; }

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
