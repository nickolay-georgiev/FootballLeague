using System;

namespace FootballLeague.Services.Implementation.Match.Models.Contexts
{
    public class UpdateMatchContext
    {
        public UpdateMatchContext(int homeTeamGoals, int awayTeamGoals, DateTime endDate)
        {
            HomeTeamGoals = homeTeamGoals;
            AwayTeamGoals = awayTeamGoals;
            EndDate = endDate;
        }

        public int HomeTeamGoals { get; }

        public int AwayTeamGoals { get; }

        public DateTime EndDate { get; }
    }
}
