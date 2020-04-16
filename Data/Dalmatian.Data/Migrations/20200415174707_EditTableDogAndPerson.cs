using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class EditTableDogAndPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreederName",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Dogs");

            migrationBuilder.AddColumn<int>(
                name: "PersonBreederId",
                table: "Dogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonOwnerId",
                table: "Dogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_PersonBreederId",
                table: "Dogs",
                column: "PersonBreederId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_PersonOwnerId",
                table: "Dogs",
                column: "PersonOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Persons_PersonBreederId",
                table: "Dogs",
                column: "PersonBreederId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Persons_PersonOwnerId",
                table: "Dogs",
                column: "PersonOwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Persons_PersonBreederId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Persons_PersonOwnerId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_PersonBreederId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_PersonOwnerId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "PersonBreederId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "PersonOwnerId",
                table: "Dogs");

            migrationBuilder.AddColumn<string>(
                name: "BreederName",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
