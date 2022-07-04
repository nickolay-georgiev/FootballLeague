using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Web.Models.Match.Update;

namespace FootballLeague.Services.Implementation.Match.Commands
{
    public class UpdateMatchOnGameEndCommand : ICommand
    {
        public UpdateMatchOnGameEndCommand(UpdateMatchOnGameEndInputModel inputModel)
        {
            this.InputModel = inputModel;
        }

        public UpdateMatchOnGameEndInputModel InputModel { get; }
    }


}
