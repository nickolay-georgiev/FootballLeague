using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Persistence.Result.GetById.Team;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.QueryHandlers.GetById.Team
{
    public sealed class TeamByIdDatabaseErrorHandler : IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult>
    {
        private readonly IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult> decorated;

        public TeamByIdDatabaseErrorHandler(IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<TeamByIdDatabaseResult> Handle(TeamByIdDatabaseQuery query)
        {
            try
            {
                return await decorated.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to fetch team with ID {query.Id}, {ex}");

                return new TeamByIdDatabaseResult();
            }
        }
    }
}
