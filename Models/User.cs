using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaLibApi.Models
{
    public sealed class User : NaLibApi.Interfaces.ICreatedUpdatedVoidedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int? LibraryId { get; set; }
        public required int CreatedBy { get; set; }
        public required int? UpdatedBy { get; set; }
        public bool Voided { get; set; }
        public int? VoidedBy { get; set; }
        public DateTime? VoidedOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("LibraryId")]
        public Library Library { get; set; }
        
        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public User UpdatedByUser { get; set; }

        [ForeignKey("VoidedBy")]
        public User VoidedByUser { get; set; }

        // Collection navigation properties
        public ICollection<UserSkill> UserSkills { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserGrade> UserGrades { get; set; }
        public ICollection<UserExperience> UserExperiences { get; set; }
        public ICollection<UserContact> UserContacts { get; set; }
        public ICollection<RoleAccess> RoleAccesses { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<MemberContact> MemberContacts { get; set; }
        public ICollection<MemberRent> MemberRents { get; set; }
        public ICollection<ContactType> ContactTypes { get; set; }
    }
}
