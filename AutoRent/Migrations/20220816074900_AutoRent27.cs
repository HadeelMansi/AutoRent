using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_PickupCityId",
                table: "CarBookings",
                column: "PickupCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookings_Cities_PickupCityId",
                table: "CarBookings",
                column: "PickupCityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookings_Cities_PickupCityId",
                table: "CarBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarBookings_PickupCityId",
                table: "CarBookings");
        }
    }
}
