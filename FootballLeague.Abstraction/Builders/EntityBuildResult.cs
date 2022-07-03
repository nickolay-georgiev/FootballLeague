using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Abstraction.Builders
{
    public class EntityBuildResult<TEntity> : IResult
    {
        public EntityBuildResult()
        {
            Succeed = false;
        }

        public EntityBuildResult(TEntity entity)
        {
            Succeed = true;
            Entity = entity;
        }

        public bool Succeed { get; }

        public TEntity Entity { get; }
    }
}
