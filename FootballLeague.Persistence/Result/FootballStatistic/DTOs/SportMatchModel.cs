using System;

namespace FootballLeague.Persistence.Result.FootballStatistic.DTOs
{
    public class SportMatchModel
    {
        public string Name { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public SportTeamModel HomeTeam { get; set; }

        public SportTeamModel AwayTeam { get; set; }
    }
}
