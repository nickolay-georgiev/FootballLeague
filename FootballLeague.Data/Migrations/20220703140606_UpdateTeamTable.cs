using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballLeague.Data.Migrations
{
    public partial class UpdateTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SportTeam",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SportTeam",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SportMatch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SportMatch",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SportTeam_IsDeleted",
                table: "SportTeam",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SportMatch_IsDeleted",
                table: "SportMatch",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SportTeam_IsDeleted",
                table: "SportTeam");

            migrationBuilder.DropIndex(
                name: "IX_SportMatch_IsDeleted",
                table: "SportMatch");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SportTeam");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SportTeam");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SportMatch");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SportMatch");
        }
    }
}
