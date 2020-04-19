using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class AddFullTextIndexTableDogsPedigreeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(
            //    @"CREATE FULLTEXT CATALOG DogPedigreeName
            //      GO
            //      CREATE FULLTEXT INDEX ON Dogs
            //       (
            //        PedigreeName
            //           Language 1033
            //       )
            //      KEY INDEX PK_Dogs
            //      ON
            //      DogPedigreeName
            //      ",
            //    true);
        }// BG Language 1026

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(
            //    @"DROP FULLTEXT INDEX ON Dogs
            //      DROP FULLTEXT CATALOG DogPedigreeName",
            //    true);
        }
    }
}
