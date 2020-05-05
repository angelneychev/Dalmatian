namespace Dalmatian.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CreateBirthCertificateDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Litters_ConfirmationOfMatings_ConfirmationOfMatingId",
                table: "Litters");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Persons_PersonId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_ConfirmationOfMatingId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_PersonId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "ConfirmationOfMatingId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "LetterOfLitter",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "NumberOfFemales",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "NumberOfMales",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "NumberOfPuppies",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Litters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmationOfMatingId",
                table: "Litters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Litters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LetterOfLitter",
                table: "Litters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFemales",
                table: "Litters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMales",
                table: "Litters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPuppies",
                table: "Litters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Litters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Litters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Litters_ConfirmationOfMatingId",
                table: "Litters",
                column: "ConfirmationOfMatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_PersonId",
                table: "Litters",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_ConfirmationOfMatings_ConfirmationOfMatingId",
                table: "Litters",
                column: "ConfirmationOfMatingId",
                principalTable: "ConfirmationOfMatings",
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
