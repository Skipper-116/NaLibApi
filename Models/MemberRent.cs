using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NaLibApi.Models
{
    public class MemberRent  : Interfaces.ICreatedUpdatedVoidedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required(ErrorMessage = "Member is required")]
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Resource is required")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Resource must be between 6 and 150 characters")]
        public string Resource { get; set; }
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool Overdue { get; set; }
        [Required(ErrorMessage = "Resource condition is required")]
        public int Condition { get; set; }
        // public string ResourceCondition => $"{ConditionStatus?.Name}";
        // public string ResourceReturnCondition => $"{ReturnConditionStatus?.Name}";
        [Required(ErrorMessage = "Return condition is required")]
        public int? ReturnCondition { get; set; }
        [JsonIgnore]
        public int? ProcessedBy { get; set; }
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
        [ForeignKey("MemberId")]
        public Member Member { get; set; }

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
        public User ProcessedByUser { get; set; }

        // [ForeignKey("Condition")]
        // [JsonIgnore]
        // public ResourceStatus? ConditionStatus { get; set; }
        //
        // [ForeignKey("ReturnCondition")]
        // [JsonIgnore]
        // public ResourceStatus? ReturnConditionStatus { get; set; }
    }
}
