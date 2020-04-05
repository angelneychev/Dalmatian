using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class RenameTablePeopleToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Peoples_PeopleCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Peoples_PeopleOwnerId",
                table: "Kennels");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Peoples_BreederId",
                table: "Litters");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Litters_BreederId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_PeopleCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_PeopleOwnerId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "BreederId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "PeopleCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "PeopleOwnerId",
                table: "Kennels");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Litters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonCoOwnerId",
                table: "Kennels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonOwnerId",
                table: "Kennels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Persons",
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
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Litters_PersonId",
                table: "Litters",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_PersonCoOwnerId",
                table: "Kennels",
                column: "PersonCoOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_PersonOwnerId",
                table: "Kennels",
                column: "PersonOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IsDeleted",
                table: "Persons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Persons_PersonCoOwnerId",
                table: "Kennels",
                column: "PersonCoOwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Persons_PersonOwnerId",
                table: "Kennels",
                column: "PersonOwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Persons_PersonId",
                table: "Litters",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Persons_PersonCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Persons_PersonOwnerId",
                table: "Kennels");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Persons_PersonId",
                table: "Litters");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Litters_PersonId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_PersonCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_PersonOwnerId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "PersonCoOwnerId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "PersonOwnerId",
                table: "Kennels");

            migrationBuilder.AddColumn<int>(
                name: "BreederId",
                table: "Litters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeopleCoOwnerId",
                table: "Kennels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeopleOwnerId",
                table: "Kennels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Peoples",
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
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peoples_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Litters_BreederId",
                table: "Litters",
                column: "BreederId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_PeopleCoOwnerId",
                table: "Kennels",
                column: "PeopleCoOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_PeopleOwnerId",
                table: "Kennels",
                column: "PeopleOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_IsDeleted",
                table: "Peoples",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_UserId",
                table: "Peoples",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Peoples_BreederId",
                table: "Litters",
                column: "BreederId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
