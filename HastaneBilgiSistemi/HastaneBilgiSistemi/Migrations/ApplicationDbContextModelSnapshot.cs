﻿// <auto-generated />
using System;
using HastaneBilgiSistemi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HastaneBilgiSistemi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "32b21c1d-db07-47f6-9dc3-605a6ac57290",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "886935fb-8c0a-4bac-9c58-0dc382bceca5",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "a119ae79-0f6e-4fe5-9bbb-62a5d05645f0",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = 4,
                            ConcurrencyStamp = "cce3673c-4385-4b17-920e-35a17ce0c8ba",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "36c3656a-4881-412c-a1ac-e6f455e7ba11",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "admin@admin.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEINxeHAWrQpO8BImS42w4eeTqO3dPb8NsbIBvBtW47KUMdMljIDmvXIRGfkGX2CL1A==",
                            PhoneNumber = "+905325321234",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "50719b97-64df-4f06-a13b-ad0ae899d659",
                            Email = "doctor@doctor.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "doctor@doctor.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEKtCFortBC7H/zwj5nNFtM+bvojfeWBorWvojM2LwombEzhMvObtvPLYS34rm0RCkw==",
                            PhoneNumber = "+905325321234",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "doctor@doctor.com"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "1934d749-16e5-46d9-a8b7-7aab1e212ca7",
                            Email = "secretary@secretary.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "secretary@secretary.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAtncvoAoEhf2tjQyeCwZE7zG73xiswr/mK13pK57g6a25wLpW37rfVO+d55DBIGlA==",
                            PhoneNumber = "+905325321234",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "secretary@secretary.com"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "02703ba2-fe70-484b-9a6c-0bb9a90c240b",
                            Email = "client@client.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "client@client.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEHWh2lHYAh91MhFUr5XrLKdixqgooUR+3gqRxuOWCRAPYIcwUmwkVCyPe0oU1wiySA==",
                            PhoneNumber = "+905325321234",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "client@client.com"
                        });
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.ClientHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiseasId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PolyclinicId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiseasId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PolyclinicId");

                    b.HasIndex("ReservationId");

                    b.ToTable("ClientHistory");
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.ClientHistoryMedication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("MedicationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientHistoryId");

                    b.HasIndex("MedicationId");

                    b.ToTable("ClientHistoryMedication");
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Diseas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Diseas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "COVID-19"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hipertansiyon"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hiperlipidemi "
                        },
                        new
                        {
                            Id = 4,
                            Name = "Akut Romatizmal Ateş"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Multiple Skleroz"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Üst Solunum Yolu Enfeksiyonu"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Alt Solunum Yolu Enfeksiyonu"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Akut Gastroenterit"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Yumuşak Doku Enfeksiyonu "
                        });
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PolyclinicId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolyclinicId");

                    b.HasIndex("UserId");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PolyclinicId = 9,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Medication");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AZOSİLİN 30 TB"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BACTRİM 200/40 MG 100 ML SÜSPANSİYON"
                        },
                        new
                        {
                            Id = 3,
                            Name = "DUOCİD ORAL SÜSPANSİYON 250MG/5ML 100ML"
                        },
                        new
                        {
                            Id = 4,
                            Name = "DEPOSİLİN 1.2 IU FLK"
                        },
                        new
                        {
                            Id = 5,
                            Name = "MACROL 250 MG 100 ML SUSPANSIYON"
                        },
                        new
                        {
                            Id = 6,
                            Name = "NİDAZOL 500 MG FİLM TABLET"
                        },
                        new
                        {
                            Id = 7,
                            Name = "SUPRAX SUSPANSIYON 50 ML."
                        },
                        new
                        {
                            Id = 8,
                            Name = "SUPRAX 400 MG"
                        });
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Polyclinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Polyclinic");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ağız ve Diş Sağlığı Servisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Anestezi ve Reanimasyon Servisi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Beslenme ve Diyet Bölümü"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cilt Hastalıkları Servisi"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Çocuk Servisi"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Dahiliye Servisi"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Fizik Tedavi Servisi"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Genel Cerrahi Servisi"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Göğüs Hastalıkları Servisi"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Göz Servisi"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Kadın Hastalıkları ve Doğum Servisi"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Kardiyoloji Servisi"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Kulak Burun Boğaz Servisi"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Nöroloji Servisi"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Nöroşirüji Servisi"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Ortopedi ve Travmatoloji Servisi"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Patoloji Servisi"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Psikoloji Servisi"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Radyoloji Servisi"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Üroloji Servisi"
                        });
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PolicylinicId")
                        .HasColumnType("int");

                    b.Property<int?>("PolyclinicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PolyclinicId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Secretary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Secretary");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Client", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.ClientHistory", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.Diseas", "Diseas")
                        .WithMany()
                        .HasForeignKey("DiseasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneBilgiSistemi.Data.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneBilgiSistemi.Data.Model.Polyclinic", "Polyclinic")
                        .WithMany()
                        .HasForeignKey("PolyclinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneBilgiSistemi.Data.Model.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.ClientHistoryMedication", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.ClientHistory", "ClientHistory")
                        .WithMany()
                        .HasForeignKey("ClientHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneBilgiSistemi.Data.Model.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Doctor", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.Polyclinic", "Polyclinic")
                        .WithMany()
                        .HasForeignKey("PolyclinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Reservation", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneBilgiSistemi.Data.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneBilgiSistemi.Data.Model.Polyclinic", "Polyclinic")
                        .WithMany()
                        .HasForeignKey("PolyclinicId");
                });

            modelBuilder.Entity("HastaneBilgiSistemi.Data.Model.Secretary", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("HastaneBilgiSistemi.Data.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
