using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data;
using FootballLeague.Data.Common;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Repositories;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using SimpleInjector;

namespace FootballLeague.IoCContainers.Repository
{
    public sealed class RepositoryPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>), Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(EfRepository<>), Lifestyle.Scoped);
            container.Register<IDbQueryRunner, DbQueryRunner>(Lifestyle.Scoped);

            container.Register<IQueryHandler<Query, Result>, QueryHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandler<Query, Result>, QueryHandler1>(Lifestyle.Scoped);
        }
    }

    public class Query : IQuery<Result>
    {

    }

    public class Result
    {

    }

    public class QueryHandler : IQueryHandler<Query, Result>
    {
        public Result Handle(Query query)
        {

            return new Result();
        }
    }

    public class QueryHandler1 : IQueryHandler<Query, Result>
    {
        private readonly IQueryHandler<Query, Result> decorated;

        public QueryHandler1(IQueryHandler<Query, Result> decorated)
        {
            this.decorated = decorated;
        }

        public Result Handle(Query query)
        {
            this.decorated.Handle(query);

            return new Result();
        }
    }
}
