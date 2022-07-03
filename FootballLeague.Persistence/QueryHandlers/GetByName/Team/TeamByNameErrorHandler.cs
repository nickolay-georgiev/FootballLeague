using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Persistence.Queries.GetByName.Team;
using FootballLeague.Persistence.Result.Team.GetByName;
using System;

namespace FootballLeague.Persistence.QueryHandlers.GetByName.Team
{
    public sealed class TeamByNameErrorHandler : IQueryHandler<TeamByNameDatabaseQuery, TeamByNameDatabaseResult>
    {
        private readonly IQueryHandler<TeamByNameDatabaseQuery, TeamByNameDatabaseResult> decorated;

        public TeamByNameErrorHandler(IQueryHandler<TeamByNameDatabaseQuery, TeamByNameDatabaseResult> decorated)
        {
            this.decorated = decorated;
        }

        public TeamByNameDatabaseResult Handle(TeamByNameDatabaseQuery query)
        {
            try
            {
                return decorated.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to fetch team with name {query.Name}, {ex}");

                return new TeamByNameDatabaseResult();
            }
        }
    }
}
