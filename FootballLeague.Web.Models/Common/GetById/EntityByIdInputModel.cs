using System.ComponentModel.DataAnnotations;

namespace FootballLeague.Web.Models.Common.GetById
{
    public class EntityByIdInputModel
    {
        [Required]
        public int Id { get; set; }
    }
}
