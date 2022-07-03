using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Queries.GetByName.Team;
using FootballLeague.Persistence.Result.Team.GetByName;
using System.Linq;

namespace FootballLeague.Persistence.QueryHandlers.GetByName.Team
{
    public sealed class TeamByNameQueryHandler : IQueryHandler<TeamByNameQuery, TeamByNameResult>
    {
        private readonly IRepository<SportTeam> repo;

        public TeamByNameQueryHandler(IRepository<SportTeam> repo)
        {
            this.repo = repo;
        }

        public TeamByNameResult Handle(TeamByNameQuery query)
        {
            var sportTeam = repo
                .AllAsNoTracking()
                .Where(x => x.Name == query.Name)
                .FirstOrDefault();

            return new TeamByNameResult(sportTeam);
        }
    }
}
