using Microsoft.EntityFrameworkCore;

namespace NaLibApi.Data
{
    public class NaLibDbContext : DbContext
    {
        public NaLibDbContext(DbContextOptions<NaLibDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserGrade> UserGrades { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<RoleAccess> RoleAccesses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberContact> MemberContacts { get; set; }
        public DbSet<MemberRent> MemberRents { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogEvent> CatalogEvents { get; set; }
    }
}