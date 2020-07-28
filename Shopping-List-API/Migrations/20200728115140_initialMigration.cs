using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "rcp");

            //migrationBuilder.CreateTable(
            //    name: "Account",
            //    schema: "rcp",
            //    columns: table => new
            //    {
            //        AccountId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Email = table.Column<string>(nullable: true),
            //        PasswordHash = table.Column<byte[]>(nullable: true),
            //        PasswordSalt = table.Column<byte[]>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Account", x => x.AccountId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Category",
            //    schema: "rcp",
            //    columns: table => new
            //    {
            //        CategoryId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Category", x => x.CategoryId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "List",
            //    schema: "rcp",
            //    columns: table => new
            //    {
            //        ListId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        AccountId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_List", x => x.ListId);
            //        table.ForeignKey(
            //            name: "FK_List_Account_AccountId",
            //            column: x => x.AccountId,
            //            principalSchema: "rcp",
            //            principalTable: "Account",
            //            principalColumn: "AccountId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Recipe",
            //    schema: "rcp",
            //    columns: table => new
            //    {
            //        RecipeId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        DescriptionMain = table.Column<string>(nullable: true),
            //        DescriptionSecondary = table.Column<string>(nullable: true),
            //        ImageUrl = table.Column<string>(nullable: true),
            //        DeletedAt = table.Column<DateTime>(nullable: true),
            //        PublishedAt = table.Column<DateTime>(nullable: true),
            //        CategoryId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Recipe", x => x.RecipeId);
            //        table.ForeignKey(
            //            name: "FK_Recipe_Category_CategoryId",
            //            column: x => x.CategoryId,
            //            principalSchema: "rcp",
            //            principalTable: "Category",
            //            principalColumn: "CategoryId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ListItem",
            //    schema: "rcp",
            //    columns: table => new
            //    {
            //        ListItemId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Quantity = table.Column<int>(nullable: true),
            //        IsDeleted = table.Column<DateTime>(nullable: true),
            //        IsComplete = table.Column<DateTime>(nullable: true),
            //        Order = table.Column<int>(nullable: false),
            //        ListId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ListItem", x => x.ListItemId);
            //        table.ForeignKey(
            //            name: "FK_ListItem_List_ListId",
            //            column: x => x.ListId,
            //            principalSchema: "rcp",
            //            principalTable: "List",
            //            principalColumn: "ListId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Ingredient",
            //    schema: "rcp",
            //    columns: table => new
            //    {
            //        IngredientId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Quantity = table.Column<decimal>(nullable: false),
            //        Measure = table.Column<string>(nullable: true),
            //        PositionNo = table.Column<int>(nullable: false),
            //        RecipeId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
            //        table.ForeignKey(
            //            name: "FK_Ingredient_Recipe_RecipeId",
            //            column: x => x.RecipeId,
            //            principalSchema: "rcp",
            //            principalTable: "Recipe",
            //            principalColumn: "RecipeId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MethodItem",
            //    schema: "rcp",
            //    columns: table => new
            //    {
            //        MethodItemId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        StepNo = table.Column<int>(nullable: false),
            //        Text = table.Column<string>(nullable: true),
            //        RecipeId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MethodItem", x => x.MethodItemId);
            //        table.ForeignKey(
            //            name: "FK_MethodItem_Recipe_RecipeId",
            //            column: x => x.RecipeId,
            //            principalSchema: "rcp",
            //            principalTable: "Recipe",
            //            principalColumn: "RecipeId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Ingredient_RecipeId",
            //    schema: "rcp",
            //    table: "Ingredient",
            //    column: "RecipeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_List_AccountId",
            //    schema: "rcp",
            //    table: "List",
            //    column: "AccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ListItem_ListId",
            //    schema: "rcp",
            //    table: "ListItem",
            //    column: "ListId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MethodItem_RecipeId",
            //    schema: "rcp",
            //    table: "MethodItem",
            //    column: "RecipeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Recipe_CategoryId",
            //    schema: "rcp",
            //    table: "Recipe",
            //    column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Ingredient",
            //    schema: "rcp");

            //migrationBuilder.DropTable(
            //    name: "ListItem",
            //    schema: "rcp");

            //migrationBuilder.DropTable(
            //    name: "MethodItem",
            //    schema: "rcp");

            //migrationBuilder.DropTable(
            //    name: "List",
            //    schema: "rcp");

            //migrationBuilder.DropTable(
            //    name: "Recipe",
            //    schema: "rcp");

            //migrationBuilder.DropTable(
            //    name: "Account",
            //    schema: "rcp");

            //migrationBuilder.DropTable(
            //    name: "Category",
            //    schema: "rcp");
        }
    }
}
