using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Common.Logging;
using FootballLeague.Persistence.Commands.Add.Team;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Add.Team
{
    public sealed class AddSportTeamToDatabaseErrorHandler : ICommandHandlerAsync<AddSportTeamToDatabaseCommand, IResult>
    {
        private readonly ICommandHandlerAsync<AddSportTeamToDatabaseCommand, IResult> decorated;

        public AddSportTeamToDatabaseErrorHandler(ICommandHandlerAsync<AddSportTeamToDatabaseCommand, IResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<IResult> Handle(AddSportTeamToDatabaseCommand command)
        {
            try
            {
                return await decorated.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to add entity of type {nameof(command.Entity)} to DB, {ex}");

                return new FailedResult();
            }
        }
    }
}
