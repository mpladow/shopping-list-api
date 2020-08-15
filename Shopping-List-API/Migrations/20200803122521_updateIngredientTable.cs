using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class updateIngredientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "rcp",
                table: "Ingredient",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "rcp",
                table: "Ingredient",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
