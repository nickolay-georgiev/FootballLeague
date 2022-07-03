using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Persistence.Commands.Update;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Update
{
    public sealed class UpdateSportTeamMatchPlayedCommandHandler : ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>
    {
        private readonly ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> decorated;

        public UpdateSportTeamMatchPlayedCommandHandler(ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<IResult> Handle(UpdateSportTeamDatabaseCommand command)
        {
            command.SportTeam.MatchPlayed += 1;

            var result = await this.decorated.Handle(command);
            if (!result.Succeed) return new FailedResult();

            return new SuccessfulResult();
        }
    }
}
