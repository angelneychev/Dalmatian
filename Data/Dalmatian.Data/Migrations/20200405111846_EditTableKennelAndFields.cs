using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class EditTableKennelAndFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Peoples_PeopleId",
                table: "Kennels");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_PeopleId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "PeopleId",
                table: "Kennels");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfRegistration",
                table: "Kennels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PeopleCoOwnerId",
                table: "Kennels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeopleOwnerId",
                table: "Kennels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_PeopleCoOwnerId",
                table: "Kennels",
                column: "PeopleCoOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_PeopleOwnerId",
                table: "Kennels",
                column: "PeopleOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Peoples_PeopleCoOwnerId",
                table: "Kennels",
                column: "PeopleCoOwnerId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Peoples_PeopleOwnerId",
                table: "Kennels",
                column: "PeopleOwnerId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Peoples_PeopleCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Peoples_PeopleOwnerId",
                table: "Kennels");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_PeopleCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_PeopleOwnerId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "DateOfRegistration",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "PeopleCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "PeopleOwnerId",
                table: "Kennels");

            migrationBuilder.AddColumn<int>(
                name: "PeopleId",
                table: "Kennels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_PeopleId",
                table: "Kennels",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Peoples_PeopleId",
                table: "Kennels",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
