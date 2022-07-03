using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Services.Implementation.Team.Models.Result.Delete
{
    public class DeleteTeamByIdResult : IResult
    {
        public DeleteTeamByIdResult()
        {
            Succeed = true;
        }

        public DeleteTeamByIdResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }
    }
}
