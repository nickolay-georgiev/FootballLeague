using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Persistence.Commands.Add.Team;
using FootballLeague.Persistence.Result.Add.Team;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Add.Team
{
    public sealed class AddSportTeamToDatabaseErrorHandler : ICommandHandlerAsync<AddSportTeamToDatabaseCommand, AddSportTeamToDatabaseResult>
    {
        private readonly ICommandHandlerAsync<AddSportTeamToDatabaseCommand, AddSportTeamToDatabaseResult> decorated;

        public AddSportTeamToDatabaseErrorHandler(ICommandHandlerAsync<AddSportTeamToDatabaseCommand, AddSportTeamToDatabaseResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<AddSportTeamToDatabaseResult> Handle(AddSportTeamToDatabaseCommand command)
        {
            try
            {
                return await decorated.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to add entity of type {nameof(command.Entity)} to DB, {ex}");

                return new AddSportTeamToDatabaseResult();
            }
        }
    }
}
