using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class EditDataModelLitterKennelBreader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Breeder_BreederId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Kennels_KennelId",
                table: "Litters");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Breeder_PersonId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_KennelId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_PersonId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BreederId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KennelId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "BreederId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BreederId",
                table: "Litters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Litters_BreederId",
                table: "Litters",
                column: "BreederId");

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Breeder_BreederId",
                table: "Litters",
                column: "BreederId",
                principalTable: "Breeder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Breeder_BreederId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_BreederId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "BreederId",
                table: "Litters");

            migrationBuilder.AddColumn<int>(
                name: "KennelId",
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

            migrationBuilder.AddColumn<int>(
                name: "BreederId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Litters_KennelId",
                table: "Litters",
                column: "KennelId");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_PersonId",
                table: "Litters",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BreederId",
                table: "AspNetUsers",
                column: "BreederId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Breeder_BreederId",
                table: "AspNetUsers",
                column: "BreederId",
                principalTable: "Breeder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Kennels_KennelId",
                table: "Litters",
                column: "KennelId",
                principalTable: "Kennels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Breeder_PersonId",
                table: "Litters",
                column: "PersonId",
                principalTable: "Breeder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
