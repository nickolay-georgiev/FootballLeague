namespace FootballLeague.Persistence.Result.FootballStatistic.DTOs
{
    public class SportTeamModel
    {
        public string Name { get; set; }

        public int TotalWon { get; set; }

        public int TotalDraw { get; set; }

        public int TotalLost { get; set; }

        public int MatchPlayed { get; set; }

        public int TotalSeasonScore { get; set; }
    }
}
