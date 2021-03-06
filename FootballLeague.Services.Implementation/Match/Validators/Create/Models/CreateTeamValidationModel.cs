using FootballLeague.Data.Models.Team;
using System;

namespace FootballLeague.Services.Implementation.Match.Validators.Create.Models
{
    public class CreateTeamValidationModel
    {
        public CreateTeamValidationModel(SportTeam homeTeam, SportTeam awayTeam, DateTime startDate)
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
