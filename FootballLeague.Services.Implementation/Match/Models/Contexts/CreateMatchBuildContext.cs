using FootballLeague.Data.Models.Team;
using System;

namespace FootballLeague.Services.Implementation.Match.Models.Contexts
{
    public class CreateMatchBuildContext
    {
        public CreateMatchBuildContext(SportTeam homeTeam, SportTeam awayTeam, DateTime startDate)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            StartDate = startDate;
        }

        public SportTeam HomeTeam { get; }

        public SportTeam AwayTeam { get; }

        public DateTime StartDate { get; }
    }
}
