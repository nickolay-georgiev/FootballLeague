using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Services.Implementation.Common.Results.Update
{
    public class UpdateEntityResult : IResult
    {
        public UpdateEntityResult()
        {
            Succeed = true;
        }

        public UpdateEntityResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }
    }
}
