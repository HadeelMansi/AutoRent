using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCategories_carCategoryCategoryId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarVendors_carVendorVendorId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_carCategoryCategoryId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_carVendorVendorId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "carCategoryCategoryId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "carVendorVendorId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VendorId",
                table: "Cars",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCategories_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "CarCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarVendors_VendorId",
                table: "Cars",
                column: "VendorId",
                principalTable: "CarVendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCategories_CategoryId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarVendors_VendorId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_VendorId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "carCategoryCategoryId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "carVendorVendorId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_carCategoryCategoryId",
                table: "Cars",
                column: "carCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_carVendorVendorId",
                table: "Cars",
                column: "carVendorVendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCategories_carCategoryCategoryId",
                table: "Cars",
                column: "carCategoryCategoryId",
                principalTable: "CarCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarVendors_carVendorVendorId",
                table: "Cars",
                column: "carVendorVendorId",
                principalTable: "CarVendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
