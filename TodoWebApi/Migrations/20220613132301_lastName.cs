using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebApi.Migrations
{
    public partial class lastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "TodoItems");
        }
    }
}
