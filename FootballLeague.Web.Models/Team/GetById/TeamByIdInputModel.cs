using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Web.Models.Team.GetById
{
    public class TeamByIdInputModel
    {
        [Required]
        public int Id { get; set; }
    }
}
