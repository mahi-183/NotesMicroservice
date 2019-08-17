using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryManager.Migrations
{
    public partial class Notess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPin",
                table: "Notes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPin",
                table: "Notes");
        }
    }
}
