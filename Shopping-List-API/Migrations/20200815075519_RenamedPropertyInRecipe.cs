using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class RenamedPropertyInRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionMain",
                schema: "rcp",
                table: "Recipe",
                newName: "DescriptionPrimary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionPrimary",
                schema: "rcp",
                table: "Recipe",
                newName: "DescriptionMain");
        }
    }
}
