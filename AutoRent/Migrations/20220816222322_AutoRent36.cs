using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRent.Migrations
{
    public partial class AutoRent36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarBookingBookingId",
                table: "CarReviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarBookingId",
                table: "CarReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarReviews_CarBookingBookingId",
                table: "CarReviews",
                column: "CarBookingBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReviews_CarBookings_CarBookingBookingId",
                table: "CarReviews",
                column: "CarBookingBookingId",
                principalTable: "CarBookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReviews_CarBookings_CarBookingBookingId",
                table: "CarReviews");

            migrationBuilder.DropIndex(
                name: "IX_CarReviews_CarBookingBookingId",
                table: "CarReviews");

            migrationBuilder.DropColumn(
                name: "CarBookingBookingId",
                table: "CarReviews");

            migrationBuilder.DropColumn(
                name: "CarBookingId",
                table: "CarReviews");
        }
    }
}
