using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneBilgiSistemi.Data.Migrations
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
                        onDelete: ReferentialAction.NoAction);
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
                    { 1, "2f52647a-cd53-4ba6-a6cb-f97cfbf1e55b", "Admin", "ADMIN" },
                    { 2, "7ebd6197-665e-4222-95c0-e4d873a44573", "Doctor", "DOCTOR" },
                    { 3, "8273e391-bf4e-4128-acfa-4adf9639accb", "Secretary", "SECRETARY" },
                    { 4, "2f62f716-e2cd-4a4c-996f-8dde36458e1a", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c0ded3e3-ea17-429f-94eb-2389bd41e9b3", "admin@admin.com", true, null, null, null, false, null, "ADMIN@ADMIN.COM", "admin@admin.com", "AQAAAAEAACcQAAAAEP3bfSICN/Kl3+5evuNXkxWxCi7KjJWqiF6bT/L+X97x3TIBO3lAuL4zt5Atg6Jjgg==", "+905325321234", false, "83b61377-ea64-4194-877a-e20c1551eef3", false, "admin@admin.com" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c46c35af-7d2f-4cb3-af99-2fbef1fadf0f", "doctor@doctor.com", true, null, null, null, false, null, "DOCTOR@DOCTOR.COM", "doctor@doctor.com", "AQAAAAEAACcQAAAAEA5v2ySwGddpDQOAixPuqKundeUldHTcZnqwE+YZdND05tO9nX8xJZWitrYwIkAZfA==", "+905325321234", false, "e069e883-ac60-4a39-b3ca-7bc436a7945b", false, "doctor@doctor.com" },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7cf1bb6e-003d-476a-9766-1dc4eb30362b", "secretary@secretary.com", true, null, null, null, false, null, "SECRETARY@SECRETARY.COM", "secretary@secretary.com", "AQAAAAEAACcQAAAAEJ5mgRPscpYQ08JulTNQnC2eAqaYGQVRaJ/Ov/CCo/Z8qnu0A0TsdfmSIX0I5GrU5w==", "+905325321234", false, "294abf75-e107-4d3b-a074-682dd7b92c96", false, "secretary@secretary.com" },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fb486bca-5632-46e5-bf4b-ed107967c005", "client@client.com", true, null, null, null, false, null, "CLIENT@CLIENT.COM", "client@client.com", "AQAAAAEAACcQAAAAEF3KK6i7DlQIQORha+/xycWd9nTaHrpNMbugLBYSxlhwYpzgKcrK8uCcX8wxHbjduQ==", "+905325321234", false, "411b86cc-e714-4f32-b381-8e4a4f3ba005", false, "client@client.com" }
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
