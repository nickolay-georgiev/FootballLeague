namespace FootballLeague.Abstraction.Builders
{
    public interface IDomainEntityBuilder<TEntity, TContext>
    {
        public EntityBuildResult<TEntity> Build(TContext context);
    }
}
