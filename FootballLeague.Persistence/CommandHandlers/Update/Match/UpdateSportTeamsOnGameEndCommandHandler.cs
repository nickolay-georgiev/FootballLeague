using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Enums;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Update;
using FootballLeague.Persistence.Commands.Update.Match;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Team;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Match.CommandHandlers.Update
{
    public sealed class UpdateSportTeamsOnGameEndCommandHandler : ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult>
    {
        private readonly ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult> decorated;
        private readonly ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> teamUpdateHandler;
        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>> teamByIdHandler;

        public UpdateSportTeamsOnGameEndCommandHandler(ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult> decorated, ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> teamUpdateHandler, IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>> teamByIdHandler)
        {
            this.decorated = decorated;
            this.teamUpdateHandler = teamUpdateHandler;
            this.teamByIdHandler = teamByIdHandler;
        }

        public async Task<IResult> Handle(UpdateSportMatchDatabaseCommand command)
        {
            var homeTeamResult = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(command.SportMatch.HomeTeamId));
            if (!homeTeamResult.Succeed) return new FailedResult();

            var awayTeamResult = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(command.SportMatch.AwayTeamId));
            if (!awayTeamResult.Succeed) return new FailedResult();

            var updateHomeTeam = await this.teamUpdateHandler.Handle(new UpdateSportTeamDatabaseCommand(homeTeamResult.Entity, GetMatchScore(command.SportMatch.HomeTeamGoals, command.SportMatch.AwayTeamGoals)));
            var updateAwayTeam = await this.teamUpdateHandler.Handle(new UpdateSportTeamDatabaseCommand(homeTeamResult.Entity, GetMatchScore(command.SportMatch.AwayTeamGoals, command.SportMatch.HomeTeamGoals)));

            return await this.decorated.Handle(command);
        }

        private MatchScore GetMatchScore(int selectedTeamGoals, int opponentTeamGoals)
        {
            if (selectedTeamGoals > opponentTeamGoals)
            {
                return MatchScore.Win;
            }
            else if (selectedTeamGoals < opponentTeamGoals)
            {
                return MatchScore.Loss;
            }
            else
            {
                return MatchScore.Draw;
            }
        }
    }
}
