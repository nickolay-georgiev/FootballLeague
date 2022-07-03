using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Web.Models.Team.GetById;

namespace FootballLeague.Services.Implementation.Team.Commands.Delete
{
    public class DeleteTeamByIdCommand : ICommand
    {
        public DeleteTeamByIdCommand(TeamByIdInputModel inputModel)
        {
            InputModel = inputModel;
        }

        public TeamByIdInputModel InputModel { get; }
    }   
}
