using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class EditDataModelDogKennelAddBreade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Users_UserId",
                table: "Kennels");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Persons_PersonId",
                table: "Litters");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_UserId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Kennels");

            migrationBuilder.AddColumn<int>(
                name: "DogId1",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreederId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Breeder",
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
                    KennelId = table.Column<int>(nullable: true),
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
                    table.PrimaryKey("PK_Breeder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeder_Kennels_KennelId",
                        column: x => x.KennelId,
                        principalTable: "Kennels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Breeder_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parents_DogId1",
                table: "Parents",
                column: "DogId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BreederId",
                table: "AspNetUsers",
                column: "BreederId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeder_IsDeleted",
                table: "Breeder",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Breeder_KennelId",
                table: "Breeder",
                column: "KennelId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeder_UserId",
                table: "Breeder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Breeder_BreederId",
                table: "AspNetUsers",
                column: "BreederId",
                principalTable: "Breeder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Breeder_PersonId",
                table: "Litters",
                column: "PersonId",
                principalTable: "Breeder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Dogs_DogId1",
                table: "Parents",
                column: "DogId1",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Breeder_BreederId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Breeder_PersonId",
                table: "Litters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Dogs_DogId1",
                table: "Parents");

            migrationBuilder.DropTable(
                name: "Breeder");

            migrationBuilder.DropIndex(
                name: "IX_Parents_DogId1",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BreederId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DogId1",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "BreederId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Breed",
                table: "Kennels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Kennels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Kennels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_UserId",
                table: "Kennels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IsDeleted",
                table: "Persons",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Users_UserId",
                table: "Kennels",
                column: "UserId",
                principalTable: "Users",
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
    }
}
