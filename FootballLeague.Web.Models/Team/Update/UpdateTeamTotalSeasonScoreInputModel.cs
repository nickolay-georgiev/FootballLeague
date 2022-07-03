using FootballLeague.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Web.Models.Team.Update
{
    public class UpdateTeamTotalSeasonScoreInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public MatchScore MatchScore { get; set; }
    }
}
