using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Services.Implementation.Team.Models.Result.Update
{
    public class UpdateTeamTotalSeasonScoreResult : IResult
    {
        public UpdateTeamTotalSeasonScoreResult()
        {
            Succeed = true;
        }

        public UpdateTeamTotalSeasonScoreResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }
    }
}
