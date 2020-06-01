using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping_List_API.Migrations
{
    public partial class UpdatedAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "rcp",
                table: "Account");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "rcp",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                schema: "rcp",
                table: "Account",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "rcp",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "rcp",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "rcp",
                table: "Account",
                nullable: true);
        }
    }
}
