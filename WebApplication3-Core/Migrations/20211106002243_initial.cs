using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3_Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteSearches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromStationId = table.Column<int>(type: "int", nullable: true),
                    ToStationId = table.Column<int>(type: "int", nullable: true),
                    DateSearched = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteSearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteSearches_Stations_FromStationId",
                        column: x => x.FromStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteSearches_Stations_ToStationId",
                        column: x => x.ToStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StationLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubwayLine = table.Column<int>(type: "int", nullable: false),
                    Fare = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    FromStationId = table.Column<int>(type: "int", nullable: false),
                    ToStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationLinks_Stations_FromStationId",
                        column: x => x.FromStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationLinks_Stations_ToStationId",
                        column: x => x.ToStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Zero", "Zero" },
                    { 2, "One", "One" },
                    { 3, "Two", "Two" },
                    { 4, "Three", "Three" },
                    { 5, "Four", "Four" },
                    { 6, "Five", "Five" },
                    { 7, "Six", "Six" },
                    { 8, "Seven", "Seven" },
                    { 9, "Eight", "Eight" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteSearches_FromStationId",
                table: "RouteSearches",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteSearches_ToStationId",
                table: "RouteSearches",
                column: "ToStationId");

            migrationBuilder.CreateIndex(
                name: "IX_StationLinks_FromStationId",
                table: "StationLinks",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_StationLinks_ToStationId",
                table: "StationLinks",
                column: "ToStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteSearches");

            migrationBuilder.DropTable(
                name: "StationLinks");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
