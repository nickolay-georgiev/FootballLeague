using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Web.Models.Match.Update
{
    public class UpdateMatchOnGameEndInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
