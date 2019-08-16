using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryManager.Migrations
{
    public partial class note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reminder",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "noteType",
                table: "Notes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Reminder",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "noteType",
                table: "Notes");
        }
    }
}
