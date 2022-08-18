using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "CarReviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarReviews_applicationUserId",
                table: "CarReviews",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReviews_AspNetUsers_applicationUserId",
                table: "CarReviews",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReviews_AspNetUsers_applicationUserId",
                table: "CarReviews");

            migrationBuilder.DropIndex(
                name: "IX_CarReviews_applicationUserId",
                table: "CarReviews");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "CarReviews");
        }
    }
}
