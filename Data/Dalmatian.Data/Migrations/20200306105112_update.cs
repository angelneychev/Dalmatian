using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubRegisterNumbers_Dogs_DogId",
                table: "ClubRegisterNumbers");

            migrationBuilder.DropIndex(
                name: "IX_ClubRegisterNumbers_DogId",
                table: "ClubRegisterNumbers");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "ClubRegisterNumbers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "ClubRegisterNumbers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClubRegisterNumbers_DogId",
                table: "ClubRegisterNumbers",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubRegisterNumbers_Dogs_DogId",
                table: "ClubRegisterNumbers",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
