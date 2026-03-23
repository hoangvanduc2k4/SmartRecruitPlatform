using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRecruit.Infrastructure.Migrations
{
    public partial class SeedJobExpireDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update all existing jobs to have a random ExpireDate between -5 and 30 days from now
            migrationBuilder.Sql("UPDATE Jobs SET ExpireDate = DATEADD(day, ABS(CHECKSUM(NEWID()) % 35) - 5, GETUTCDATE()) WHERE ExpireDate IS NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the seed data (setting it to null or keeping as is)
            migrationBuilder.Sql("UPDATE Jobs SET ExpireDate = NULL;");
        }
    }
}
