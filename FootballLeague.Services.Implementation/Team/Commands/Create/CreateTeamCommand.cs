using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Web.Models.Team.Create;

namespace FootballLeague.Services.Implementation.Team.Commands.Create
{
    public class CreateTeamCommand : ICommand
    {
        public CreateTeamCommand(CreateTeamInputModel inputModel)
        {
            InputModel = inputModel;
        }

        public CreateTeamInputModel InputModel { get; }
    }
}
