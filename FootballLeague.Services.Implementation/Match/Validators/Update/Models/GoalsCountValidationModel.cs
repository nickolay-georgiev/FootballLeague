using System;

namespace FootballLeague.Services.Implementation.Match.Validators.Update.Models
{
    public class UpdateMatchOnGameEndValidationModel
    {
        public UpdateMatchOnGameEndValidationModel(int homeTeamGoals, int awayTeamGoals, DateTime startDate, DateTime endDate)
        {
            HomeTeamGoals = homeTeamGoals;
            AwayTeamGoals = awayTeamGoals;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
