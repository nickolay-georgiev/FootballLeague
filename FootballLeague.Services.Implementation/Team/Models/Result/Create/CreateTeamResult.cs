using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Services.Implementation.Team.Models.Result.Create
{
    public class CreateTeamResult : IResult
    {
        public CreateTeamResult()
        {
            Succeed = true;
        }

        public CreateTeamResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }
    }
}
