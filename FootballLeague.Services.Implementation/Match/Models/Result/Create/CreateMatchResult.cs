using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Services.Implementation.Match.Models.Result.Create
{
    public class CreateMatchResult : IResult
    {
        public CreateMatchResult()
        {
            Succeed = true;
        }

        public CreateMatchResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }
    }
}
