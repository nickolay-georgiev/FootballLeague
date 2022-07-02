using FootballLeague.Data.Common.Models;
using FootballLeague.Data.Models.Enums;
using FootballLeague.Data.Models.Team;

namespace FootballLeague.Data.Models.Player
{
    public class SportPlayer : BaseDeletableModel<int>
    {
        public int Name { get; set; }

        public int TotalGoals { get; set; }

        public int JerseyNumber { get; set; }

        public int SportTeamId { get; set; }

        public SportTeam SportTeam { get; set; }

        public PlayerPosition Position { get; set; }
    }
}
