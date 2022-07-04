using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Persistence.Queries.GetById
{
    public class EntityByIdDatabaseQuery<TResult> : IQuery<TResult>
        where TResult : IResult
    {
        public EntityByIdDatabaseQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    public class EntityByIdDatabaseResult<TEntity> : IResult
    {
        public EntityByIdDatabaseResult()
        {
            Succeed = false;

        }

        public EntityByIdDatabaseResult(TEntity entity)
        {
            Succeed = true;
            Entity = entity;
        }

        public bool Succeed { get; }

        public TEntity Entity { get; }
    }
}
