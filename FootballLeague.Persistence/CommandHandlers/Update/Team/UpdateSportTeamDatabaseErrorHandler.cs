using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Persistence.Commands.Update;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Update.Team
{
    public sealed class UpdateSportTeamDatabaseErrorHandler : ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>
    {
        private readonly ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> decorated;

        public UpdateSportTeamDatabaseErrorHandler(ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> decorated)
        {
            this.decorated = decorated;
        }
        public async Task<IResult> Handle(UpdateSportTeamDatabaseCommand command)
        {
            try
            {
                return await decorated.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to update team with ID {command.SportTeam.Id} with MatchScore {command.MatchScore}, {ex}");

                return new FailedResult();
            }
        }
    }
}
