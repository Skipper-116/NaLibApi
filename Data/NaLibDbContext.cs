using Microsoft.EntityFrameworkCore;
using NaLibApi.Models;
using NaLibApi.Interfaces;
using System.Reflection;

namespace NaLibApi.Data
{
    public class NaLibDbContext : DbContext
    {
        public NaLibDbContext(DbContextOptions<NaLibDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserGrade> UserGrades { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<RoleAccess> RoleAccesses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberContact> MemberContacts { get; set; }
        public DbSet<MemberRent> MemberRents { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<ResourceStatus> ResourceStatuses { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var method = SetRelationshipsMethod.MakeGenericMethod(entityType.ClrType);
                method.Invoke(this, new object[] { modelBuilder });
            }
        }

        private static readonly MethodInfo SetRelationshipsMethod =
            typeof(NaLibDbContext).GetMethod(
                nameof(SetRelationships),
                BindingFlags.NonPublic | BindingFlags.Instance
            );

        private void SetRelationships<TEntity>(ModelBuilder modelBuilder)
            where TEntity : class, ICreatedUpdatedVoidedEntity
        {
            modelBuilder
                .Entity<TEntity>()
                .HasOne(c => c.CreatedByUser)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy);

            modelBuilder
                .Entity<TEntity>()
                .HasOne(c => c.UpdatedByUser)
                .WithMany()
                .HasForeignKey(c => c.UpdatedBy);

            modelBuilder
                .Entity<TEntity>()
                .HasOne(c => c.VoidedByUser)
                .WithMany()
                .HasForeignKey(c => c.VoidedBy);
        }
    }
}
