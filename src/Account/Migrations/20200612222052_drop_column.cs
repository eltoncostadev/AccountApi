using Microsoft.EntityFrameworkCore.Migrations;

namespace Account.Migrations
{
    public partial class drop_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "User",
                type: "text",
                nullable: true);
        }
    }
}
