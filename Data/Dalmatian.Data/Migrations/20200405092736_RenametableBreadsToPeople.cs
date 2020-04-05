using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class RenametableBreadsToPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Breeders_BreederId",
                table: "Kennels");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Breeders_BreederId",
                table: "Litters");

            migrationBuilder.DropTable(
                name: "Breeders");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_BreederId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "BreederId",
                table: "Kennels");

            migrationBuilder.AddColumn<int>(
                name: "PeopleId",
                table: "Kennels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Middlename = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peoples_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_PeopleId",
                table: "Kennels",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_IsDeleted",
                table: "Peoples",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_UserId",
                table: "Peoples",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Peoples_PeopleId",
                table: "Kennels",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Peoples_BreederId",
                table: "Litters",
                column: "BreederId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Peoples_PeopleId",
                table: "Kennels");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Peoples_BreederId",
                table: "Litters");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_PeopleId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "PeopleId",
                table: "Kennels");

            migrationBuilder.AddColumn<int>(
                name: "BreederId",
                table: "Kennels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Breeders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_BreederId",
                table: "Kennels",
                column: "BreederId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeders_IsDeleted",
                table: "Breeders",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Breeders_UserId",
                table: "Breeders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Breeders_BreederId",
                table: "Kennels",
                column: "BreederId",
                principalTable: "Breeders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Breeders_BreederId",
                table: "Litters",
                column: "BreederId",
                principalTable: "Breeders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
