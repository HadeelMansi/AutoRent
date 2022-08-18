using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookings_AspNetUsers_AppUserId1",
                table: "CarBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarBookings_AppUserId1",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "CarBookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "CarBookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_AppUserId1",
                table: "CarBookings",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookings_AspNetUsers_AppUserId1",
                table: "CarBookings",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
