using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JetStreamBackend.Migrations
{
    /// <inheritdoc />
    public partial class Initialcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE LOGIN [JetUser] WITH PASSWORD = 'JetStream';");
            migrationBuilder.Sql("USE [Jetstream];");
            migrationBuilder.Sql("CREATE USER [JetUser] FOR LOGIN [JetUser];");
            migrationBuilder.Sql("GRANT SELECT, INSERT, UPDATE, DELETE TO [JetUser];");

            migrationBuilder.CreateTable(
                name: "Mitarbeiter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Benutzername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Passwort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rolle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LetzteAnmeldung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoginVersuche = table.Column<int>(type: "int", nullable: false),
                    IstGesperrt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitarbeiter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAuftraege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAuftraege", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Mitarbeiter",
                columns: new[] { "Id", "Benutzername", "Email", "Erstellungsdatum", "IsActive", "IstGesperrt", "LetzteAnmeldung", "LoginVersuche", "Name", "Passwort", "Rolle", "Telefonnummer" },
                values: new object[,]
                {
                    { 1, "maxmuster", "max@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9635), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9704), 0, "Max Mustermann", "passwort123", "Administrator", "0123456789" },
                    { 2, "arda", "max@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9710), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9712), 0, "arda Mustermann", "passwort123", "Mitarbeiter", "0123456789" },
                    { 3, "tom", "tom@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9716), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9718), 0, "Tom Schmitz", "passwort123", "Mitarbeiter", "0123456791" },
                    { 4, "anna", "anna@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9722), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9724), 0, "Anna Schmidt", "passwort123", "Mitarbeiter", "0123456792" },
                    { 5, "jan", "jan@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9727), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9729), 0, "Jan Bauer", "passwort123", "Mitarbeiter", "0123456793" },
                    { 6, "sara", "sara@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9733), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9735), 0, "Sara Koch", "passwort123", "Mitarbeiter", "0123456794" },
                    { 7, "markus", "markus@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9739), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9740), 0, "Markus Weber", "passwort123", "Mitarbeiter", "0123456795" },
                    { 8, "julia", "julia@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9744), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9746), 0, "Julia Lange", "passwort123", "Mitarbeiter", "0123456796" },
                    { 9, "felix", "felix@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9749), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9751), 0, "Felix Klein", "passwort123", "Mitarbeiter", "0123456797" },
                    { 10, "sophie", "sophie@example.com", new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9754), true, false, new DateTime(2023, 11, 21, 19, 41, 31, 196, DateTimeKind.Local).AddTicks(9756), 0, "Sophie Groß", "passwort123", "Mitarbeiter", "0123456798" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mitarbeiter_Benutzername",
                table: "Mitarbeiter",
                column: "Benutzername",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("USE [Jetstream];");
            migrationBuilder.Sql("DROP USER IF EXISTS [JetUser];");
            migrationBuilder.Sql("DROP LOGIN IF EXISTS [JetUser];");

            migrationBuilder.DropTable(
                name: "Mitarbeiter");

            migrationBuilder.DropTable(
                name: "ServiceAuftraege");
        }
    }
}
