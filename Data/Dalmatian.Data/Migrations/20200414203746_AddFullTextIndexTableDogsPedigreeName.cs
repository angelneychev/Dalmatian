using Microsoft.EntityFrameworkCore.Migrations;

namespace Dalmatian.Data.Migrations
{
    public partial class AddFullTextIndexTableDogsPedigreeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE FULLTEXT CATALOG PedigreeName
                  GO
                  CREATE FULLTEXT INDEX ON Dogs
                   (
                    Title
                       Language 1033,
                    Content
                       Language 1033
                   )
                  KEY INDEX PK_Dogs
                  ON
                  PedigreeNameFullTextIndex
                  ",
                true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP FULLTEXT INDEX ON Dogs
                  DROP FULLTEXT CATALOG PedigreeNameFullTextIndex",
                true);
        }
    }
}
