using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class addedPropertyToIngredientAndMEthodItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seperator",
                schema: "rcp",
                table: "MethodItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Seperator",
                schema: "rcp",
                table: "Ingredient",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seperator",
                schema: "rcp",
                table: "MethodItem");

            migrationBuilder.DropColumn(
                name: "Seperator",
                schema: "rcp",
                table: "Ingredient");
        }
    }
}
