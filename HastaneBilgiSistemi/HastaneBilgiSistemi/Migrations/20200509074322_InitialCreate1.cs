using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneBilgiSistemi.Migrations
{
    public partial class InitialCreate1 : Migration
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
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_AspNetUsers_UserId",
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
                    PolicylinicId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    PolyclinicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservation_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservation_Polyclinic_PolyclinicId",
                        column: x => x.PolyclinicId,
                        principalTable: "Polyclinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    DiseasId = table.Column<int>(nullable: false),
                    PolyclinicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientHistory_Diseas_DiseasId",
                        column: x => x.DiseasId,
                        principalTable: "Diseas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientHistory_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientHistory_Polyclinic_PolyclinicId",
                        column: x => x.PolyclinicId,
                        principalTable: "Polyclinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientHistory_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ClientHistoryMedication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientHistoryId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientHistoryMedication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientHistoryMedication_ClientHistory_ClientHistoryId",
                        column: x => x.ClientHistoryId,
                        principalTable: "ClientHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClientHistoryMedication_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "32b21c1d-db07-47f6-9dc3-605a6ac57290", "Admin", "ADMIN" },
                    { 2, "886935fb-8c0a-4bac-9c58-0dc382bceca5", "Doctor", "DOCTOR" },
                    { 3, "a119ae79-0f6e-4fe5-9bbb-62a5d05645f0", "Secretary", "SECRETARY" },
                    { 4, "cce3673c-4385-4b17-920e-35a17ce0c8ba", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "36c3656a-4881-412c-a1ac-e6f455e7ba11", "admin@admin.com", true, null, null, null, false, null, null, "admin@admin.com", "AQAAAAEAACcQAAAAEINxeHAWrQpO8BImS42w4eeTqO3dPb8NsbIBvBtW47KUMdMljIDmvXIRGfkGX2CL1A==", "+905325321234", false, null, false, "admin@admin.com" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50719b97-64df-4f06-a13b-ad0ae899d659", "doctor@doctor.com", true, null, null, null, false, null, null, "doctor@doctor.com", "AQAAAAEAACcQAAAAEKtCFortBC7H/zwj5nNFtM+bvojfeWBorWvojM2LwombEzhMvObtvPLYS34rm0RCkw==", "+905325321234", false, null, false, "doctor@doctor.com" },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1934d749-16e5-46d9-a8b7-7aab1e212ca7", "secretary@secretary.com", true, null, null, null, false, null, null, "secretary@secretary.com", "AQAAAAEAACcQAAAAEAtncvoAoEhf2tjQyeCwZE7zG73xiswr/mK13pK57g6a25wLpW37rfVO+d55DBIGlA==", "+905325321234", false, null, false, "secretary@secretary.com" },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02703ba2-fe70-484b-9a6c-0bb9a90c240b", "client@client.com", true, null, null, null, false, null, null, "client@client.com", "AQAAAAEAACcQAAAAEHWh2lHYAh91MhFUr5XrLKdixqgooUR+3gqRxuOWCRAPYIcwUmwkVCyPe0oU1wiySA==", "+905325321234", false, null, false, "client@client.com" }
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
                table: "Client",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "PolyclinicId", "UserId" },
                values: new object[] { 1, 9, 2 });

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
                name: "IX_Client_UserId",
                table: "Client",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_DiseasId",
                table: "ClientHistory",
                column: "DiseasId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_DoctorId",
                table: "ClientHistory",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_PolyclinicId",
                table: "ClientHistory",
                column: "PolyclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_ReservationId",
                table: "ClientHistory",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistoryMedication_ClientHistoryId",
                table: "ClientHistoryMedication",
                column: "ClientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistoryMedication_MedicationId",
                table: "ClientHistoryMedication",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PolyclinicId",
                table: "Doctor",
                column: "PolyclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_UserId",
                table: "Doctor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_DoctorId",
                table: "Reservation",
                column: "DoctorId");

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
                name: "ClientHistoryMedication");

            migrationBuilder.DropTable(
                name: "Secretary");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ClientHistory");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Diseas");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Polyclinic");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
