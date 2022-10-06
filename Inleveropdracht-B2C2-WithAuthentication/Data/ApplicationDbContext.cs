using Inleveropdracht_B2C2_WithAuthentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inleveropdracht_B2C2_WithAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Punten> Points { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
            .HasMany(au => au.Cameras)
            .WithOne(c => c.AppUser)
            .HasForeignKey(au => au.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}