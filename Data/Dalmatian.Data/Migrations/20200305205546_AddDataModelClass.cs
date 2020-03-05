using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class AddDataModelClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Parents_ParentId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_ParentId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Dogs");

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Parents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FatherDogId",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherDogId",
                table: "Parents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_DogId",
                table: "Parents",
                column: "DogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Dogs_DogId",
                table: "Parents",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Dogs_DogId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_DogId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "FatherDogId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "MotherDogId",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "Parents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "Parents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ParentId",
                table: "Dogs",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Parents_ParentId",
                table: "Dogs",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
