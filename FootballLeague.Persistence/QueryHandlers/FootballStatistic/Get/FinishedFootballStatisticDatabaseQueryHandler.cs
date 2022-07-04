using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Queries.FootballStatistic.Get;
using FootballLeague.Persistence.Result.FootballStatistic.DTOs;
using FootballLeague.Persistence.Result.FootballStatistic.Get;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.QueryHandlers.FootballStatistic.Get
{
    public sealed class FinishedFootballStatisticDatabaseQueryHandler : IAsyncQueryHandler<FinishedFootballStatisticDatabaseQuery, FinishedFootballStatisticDatabaseResult>
    {
        private readonly IDeletableEntityRepository<SportMatch> repo;

        public FinishedFootballStatisticDatabaseQueryHandler(IDeletableEntityRepository<SportMatch> repo)
        {
            this.repo = repo;
        }

        public async Task<FinishedFootballStatisticDatabaseResult> Handle(FinishedFootballStatisticDatabaseQuery query)
        {
            var model = await this.repo
                .AllAsNoTracking()
                .Where(x => x.EndDate != null)
                .Select(x => new SportMatchModel
                {
                    Name = x.Name,
                    HomeTeamGoals = x.HomeTeamGoals,
                    AwayTeamGoals = x.AwayTeamGoals,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    HomeTeam = new SportTeamModel
                    {
                        Name = x.HomeTeam.Name,
                        TotalWon = x.HomeTeam.TotalWon,
                        TotalDraw = x.HomeTeam.TotalDraw,
                        TotalLost = x.HomeTeam.TotalLost,
                        MatchPlayed = x.HomeTeam.MatchPlayed,
                        TotalSeasonScore = x.HomeTeam.TotalSeasonScore,
                    },
                    AwayTeam = new SportTeamModel
                    {
                        Name = x.AwayTeam.Name,
                        TotalWon = x.AwayTeam.TotalWon,
                        TotalDraw = x.AwayTeam.TotalDraw,
                        TotalLost = x.AwayTeam.TotalLost,
                        MatchPlayed = x.AwayTeam.MatchPlayed,
                        TotalSeasonScore = x.AwayTeam.TotalSeasonScore,
                    }

                }).ToListAsync();

            return new FinishedFootballStatisticDatabaseResult(model);
        }
    }  
}
