using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarReviews_CarId",
                table: "CarReviews",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReviews_Cars_CarId",
                table: "CarReviews",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReviews_Cars_CarId",
                table: "CarReviews");

            migrationBuilder.DropIndex(
                name: "IX_CarReviews_CarId",
                table: "CarReviews");
        }
    }
}
