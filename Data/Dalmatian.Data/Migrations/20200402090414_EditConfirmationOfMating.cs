using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class EditConfirmationOfMating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherDogId",
                table: "ConfirmationOfMatings");

            migrationBuilder.DropColumn(
                name: "MotherDogId",
                table: "ConfirmationOfMatings");

            migrationBuilder.AlterColumn<int>(
                name: "DogMotherId",
                table: "ConfirmationOfMatings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DogFatherId",
                table: "ConfirmationOfMatings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DogMotherId",
                table: "ConfirmationOfMatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DogFatherId",
                table: "ConfirmationOfMatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FatherDogId",
                table: "ConfirmationOfMatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotherDogId",
                table: "ConfirmationOfMatings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
