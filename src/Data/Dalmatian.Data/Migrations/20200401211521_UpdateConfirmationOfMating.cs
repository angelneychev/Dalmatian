using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class UpdateConfirmationOfMating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmationOfMatings_Dogs_DogFemaleId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmationOfMatings_Dogs_DogMaleId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropIndex(
                name: "IX_ConfirmationOfMatings_DogFemaleId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropIndex(
                name: "IX_ConfirmationOfMatings_DogMaleId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "DogFemaleId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "DogMaleId",
                table: "ConfirmationOfMatings");

            migrationBuilder.AddColumn<int>(
                name: "DogFatherId",
                table: "ConfirmationOfMatings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DogMotherId",
                table: "ConfirmationOfMatings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FatherDogId",
                table: "ConfirmationOfMatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotherDogId",
                table: "ConfirmationOfMatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OwnerFemaleDog",
                table: "ConfirmationOfMatings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerMaleDog",
                table: "ConfirmationOfMatings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationOfMatings_DogFatherId",
                table: "ConfirmationOfMatings",
                column: "DogFatherId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationOfMatings_DogMotherId",
                table: "ConfirmationOfMatings",
                column: "DogMotherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmationOfMatings_Dogs_DogFatherId",
                table: "ConfirmationOfMatings",
                column: "DogFatherId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmationOfMatings_Dogs_DogMotherId",
                table: "ConfirmationOfMatings",
                column: "DogMotherId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmationOfMatings_Dogs_DogFatherId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmationOfMatings_Dogs_DogMotherId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropIndex(
                name: "IX_ConfirmationOfMatings_DogFatherId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropIndex(
                name: "IX_ConfirmationOfMatings_DogMotherId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "DogFatherId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "DogMotherId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "FatherDogId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "MotherDogId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "OwnerFemaleDog",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "OwnerMaleDog",
                table: "ConfirmationOfMatings");

            migrationBuilder.AddColumn<int>(
                name: "DogFemaleId",
                table: "ConfirmationOfMatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DogMaleId",
                table: "ConfirmationOfMatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationOfMatings_DogFemaleId",
                table: "ConfirmationOfMatings",
                column: "DogFemaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationOfMatings_DogMaleId",
                table: "ConfirmationOfMatings",
                column: "DogMaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmationOfMatings_Dogs_DogFemaleId",
                table: "ConfirmationOfMatings",
                column: "DogFemaleId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmationOfMatings_Dogs_DogMaleId",
                table: "ConfirmationOfMatings",
                column: "DogMaleId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
