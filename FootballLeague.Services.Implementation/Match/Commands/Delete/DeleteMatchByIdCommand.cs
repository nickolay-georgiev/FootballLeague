using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Web.Models.Match.GetById;

namespace FootballLeague.Services.Implementation.Match.Commands.Delete
{
    public class DeleteMatchByIdCommand : ICommand
    {
        public DeleteMatchByIdCommand(MatchByIdInputModel inputModel)
        {
            InputModel = inputModel;
        }

        public MatchByIdInputModel InputModel { get; set; }
    }
}
