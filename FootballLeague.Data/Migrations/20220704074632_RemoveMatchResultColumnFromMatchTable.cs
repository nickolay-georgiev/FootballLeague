using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballLeague.Data.Migrations
{
    public partial class RemoveMatchResultColumnFromMatchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchResult",
                table: "SportMatch");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchResult",
                table: "SportMatch",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
