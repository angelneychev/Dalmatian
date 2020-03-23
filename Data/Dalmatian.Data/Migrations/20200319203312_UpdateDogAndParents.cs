using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class UpdateDogAndParents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeders",
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
                    table.PrimaryKey("PK_Breeders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    PedigreeName = table.Column<string>(nullable: true),
                    Breed = table.Column<int>(nullable: false),
                    SexDog = table.Column<int>(nullable: false),
                    ImagesUrl = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    DateOfDeath = table.Column<DateTime>(nullable: true),
                    Color = table.Column<int>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    BreederName = table.Column<string>(nullable: true),
                    FatherDogId = table.Column<int>(nullable: true),
                    MotherDogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Dogs_FatherDogId",
                        column: x => x.FatherDogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dogs_Dogs_MotherDogId",
                        column: x => x.MotherDogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kennels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    BreederId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kennels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kennels_Breeders_BreederId",
                        column: x => x.BreederId,
                        principalTable: "Breeders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreedingInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    HeightUnits = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    WeightUnits = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    BreedingStatus = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<int>(nullable: false),
                    CountryOfResidence = table.Column<int>(nullable: false),
                    DogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedingInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedingInformations_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubRegisterNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DogId = table.Column<int>(nullable: false),
                    ClubNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubRegisterNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubRegisterNumbers_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmationOfMatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    DogMaleId = table.Column<int>(nullable: false),
                    DogFemaleId = table.Column<int>(nullable: false),
                    DateOfMating = table.Column<DateTime>(nullable: false),
                    TypeOfMating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationOfMatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmationOfMatings_Dogs_DogFemaleId",
                        column: x => x.DogFemaleId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfirmationOfMatings_Dogs_DogMaleId",
                        column: x => x.DogMaleId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Baer = table.Column<int>(nullable: false),
                    HipRating = table.Column<int>(nullable: false),
                    ElbowRating = table.Column<int>(nullable: false),
                    OtherHealthTest = table.Column<string>(nullable: true),
                    DogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthInformations_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationDogNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    DogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationDogNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationDogNumbers_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Litters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ConfirmationOfMatingId = table.Column<int>(nullable: false),
                    NumberOfPuppies = table.Column<int>(nullable: false),
                    NumberOfMales = table.Column<int>(nullable: false),
                    NumberOfFemales = table.Column<int>(nullable: false),
                    BreederId = table.Column<int>(nullable: false),
                    LetterOfLitter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Litters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Litters_Breeders_BreederId",
                        column: x => x.BreederId,
                        principalTable: "Breeders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Litters_ConfirmationOfMatings_ConfirmationOfMatingId",
                        column: x => x.ConfirmationOfMatingId,
                        principalTable: "ConfirmationOfMatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportOfLitters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    LitterId = table.Column<int>(nullable: false),
                    DogId = table.Column<int>(nullable: false),
                    BreederInCharge = table.Column<string>(nullable: true),
                    DateOfExamination = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportOfLitters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportOfLitters_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportOfLitters_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breeders_IsDeleted",
                table: "Breeders",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Breeders_UserId",
                table: "Breeders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingInformations_DogId",
                table: "BreedingInformations",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingInformations_IsDeleted",
                table: "BreedingInformations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ClubRegisterNumbers_DogId",
                table: "ClubRegisterNumbers",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubRegisterNumbers_IsDeleted",
                table: "ClubRegisterNumbers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationOfMatings_DogFemaleId",
                table: "ConfirmationOfMatings",
                column: "DogFemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationOfMatings_DogMaleId",
                table: "ConfirmationOfMatings",
                column: "DogMaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationOfMatings_IsDeleted",
                table: "ConfirmationOfMatings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_FatherDogId",
                table: "Dogs",
                column: "FatherDogId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_IsDeleted",
                table: "Dogs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_MotherDogId",
                table: "Dogs",
                column: "MotherDogId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformations_DogId",
                table: "HealthInformations",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformations_IsDeleted",
                table: "HealthInformations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_BreederId",
                table: "Kennels",
                column: "BreederId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_IsDeleted",
                table: "Kennels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_BreederId",
                table: "Litters",
                column: "BreederId");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_ConfirmationOfMatingId",
                table: "Litters",
                column: "ConfirmationOfMatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_IsDeleted",
                table: "Litters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_IsDeleted",
                table: "Parents",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationDogNumbers_DogId",
                table: "RegistrationDogNumbers",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationDogNumbers_IsDeleted",
                table: "RegistrationDogNumbers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReportOfLitters_DogId",
                table: "ReportOfLitters",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportOfLitters_IsDeleted",
                table: "ReportOfLitters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReportOfLitters_LitterId",
                table: "ReportOfLitters",
                column: "LitterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedingInformations");

            migrationBuilder.DropTable(
                name: "ClubRegisterNumbers");

            migrationBuilder.DropTable(
                name: "HealthInformations");

            migrationBuilder.DropTable(
                name: "Kennels");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "RegistrationDogNumbers");

            migrationBuilder.DropTable(
                name: "ReportOfLitters");

            migrationBuilder.DropTable(
                name: "Litters");

            migrationBuilder.DropTable(
                name: "Breeders");

            migrationBuilder.DropTable(
                name: "ConfirmationOfMatings");

            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
