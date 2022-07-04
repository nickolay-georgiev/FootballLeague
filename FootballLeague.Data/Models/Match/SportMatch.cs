using FootballLeague.Data.Common.Models;
using FootballLeague.Data.Models.Contracts;
using FootballLeague.Data.Models.Enums;
using FootballLeague.Data.Models.Team;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeague.Data.Models.Match
{
    public class SportMatch : BaseDeletableModel<int>, IIHaveIntId
    {
        public string Name { get; set; }

        public int TotalGoals { get; set; }

        public string MatchScore { get; set; }

        public DateTime StartDate { get; set; }

        [ForeignKey(nameof(SportTeam))]
        public int HomeTeamId { get; set; }

        public SportTeam HomeTeam { get; set; }

        [ForeignKey(nameof(SportTeam))]
        public int AwayTeamId { get; set; }

        public SportTeam AwayTeam { get; set; }

        public MatchResult MatchResult { get; set; }
    }
}
