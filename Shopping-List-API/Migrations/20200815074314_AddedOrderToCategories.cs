using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class AddedOrderToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "rcp",
                table: "Category",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                schema: "rcp",
                table: "Category");
        }
    }
}
