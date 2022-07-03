using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Persistence.Queries.GetById
{
    public class EntityByIdQuery<TResult> : IQuery<TResult>
    {
        public EntityByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    public class EntityByIdResult<TEntity> : IResult
    {
        public EntityByIdResult()
        {
            Succeed = false;

        }

        public EntityByIdResult(TEntity entity)
        {
            Succeed = true;
            Entity = entity;
        }

        public bool Succeed { get; }

        public TEntity Entity { get; }
    }
}
