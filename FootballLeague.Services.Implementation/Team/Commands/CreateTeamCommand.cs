using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Web.Models.Team;

namespace FootballLeague.Services.Implementation.Team.Commands
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
