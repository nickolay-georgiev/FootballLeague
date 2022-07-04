using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Models.Contracts;
using FootballLeague.Persistence.Queries.GetById;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.QueryHandlers.Common.GetById
{
    public sealed class EntityByIntIdDatabaseErrorHandler<TEntity> : IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<TEntity>>, EntityByIdDatabaseResult<TEntity>>
            where TEntity : IIHaveIntId
    {
        private const string ERROR_MESSAGE = "Unexpected error, please try again and if this error still occurs, contatct the support team.";

        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<TEntity>>, EntityByIdDatabaseResult<TEntity>> decorated;

        public EntityByIntIdDatabaseErrorHandler(IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<TEntity>>, EntityByIdDatabaseResult<TEntity>> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<EntityByIdDatabaseResult<TEntity>> Handle(EntityByIdDatabaseQuery<EntityByIdDatabaseResult<TEntity>> query)
        {
            try
            {
                return await decorated.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to fetch entiy with ID {query.Id} and type {typeof(TEntity)}, {ex}");

                return new EntityByIdDatabaseResult<TEntity>(ERROR_MESSAGE);
            }
        }
    }
}
