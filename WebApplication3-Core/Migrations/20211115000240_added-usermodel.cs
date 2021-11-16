using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3_Core.Migrations
{
    public partial class addedusermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteSearches_Stations_FromStationId",
                table: "RouteSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteSearches_Stations_ToStationId",
                table: "RouteSearches");

            migrationBuilder.AlterColumn<int>(
                name: "ToStationId",
                table: "RouteSearches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromStationId",
                table: "RouteSearches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RouteSearches_Stations_FromStationId",
                table: "RouteSearches",
                column: "FromStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteSearches_Stations_ToStationId",
                table: "RouteSearches",
                column: "ToStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteSearches_Stations_FromStationId",
                table: "RouteSearches");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteSearches_Stations_ToStationId",
                table: "RouteSearches");

            migrationBuilder.DropTable(
                name: "UserCredentials");

            migrationBuilder.AlterColumn<int>(
                name: "ToStationId",
                table: "RouteSearches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FromStationId",
                table: "RouteSearches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteSearches_Stations_FromStationId",
                table: "RouteSearches",
                column: "FromStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteSearches_Stations_ToStationId",
                table: "RouteSearches",
                column: "ToStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
