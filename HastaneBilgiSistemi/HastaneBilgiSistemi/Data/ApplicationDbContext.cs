﻿using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneBilgiSistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<ClientHistory> ClientHistory { get; set; }
        public DbSet<ClientHistoryMedication> ClientHistoryMedication { get; set; }
        public DbSet<Diseas> Diseas { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medication> Medication { get; set; }
        public DbSet<Polyclinic> Polyclinic { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Secretary> Secretary { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IdentityUserRole<string>>(eb => { eb.HasNoKey(); });

            var r1 = new ApplicationRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" };
            var r2 = new ApplicationRole { Id = 2, Name = "Doctor", NormalizedName = "DOCTOR" };
            var r3 = new ApplicationRole { Id = 3, Name = "Secretary", NormalizedName = "SECRETARY" };
            var r4 = new ApplicationRole { Id = 4, Name = "Client", NormalizedName = "CLIENT" };
            modelBuilder.Entity<ApplicationRole>().HasData(r1, r2, r3, r4);

            var user = new ApplicationUser();
            var hasher = new PasswordHasher<ApplicationUser>();
            var u1 = new ApplicationUser { Id = 1, UserName = "admin@admin.com", Email = "admin@admin.com", EmailConfirmed = true, NormalizedUserName = "admin@admin.com", PasswordHash = hasher.HashPassword(user, "a.A123"), PhoneNumber = "+905325321234" };
            var u2 = new ApplicationUser { Id = 2, UserName = "doctor@doctor.com", Email = "doctor@doctor.com", EmailConfirmed = true, NormalizedUserName = "doctor@doctor.com", PasswordHash = hasher.HashPassword(user, "a.A123"), PhoneNumber = "+905325321234" };
            var u3 = new ApplicationUser { Id = 3, UserName = "secretary@secretary.com", Email = "secretary@secretary.com", EmailConfirmed = true, NormalizedUserName = "secretary@secretary.com", PasswordHash = hasher.HashPassword(user, "a.A123"), PhoneNumber = "+905325321234" };
            var u4 = new ApplicationUser { Id = 4, UserName = "client@client.com", Email = "client@client.com", EmailConfirmed = true, NormalizedUserName = "client@client.com", PasswordHash = hasher.HashPassword(user, "a.A123"), PhoneNumber = "+905325321234" };
            modelBuilder.Entity<ApplicationUser>().HasData(u1, u2, u3, u4);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = u1.Id, RoleId = r1.Id },
                new IdentityUserRole<int> { UserId = u2.Id, RoleId = r2.Id },
                new IdentityUserRole<int> { UserId = u3.Id, RoleId = r3.Id },
                new IdentityUserRole<int> { UserId = u4.Id, RoleId = r4.Id }
            );

            modelBuilder.Entity<Medication>().HasData(
                new Medication { Id = 1, Name = "AZOSİLİN 30 TB" },
                new Medication { Id = 2, Name = "BACTRİM 200/40 MG 100 ML SÜSPANSİYON" },
                new Medication { Id = 3, Name = "DUOCİD ORAL SÜSPANSİYON 250MG/5ML 100ML" },
                new Medication { Id = 4, Name = "DEPOSİLİN 1.2 IU FLK" },
                new Medication { Id = 5, Name = "MACROL 250 MG 100 ML SUSPANSIYON" },
                new Medication { Id = 6, Name = "NİDAZOL 500 MG FİLM TABLET" },
                new Medication { Id = 7, Name = "SUPRAX SUSPANSIYON 50 ML." },
                new Medication { Id = 8, Name = "SUPRAX 400 MG" }
            );

            Polyclinic p1 = new Polyclinic { Id = 1, Name = "Ağız ve Diş Sağlığı Servisi" };
            Polyclinic p2 = new Polyclinic { Id = 2, Name = "Anestezi ve Reanimasyon Servisi" };
            Polyclinic p3 = new Polyclinic { Id = 3, Name = "Beslenme ve Diyet Bölümü" };
            Polyclinic p4 = new Polyclinic { Id = 4, Name = "Cilt Hastalıkları Servisi" };
            Polyclinic p5 = new Polyclinic { Id = 5, Name = "Çocuk Servisi" };
            Polyclinic p6 = new Polyclinic { Id = 6, Name = "Dahiliye Servisi" };
            Polyclinic p7 = new Polyclinic { Id = 7, Name = "Fizik Tedavi Servisi" };
            Polyclinic p8 = new Polyclinic { Id = 8, Name = "Genel Cerrahi Servisi" };
            Polyclinic p9 = new Polyclinic { Id = 9, Name = "Göğüs Hastalıkları Servisi" };
            Polyclinic p10 = new Polyclinic { Id = 10, Name = "Göz Servisi" };
            Polyclinic p11 = new Polyclinic { Id = 11, Name = "Kadın Hastalıkları ve Doğum Servisi" };
            Polyclinic p12 = new Polyclinic { Id = 12, Name = "Kardiyoloji Servisi" };
            Polyclinic p13 = new Polyclinic { Id = 13, Name = "Kulak Burun Boğaz Servisi" };
            Polyclinic p14 = new Polyclinic { Id = 14, Name = "Nöroloji Servisi" };
            Polyclinic p15 = new Polyclinic { Id = 15, Name = "Nöroşirüji Servisi" };
            Polyclinic p16 = new Polyclinic { Id = 16, Name = "Ortopedi ve Travmatoloji Servisi" };
            Polyclinic p17 = new Polyclinic { Id = 17, Name = "Patoloji Servisi" };
            Polyclinic p18 = new Polyclinic { Id = 18, Name = "Psikoloji Servisi" };
            Polyclinic p19 = new Polyclinic { Id = 19, Name = "Radyoloji Servisi" };
            Polyclinic p20 = new Polyclinic { Id = 20, Name = "Üroloji Servisi" };
            modelBuilder.Entity<Polyclinic>().HasData(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, PolyclinicId = p9.Id, UserId = u2.Id }
            );

            modelBuilder.Entity<Secretary>().HasData(
                new Secretary { Id = 1, UserId = u3.Id }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, UserId = u4.Id }
            );

            modelBuilder.Entity<Diseas>().HasData(
                new Diseas { Id = 1, Name = "COVID-19" },
                new Diseas { Id = 2, Name = "Hipertansiyon" },
                new Diseas { Id = 3, Name = "Hiperlipidemi " },
                new Diseas { Id = 4, Name = "Akut Romatizmal Ateş" },
                new Diseas { Id = 5, Name = "Multiple Skleroz" },
                new Diseas { Id = 6, Name = "Üst Solunum Yolu Enfeksiyonu" },
                new Diseas { Id = 7, Name = "Alt Solunum Yolu Enfeksiyonu" },
                new Diseas { Id = 8, Name = "Akut Gastroenterit" },
                new Diseas { Id = 9, Name = "Yumuşak Doku Enfeksiyonu " }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}