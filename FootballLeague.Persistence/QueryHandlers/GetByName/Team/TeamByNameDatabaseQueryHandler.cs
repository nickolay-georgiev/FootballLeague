using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Queries.GetByName.Team;
using FootballLeague.Persistence.Result.Team.GetByName;
using System.Linq;

namespace FootballLeague.Persistence.QueryHandlers.GetByName.Team
{
    public sealed class TeamByNameDatabaseQueryHandler : IQueryHandler<TeamByNameDatabaseQuery, TeamByNameDatabaseResult>
    {
        private readonly IDeletableEntityRepository<SportTeam> repo;

        public TeamByNameDatabaseQueryHandler(IDeletableEntityRepository<SportTeam> repo)
        {
            this.repo = repo;
        }

        public TeamByNameDatabaseResult Handle(TeamByNameDatabaseQuery query)
        {
            var sportTeam = repo
                .AllAsNoTracking()
                .Where(x => x.Name == query.Name)
                .FirstOrDefault();

            return new TeamByNameDatabaseResult(sportTeam);
        }
    }
}
