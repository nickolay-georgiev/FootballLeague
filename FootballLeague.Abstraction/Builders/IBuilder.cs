using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Abstraction.Builders
{
    public interface IBuilder<in TEntity, TContext>
    {
        public IResult Build(TEntity entity, TContext context);
    }  
}
