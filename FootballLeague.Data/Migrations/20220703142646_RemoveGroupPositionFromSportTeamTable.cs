using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballLeague.Data.Migrations
{
    public partial class RemoveGroupPositionFromSportTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupPosition",
                table: "SportTeam");

            migrationBuilder.RenameColumn(
                name: "TotalSeasonPoint",
                table: "SportTeam",
                newName: "TotalSeasonScore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSeasonScore",
                table: "SportTeam",
                newName: "TotalSeasonPoint");

            migrationBuilder.AddColumn<int>(
                name: "GroupPosition",
                table: "SportTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
