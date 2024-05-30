using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NaLibApi.Models
{
    public class User : Interfaces.ICreatedUpdatedVoidedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Given name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Given name must be between 2 and 50 characters")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Family name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Family name must be between 2 and 50 characters")]
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Required(ErrorMessage = "Email is required")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Email must be between 6 and 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(150, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
        [JsonIgnore]
        public string? Password { get; set; }
        public int? LibraryId { get; set; }
        public string LibraryName => $"{Library?.Name}";
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
        [ForeignKey("LibraryId")]
        [JsonIgnore]
        public Library Library { get; set; }
        
        [ForeignKey("CreatedBy")]
        [JsonIgnore]
        public User? CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        [JsonIgnore]
        public User? UpdatedByUser { get; set; }

        [ForeignKey("VoidedBy")]
        [JsonIgnore]
        public User? VoidedByUser { get; set; }

        // Collection navigation properties
        [JsonIgnore]
        public ICollection<UserSkill>? UserSkills { get; set; }
        [JsonIgnore]
        public ICollection<UserRole>? UserRoles { get; set; }
        [JsonIgnore]
        public ICollection<UserGrade>? UserGrades { get; set; }
        [JsonIgnore]
        public ICollection<UserExperience>? UserExperiences { get; set; }
        [JsonIgnore]
        public ICollection<UserContact>? UserContacts { get; set; }
        [JsonIgnore]
        public ICollection<RoleAccess>? RoleAccesses { get; set; }
        [JsonIgnore]
        public ICollection<Role>? Roles { get; set; }
        [JsonIgnore]
        public ICollection<Member>? Members { get; set; }
        [JsonIgnore]
        public ICollection<MemberContact>? MemberContacts { get; set; }
        [JsonIgnore]
        public ICollection<MemberRent>? MemberRents { get; set; }
        [JsonIgnore]
        public ICollection<ContactType>? ContactTypes { get; set; }
    }
}
