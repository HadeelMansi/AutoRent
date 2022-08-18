using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "CarBookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_applicationUserId",
                table: "CarBookings",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookings_AspNetUsers_applicationUserId",
                table: "CarBookings",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookings_AspNetUsers_applicationUserId",
                table: "CarBookings");

            migrationBuilder.DropIndex(
                name: "IX_CarBookings_applicationUserId",
                table: "CarBookings");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "CarBookings");
        }
    }
}
