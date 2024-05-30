using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace NaLibApi.Models
{
    public class Member : NaLibApi.Interfaces.ICreatedUpdatedVoidedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required"),
         StringLength(150, MinimumLength = 6, ErrorMessage = "First name must be between 6 and 150 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required"),
         StringLength(150, MinimumLength = 6, ErrorMessage = "Last name must be between 6 and 150 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required"),
         StringLength(150, MinimumLength = 6, ErrorMessage = "Email must be between 6 and 150 characters"),
         EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Membership code is required"),
         StringLength(150, MinimumLength = 6, ErrorMessage = "Membership code must be between 6 and 150 characters")]
        public string MembershipCode { get; set; }
        [Required(ErrorMessage = "Date enrolled is required")]
        public DateTime DateEnrolled { get; set; }

        [Required(ErrorMessage = "Creator is required"), JsonIgnore]
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
        [ForeignKey("CreatedBy"), JsonIgnore] public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy"), JsonIgnore] public User UpdatedByUser { get; set; }

        [ForeignKey("VoidedBy"), JsonIgnore] public User VoidedByUser { get; set; }
    }
}
