using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Persistence.Result.GetById.Team;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.QueryHandlers.GetById.Team
{
    public sealed class TeamByIdDatabaseQueryHandler : IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult>
    {
        private readonly IDeletableEntityRepository<SportTeam> repo;

        public TeamByIdDatabaseQueryHandler(IDeletableEntityRepository<SportTeam> repo)
        {
            this.repo = repo;
        }

        public async Task<TeamByIdDatabaseResult> Handle(TeamByIdDatabaseQuery query)
        {
            var sportTeam = await repo
              .AllAsNoTracking()
              .Where(x => x.Id == query.Id)
              .FirstOrDefaultAsync();

            return new TeamByIdDatabaseResult(sportTeam);
        }
    }   
}
