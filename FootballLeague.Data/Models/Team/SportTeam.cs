using FootballLeague.Data.Common.Models;
using FootballLeague.Data.Models.Player;
using System.Collections.Generic;

namespace FootballLeague.Data.Models.Team
{
    public class SportTeam : BaseModel<int>
    {
        public SportTeam()
        {
            this.SportPlayers = new List<SportPlayer>();
        }

        public int TotalWon { get; set; }

        public int TotalDraw { get; set; }

        public int TotalLost { get; set; }

        public int MatchPlayed { get; set; }

        public int GroupPosition { get; set; }

        public int TotalSeasonPoint { get; set; }

        public ICollection<SportPlayer> SportPlayers { get; set; }
    }
}
