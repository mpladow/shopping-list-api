using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "rcp");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "rcp",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "rcp",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                schema: "rcp",
                columns: table => new
                {
                    RecipeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipe_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "rcp",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                schema: "rcp",
                columns: table => new
                {
                    IngredientId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<DateTime>(nullable: false),
                    Measure = table.Column<string>(nullable: true),
                    RecipeId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipe_RecipeId1",
                        column: x => x.RecipeId1,
                        principalSchema: "rcp",
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MethodItem",
                schema: "rcp",
                columns: table => new
                {
                    MethodItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<string>(nullable: true),
                    StepNo = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    RecipeId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodItem", x => x.MethodItemId);
                    table.ForeignKey(
                        name: "FK_MethodItem_Recipe_RecipeId1",
                        column: x => x.RecipeId1,
                        principalSchema: "rcp",
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId1",
                schema: "rcp",
                table: "Ingredient",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_MethodItem_RecipeId1",
                schema: "rcp",
                table: "MethodItem",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CategoryId",
                schema: "rcp",
                table: "Recipe",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "rcp");

            migrationBuilder.DropTable(
                name: "Ingredient",
                schema: "rcp");

            migrationBuilder.DropTable(
                name: "MethodItem",
                schema: "rcp");

            migrationBuilder.DropTable(
                name: "Recipe",
                schema: "rcp");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "rcp");
        }
    }
}
