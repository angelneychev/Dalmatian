using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class addTableBirthCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirthCertificates",
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
                    PersonId = table.Column<int>(nullable: false),
                    KennelId = table.Column<int>(nullable: false),
                    LetterOfLitter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirthCertificates_ConfirmationOfMatings_ConfirmationOfMatingId",
                        column: x => x.ConfirmationOfMatingId,
                        principalTable: "ConfirmationOfMatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BirthCertificates_Kennels_KennelId",
                        column: x => x.KennelId,
                        principalTable: "Kennels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BirthCertificates_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificates_ConfirmationOfMatingId",
                table: "BirthCertificates",
                column: "ConfirmationOfMatingId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificates_IsDeleted",
                table: "BirthCertificates",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificates_KennelId",
                table: "BirthCertificates",
                column: "KennelId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificates_PersonId",
                table: "BirthCertificates",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthCertificates");
        }
    }
}
