using System;

namespace FootballLeague.Web.Models.Match.Create
{
    public class CreateSportMatchInputModel
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public DateTime StartDate { get; set; }
    }
}
