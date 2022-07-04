using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Common.Logging;
using FootballLeague.Persistence.Commands.Update.Match;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Update.Match
{
    public sealed class UpdateSportMatchDatabaseErrorHandler : ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult>
    {
        private readonly ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult> decorated;

        public UpdateSportMatchDatabaseErrorHandler(ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<IResult> Handle(UpdateSportMatchDatabaseCommand command)
        {
            try
            {
                return await decorated.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to update SportMatch with id {command.SportMatch.Id} to DB, {ex}");

                return new FailedResult();
            }
        }
    }
}
