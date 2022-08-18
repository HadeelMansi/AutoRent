using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookings_Cities_CityId",
                table: "CarBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarBookings_CityId",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "CarBookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "CarBookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_CityId",
                table: "CarBookings",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookings_Cities_CityId",
                table: "CarBookings",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
