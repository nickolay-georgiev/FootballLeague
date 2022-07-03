using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Persistence.Queries.GetByName.Team;
using FootballLeague.Persistence.Result.Team.GetByName;
using System;

namespace FootballLeague.Persistence.QueryHandlers.GetByName.Team
{
    public sealed class TeamByNameErrorHandler : IQueryHandler<TeamByNameQuery, TeamByNameResult>
    {
        private readonly IQueryHandler<TeamByNameQuery, TeamByNameResult> decorated;

        public TeamByNameErrorHandler(IQueryHandler<TeamByNameQuery, TeamByNameResult> decorated)
        {
            this.decorated = decorated;
        }

        public TeamByNameResult Handle(TeamByNameQuery query)
        {
            try
            {
                return decorated.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to fetch team with name {query.Name}, {ex}");

                return new TeamByNameResult();
            }
        }
    }
}
