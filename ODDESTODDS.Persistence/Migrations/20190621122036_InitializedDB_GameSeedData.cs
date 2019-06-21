using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ODDESTODDS.Persistence.Migrations
{
    public partial class InitializedDB_GameSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    HomeTeam = table.Column<string>(maxLength: 120, nullable: false),
                    AwayTeam = table.Column<string>(maxLength: 120, nullable: false),
                    GameStartTime = table.Column<DateTime>(nullable: false),
                    GameStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameOdd",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    HomeOdd = table.Column<double>(nullable: false),
                    AwayOdd = table.Column<double>(nullable: false),
                    DrawOdd = table.Column<double>(nullable: false),
                    OddStatus = table.Column<int>(nullable: false),
                    GameInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOdd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameOdd_GameInfo_GameInfoId",
                        column: x => x.GameInfoId,
                        principalTable: "GameInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameInfo",
                columns: new[] { "Id", "AwayTeam", "CreateBy", "CreatedDate", "GameStartTime", "GameStatus", "HomeTeam", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { 1L, "France U21", null, null, new DateTime(2019, 6, 21, 13, 20, 36, 223, DateTimeKind.Local), 1, "England U21", false, null, null });

            migrationBuilder.InsertData(
                table: "GameInfo",
                columns: new[] { "Id", "AwayTeam", "CreateBy", "CreatedDate", "GameStartTime", "GameStatus", "HomeTeam", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { 2L, "Germany U21", null, null, new DateTime(2019, 6, 21, 13, 20, 36, 228, DateTimeKind.Local), 1, "USA U21", false, null, null });

            migrationBuilder.InsertData(
                table: "GameInfo",
                columns: new[] { "Id", "AwayTeam", "CreateBy", "CreatedDate", "GameStartTime", "GameStatus", "HomeTeam", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[] { 3L, "England  U21", null, null, new DateTime(2019, 6, 21, 13, 20, 36, 228, DateTimeKind.Local), 1, "Denmark  U21", false, null, null });

            migrationBuilder.InsertData(
                table: "GameOdd",
                columns: new[] { "Id", "AwayOdd", "CreateBy", "CreatedDate", "DrawOdd", "GameInfoId", "HomeOdd", "IsDeleted", "ModifiedBy", "ModifiedDate", "OddStatus" },
                values: new object[] { 1L, 3.0, null, new DateTime(2019, 6, 21, 13, 20, 36, 257, DateTimeKind.Local), 14.7, 1L, 5.9, false, null, null, 1 });

            migrationBuilder.InsertData(
                table: "GameOdd",
                columns: new[] { "Id", "AwayOdd", "CreateBy", "CreatedDate", "DrawOdd", "GameInfoId", "HomeOdd", "IsDeleted", "ModifiedBy", "ModifiedDate", "OddStatus" },
                values: new object[] { 2L, 3.0, null, new DateTime(2019, 6, 21, 13, 20, 36, 257, DateTimeKind.Local), 14.7, 2L, 5.9, false, null, null, 1 });

            migrationBuilder.InsertData(
                table: "GameOdd",
                columns: new[] { "Id", "AwayOdd", "CreateBy", "CreatedDate", "DrawOdd", "GameInfoId", "HomeOdd", "IsDeleted", "ModifiedBy", "ModifiedDate", "OddStatus" },
                values: new object[] { 3L, 3.0, null, new DateTime(2019, 6, 21, 13, 20, 36, 257, DateTimeKind.Local), 14.7, 3L, 5.9, false, null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_GameOdd_GameInfoId",
                table: "GameOdd",
                column: "GameInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameOdd");

            migrationBuilder.DropTable(
                name: "GameInfo");
        }
    }
}
