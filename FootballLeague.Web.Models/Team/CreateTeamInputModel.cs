using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Web.Models.Team
{
    public class CreateTeamInputModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
