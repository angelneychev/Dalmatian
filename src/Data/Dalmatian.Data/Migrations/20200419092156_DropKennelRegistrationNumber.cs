using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class DropKennelRegistrationNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KennelRegistrationNumbers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KennelRegistrationNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfKennelRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KennelRegistrationNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KennelRegistrationNumbers_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KennelRegistrationNumbers_DogId",
                table: "KennelRegistrationNumbers",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_KennelRegistrationNumbers_IsDeleted",
                table: "KennelRegistrationNumbers",
                column: "IsDeleted");
        }
    }
}
