using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class UpdateKennel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Kennels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Kennels");
        }
    }
}
