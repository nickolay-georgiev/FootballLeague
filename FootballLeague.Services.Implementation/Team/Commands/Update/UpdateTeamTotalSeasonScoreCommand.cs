using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Web.Models.Team.Update;

namespace FootballLeague.Services.Implementation.Team.Commands.Update
{
    public class UpdateTeamTotalSeasonScoreCommand : ICommand
    {
        public UpdateTeamTotalSeasonScoreCommand(UpdateTeamTotalSeasonScoreInputModel inputModel)
        {
            InputModel = inputModel;
        }

        public UpdateTeamTotalSeasonScoreInputModel InputModel { get; }
    }
}
