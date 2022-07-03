using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Persistence;
using FootballLeague.Services.Implementation.Team.Commands.Create;
using FootballLeague.Services.Implementation.Team.Models.Result.Create;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.ErrorHandlers
{
    public sealed class CreateTeamcCommandErrorHandler : ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>
    {
        private const string CREATE_TEAM_ERROR_MESSAGE = "Failed to crate new team, please try again and if this error still occurs, contatct the support team";
        private readonly ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> decorated;

        public CreateTeamcCommandErrorHandler(ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<CreateTeamResult> Handle(CreateTeamCommand command)
        {
            try
            {
                return await this.decorated.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to create team with name {command.InputModel.Name}, {ex}");

                return new CreateTeamResult(CREATE_TEAM_ERROR_MESSAGE);
            }
        }
    }
}
