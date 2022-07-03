using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Persistence.Commands.Delete.Team;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Delete
{
    public sealed class DeleteTeamDatabaseErrorHandler : ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult>
    {
        private readonly ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult> decorated;

        public DeleteTeamDatabaseErrorHandler(ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<IResult> Handle(DeleteTeamDatabaseCommand command)
        {
            try
            {
                return await decorated.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to delete team with ID {command.SportTeam.Id}, {ex}");

                return new FailedResult();
            }
        }
    }
}
