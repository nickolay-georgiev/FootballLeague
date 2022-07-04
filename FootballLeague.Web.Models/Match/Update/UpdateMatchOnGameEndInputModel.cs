using System;

namespace FootballLeague.Web.Models.Match.Update
{
    public class UpdateMatchOnGameEndInputModel
    {
        public int Id { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime EndDate { get; set; }
    }
}
