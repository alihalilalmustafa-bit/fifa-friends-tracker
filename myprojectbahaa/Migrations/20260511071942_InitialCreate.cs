using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myprojectbahaa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Wins = table.Column<int>(type: "INTEGER", nullable: false),
                    Losses = table.Column<int>(type: "INTEGER", nullable: false),
                    Draws = table.Column<int>(type: "INTEGER", nullable: false),
                    GoalsScored = table.Column<int>(type: "INTEGER", nullable: false),
                    GoalsConceded = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Player1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Player2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Score1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Score2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Draws", "GoalsConceded", "GoalsScored", "Losses", "Name", "Username", "Wins" },
                values: new object[,]
                {
                    { 1, 2, 18, 38, 3, "Ahmed Al-Rashid", "AhmedR", 12 },
                    { 2, 2, 24, 29, 6, "Omar Khalid", "OmarK", 9 },
                    { 3, 3, 27, 25, 7, "Yusuf Demir", "YusufD", 7 },
                    { 4, 2, 33, 19, 10, "Tariq Hassan", "TariqH", 5 },
                    { 5, 2, 36, 15, 11, "Bilal Sahin", "BilalS", 4 }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Date", "Player1Id", "Player2Id", "Score1", "Score2" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 1 },
                    { 2, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 2, 0 },
                    { 3, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 4, 2 },
                    { 4, new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 1, 1 },
                    { 5, new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 5, 0 },
                    { 6, new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 3, 2 },
                    { 7, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 2, 1 },
                    { 8, new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player1Id",
                table: "Matches",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player2Id",
                table: "Matches",
                column: "Player2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
