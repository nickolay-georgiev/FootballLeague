using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Match;
using FootballLeague.Services.Implementation.Common.Results.Update;
using FootballLeague.Web.Models.Match.Update;
using System.Threading.Tasks;

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
