using System.Threading.Tasks;

namespace FootballLeague.Abstraction.CQS.Query
{
    public interface IQuery<TResult>
    {
    }

    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }

    public interface IAsyncQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }

    public interface IQueryHandler<TResult>
    {
        TResult Handle();
    }
}
