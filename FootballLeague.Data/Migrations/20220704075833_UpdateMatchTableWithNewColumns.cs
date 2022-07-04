using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballLeague.Data.Migrations
{
    public partial class UpdateMatchTableWithNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchScore",
                table: "SportMatch");

            migrationBuilder.RenameColumn(
                name: "TotalGoals",
                table: "SportMatch",
                newName: "HomeTeamGoals");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamGoals",
                table: "SportMatch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "SportMatch",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeamGoals",
                table: "SportMatch");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "SportMatch");

            migrationBuilder.RenameColumn(
                name: "HomeTeamGoals",
                table: "SportMatch",
                newName: "TotalGoals");

            migrationBuilder.AddColumn<string>(
                name: "MatchScore",
                table: "SportMatch",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
