using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class AddedImagUrlToCategoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "rcp",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "rcp",
                table: "Category");
        }
    }
}
