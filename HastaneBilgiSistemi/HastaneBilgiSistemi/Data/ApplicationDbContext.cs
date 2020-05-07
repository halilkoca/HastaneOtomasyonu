using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneBilgiSistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Diseas> Disease { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUserRole<string>>(eb => { eb.HasNoKey(); });

            var r1 = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
            var r2 = new IdentityRole { Name = "Doctor", NormalizedName = "DOCTOR" };
            var r3 = new IdentityRole { Name = "Secretary", NormalizedName = "SECRETARY" };
            var r4 = new IdentityRole { Name = "Client", NormalizedName = "CLIENT" };
            modelBuilder.Entity<IdentityRole>().HasData(r1, r2, r3, r4);

            var user = new IdentityUser();
            var hasher = new PasswordHasher<IdentityUser>();
            var u1 = new IdentityUser { UserName = "admin@admin.com", Email = "admin@admin.com", EmailConfirmed = true, NormalizedUserName = "admin@admin.com", PasswordHash = hasher.HashPassword(user, "a.A123") };
            var u2 = new IdentityUser { UserName = "doctor@doctor.com", Email = "doctor@doctor.com", EmailConfirmed = true, NormalizedUserName = "doctor@doctor.com", PasswordHash = hasher.HashPassword(user, "a.A123") };
            var u3 = new IdentityUser { UserName = "secretary@secretary.com", Email = "secretary@secretary.com", EmailConfirmed = true, NormalizedUserName = "secretary@secretary.com", PasswordHash = hasher.HashPassword(user, "a.A123") };
            var u4 = new IdentityUser { UserName = "client@client.com", Email = "client@client.com", EmailConfirmed = true, NormalizedUserName = "client@client.com", PasswordHash = hasher.HashPassword(user, "a.A123") };
            modelBuilder.Entity<IdentityUser>().HasData(u1, u2, u3, u4);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = u1.Id, RoleId = r1.Id },
                new IdentityUserRole<string> { UserId = u2.Id, RoleId = r2.Id },
                new IdentityUserRole<string> { UserId = u3.Id, RoleId = r3.Id },
                new IdentityUserRole<string> { UserId = u4.Id, RoleId = r4.Id }
            );
        }

    }
}