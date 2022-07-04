using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Services.Implementation.Common.Results.Delete
{
    public class DeleteEntityByIdResult<TEntity> : IResult
    {
        public DeleteEntityByIdResult()
        {
            Succeed = true;
        }

        public DeleteEntityByIdResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }
    }
}
