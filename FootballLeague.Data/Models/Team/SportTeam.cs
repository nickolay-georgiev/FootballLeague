using FootballLeague.Data.Common.Models;
using FootballLeague.Data.Models.Player;
using System.Collections.Generic;

namespace FootballLeague.Data.Models.Team
{
    public class SportTeam : BaseDeletableModel<int>
    {
        public SportTeam()
        {
            this.SportPlayers = new List<SportPlayer>();
        }

        public string Name { get; set; }

        public int TotalWon { get; set; }

        public int TotalDraw { get; set; }

        public int TotalLost { get; set; }

        public int MatchPlayed { get; set; }

        public int TotalSeasonScore{ get; set; }

        public ICollection<SportPlayer> SportPlayers { get; set; }
    }
}
