using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MissionSystem.Domain.Entity;
using MissionSystem.Domain.Entity.Identity;

namespace MissionSystem.Infrastructure.Database
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<School> Schools { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<ContentDetail> ContentDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Government> Governments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<School>(builder =>
            {
                builder.HasOne(r => r.Coordinator)
                    .WithMany(u => u.Schools)
                .HasForeignKey(r => r.CoordinatorId)
                .OnDelete(DeleteBehavior.NoAction);

                builder
                .HasIndex(r => new { r.CoordinatorId, r.AddressId })
                .IsUnique();
            });
        }
    }
}
