using System;

namespace FootballLeague.Services.Implementation.Match.Validators.Create.Models
{
    public class CreateTeamValidationModel
    {
        public CreateTeamValidationModel(int homeTeamId, int awayTeamId, DateTime startDate)
        {
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            StartDate = startDate;
        }

        public int HomeTeamId { get; }

        public int AwayTeamId { get; }

        public DateTime StartDate { get; }
    }
}
