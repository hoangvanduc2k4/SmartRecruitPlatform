using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRecruit.Infrastructure.Migrations
{
    public partial class AddJobExpireDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Jobs");
        }
    }
}
