﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneBilgiSistemi.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 128, nullable: true),
                    LastName = table.Column<string>(maxLength: 128, nullable: true),
                    FullName = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diseas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Polyclinic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polyclinic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Secretary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PolyclinicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Polyclinic_PolyclinicId",
                        column: x => x.PolyclinicId,
                        principalTable: "Polyclinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Doctor_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolyclinicId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservation_Polyclinic_PolyclinicId",
                        column: x => x.PolyclinicId,
                        principalTable: "Polyclinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    DiseasId = table.Column<int>(nullable: false),
                    PolyclinicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Diseas_DiseasId",
                        column: x => x.DiseasId,
                        principalTable: "Diseas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Polyclinic_PolyclinicId",
                        column: x => x.PolyclinicId,
                        principalTable: "Polyclinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientHistory_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientHistoryMedication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientHistoryId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistoryMedication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHistoryMedication_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientHistoryMedication_PatientHistory_PatientHistoryId",
                        column: x => x.PatientHistoryId,
                        principalTable: "PatientHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "62d198a8-c9f5-4573-90bb-59fd1f0fc610", "Admin", "ADMIN" },
                    { 2, "5f9c8ad6-3a8d-44d1-9646-26a60a54c728", "Doctor", "DOCTOR" },
                    { 3, "6b0c33df-5af2-4646-8140-253267bc428e", "Secretary", "SECRETARY" },
                    { 4, "277e5e95-9462-43e8-8fee-b6a61d8d0996", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1955, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c97ae8e4-3e15-41f8-ab54-489a75dfea1d", "admin@admin.com", true, "Admin", "Admin Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "admin@admin.com", "AQAAAAEAACcQAAAAEKuldFOnq1DcJJpYb0vjhfY0nnm8MOZDLwp99Glz1yc8yAXXi1jt/3kTTdLDch0XuQ==", "5325321234", false, "62c20112-95f3-437c-8d55-056f94a52f19", false, "admin@admin.com" },
                    { 2, 0, new DateTime(1955, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d23e9d01-19d1-44db-8ed2-2942354e55c5", "doctor@doctor.com", true, "Rıfat", "Rıfat Yaşar", "Yaşar", false, null, "DOCTOR@DOCTOR.COM", "doctor@doctor.com", "AQAAAAEAACcQAAAAEB8PxSBrpaFBEcsABzSkqRm2Pl38YOD521KvzC0GIEpSaDSwXWws08jIZMGdKkdF+A==", "5325321234", false, "d698a526-4d45-40fa-9f0e-923ae5fc6f32", false, "doctor@doctor.com" },
                    { 3, 0, new DateTime(1955, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "64d76579-17ad-4670-8fe9-9958825d52f0", "secretary@secretary.com", true, "Ayşe", "Ayşe Gül", "Gül", false, null, "SECRETARY@SECRETARY.COM", "secretary@secretary.com", "AQAAAAEAACcQAAAAEPhXul/SlRcgMCxM3O4dCTGmxpn2T9F7bRyNmIo/QCPgtyuqsEH/8wbF+c+EP2OXDw==", "5325321234", false, "fcdb72ea-70b4-410e-ac69-ee8ae0d9b7e5", false, "secretary@secretary.com" },
                    { 4, 0, new DateTime(1955, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e44c7819-9fcb-469a-94fe-6371b757f1aa", "patient@patient.com", true, "Osman", "Osman Oduncu", "Oduncu", false, null, "PATIENT@PATIENT.COM", "patient@patient.com", "AQAAAAEAACcQAAAAEKMFIw7ak/OzLCQHtoCnVLhk59+eiDYV3DTERYjMiELrGZZFwDwRAMInFs5uPM2wAg==", "5325321234", false, "e1da9726-a14e-4b80-bcae-fb9b4fdbb381", false, "patient@patient.com" }
                });

            migrationBuilder.InsertData(
                table: "Diseas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Yumuşak Doku Enfeksiyonu " },
                    { 8, "Akut Gastroenterit" },
                    { 7, "Alt Solunum Yolu Enfeksiyonu" },
                    { 6, "Üst Solunum Yolu Enfeksiyonu" },
                    { 2, "Hipertansiyon" },
                    { 4, "Akut Romatizmal Ateş" },
                    { 3, "Hiperlipidemi " },
                    { 1, "COVID-19" },
                    { 5, "Multiple Skleroz" }
                });

            migrationBuilder.InsertData(
                table: "Medication",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "SUPRAX SUSPANSIYON 50 ML." },
                    { 8, "SUPRAX 400 MG" },
                    { 5, "MACROL 250 MG 100 ML SUSPANSIYON" },
                    { 6, "NİDAZOL 500 MG FİLM TABLET" },
                    { 3, "DUOCİD ORAL SÜSPANSİYON 250MG/5ML 100ML" },
                    { 2, "BACTRİM 200/40 MG 100 ML SÜSPANSİYON" },
                    { 1, "AZOSİLİN 30 TB" },
                    { 4, "DEPOSİLİN 1.2 IU FLK" }
                });

            migrationBuilder.InsertData(
                table: "Polyclinic",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 18, "Psikoloji Servisi" },
                    { 17, "Patoloji Servisi" },
                    { 16, "Ortopedi ve Travmatoloji Servisi" },
                    { 15, "Nöroşirüji Servisi" },
                    { 14, "Nöroloji Servisi" },
                    { 13, "Kulak Burun Boğaz Servisi" },
                    { 12, "Kardiyoloji Servisi" },
                    { 11, "Kadın Hastalıkları ve Doğum Servisi" },
                    { 10, "Göz Servisi" },
                    { 8, "Genel Cerrahi Servisi" },
                    { 7, "Fizik Tedavi Servisi" },
                    { 6, "Dahiliye Servisi" },
                    { 5, "Çocuk Servisi" },
                    { 4, "Cilt Hastalıkları Servisi" },
                    { 3, "Beslenme ve Diyet Bölümü" },
                    { 2, "Anestezi ve Reanimasyon Servisi" },
                    { 1, "Ağız ve Diş Sağlığı Servisi" },
                    { 19, "Radyoloji Servisi" },
                    { 9, "Göğüs Hastalıkları Servisi" },
                    { 20, "Üroloji Servisi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "PolyclinicId", "UserId" },
                values: new object[] { 1, 9, 2 });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "Secretary",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PolyclinicId",
                table: "Doctor",
                column: "PolyclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_UserId",
                table: "Doctor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserId",
                table: "Patient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_DiseasId",
                table: "PatientHistory",
                column: "DiseasId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_DoctorId",
                table: "PatientHistory",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_PolyclinicId",
                table: "PatientHistory",
                column: "PolyclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistory_ReservationId",
                table: "PatientHistory",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistoryMedication_MedicationId",
                table: "PatientHistoryMedication",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistoryMedication_PatientHistoryId",
                table: "PatientHistoryMedication",
                column: "PatientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_DoctorId",
                table: "Reservation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PatientId",
                table: "Reservation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PolyclinicId",
                table: "Reservation",
                column: "PolyclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretary_UserId",
                table: "Secretary",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PatientHistoryMedication");

            migrationBuilder.DropTable(
                name: "Secretary");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "PatientHistory");

            migrationBuilder.DropTable(
                name: "Diseas");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Polyclinic");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
