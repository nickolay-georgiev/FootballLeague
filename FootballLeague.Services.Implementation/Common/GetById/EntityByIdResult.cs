using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Services.Implementation.Common.GetById
{
    public class EntityByIdResult<TEntity> : IResult
    {
        public EntityByIdResult(TEntity entity)
        {
            Succeed = true;
            Entity = entity;
        }

        public EntityByIdResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }

        public TEntity Entity { get; }
    }
}
