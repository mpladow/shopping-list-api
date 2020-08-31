using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class addedRecipeIdToMethodItemandINgredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                schema: "rcp",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_MethodItem_Recipe_RecipeId",
                schema: "rcp",
                table: "MethodItem");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                schema: "rcp",
                table: "MethodItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                schema: "rcp",
                table: "Ingredient",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                schema: "rcp",
                table: "Ingredient",
                column: "RecipeId",
                principalSchema: "rcp",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MethodItem_Recipe_RecipeId",
                schema: "rcp",
                table: "MethodItem",
                column: "RecipeId",
                principalSchema: "rcp",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                schema: "rcp",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_MethodItem_Recipe_RecipeId",
                schema: "rcp",
                table: "MethodItem");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                schema: "rcp",
                table: "MethodItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                schema: "rcp",
                table: "Ingredient",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                schema: "rcp",
                table: "Ingredient",
                column: "RecipeId",
                principalSchema: "rcp",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MethodItem_Recipe_RecipeId",
                schema: "rcp",
                table: "MethodItem",
                column: "RecipeId",
                principalSchema: "rcp",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
