using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Web.Models.Match.Create;

namespace FootballLeague.Services.Implementation.Match.Commands.Create
{
    public class CreateMatchCommand : ICommand
    {
        public CreateMatchCommand(CreateSportMatchInputModel inputModel)
        {
            this.inputModel = inputModel;
        }

        public CreateSportMatchInputModel inputModel { get; }
    }
}
