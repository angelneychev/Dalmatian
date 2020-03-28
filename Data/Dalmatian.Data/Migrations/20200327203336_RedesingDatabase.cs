using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class RedesingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBaer",
                table: "HealthInformations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfElbowRating",
                table: "HealthInformations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfHealthTest",
                table: "HealthInformations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfClubRegister",
                table: "ClubRegisterNumbers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBaer",
                table: "HealthInformations");

            migrationBuilder.DropColumn(
                name: "DateOfElbowRating",
                table: "HealthInformations");

            migrationBuilder.DropColumn(
                name: "DateOfHealthTest",
                table: "HealthInformations");

            migrationBuilder.DropColumn(
                name: "DateOfClubRegister",
                table: "ClubRegisterNumbers");
        }
    }
}
