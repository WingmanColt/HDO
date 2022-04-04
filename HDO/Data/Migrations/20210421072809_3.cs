using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SysName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "SysName",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
