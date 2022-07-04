using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Common.Models;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Contracts;
using FootballLeague.Persistence.Queries.GetById;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.QueryHandlers.Common.GetById
{
    public sealed class EntityByIntIdDatabaseQueryHandler<TEntity> : IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<TEntity>>, EntityByIdDatabaseResult<TEntity>>
            where TEntity : class, IDeletableEntity, IIHaveIntId
    {
        private readonly IDeletableEntityRepository<TEntity> repo;

        public EntityByIntIdDatabaseQueryHandler(IDeletableEntityRepository<TEntity> repo)
        {
            this.repo = repo;
        }

        public async Task<EntityByIdDatabaseResult<TEntity>> Handle(EntityByIdDatabaseQuery<EntityByIdDatabaseResult<TEntity>> query)
        {
            var entity = await repo
                 .AllAsNoTracking()
                 .Where(x => x.Id == query.Id)
                 .FirstOrDefaultAsync();

            if (entity is null) return new EntityByIdDatabaseResult<TEntity>("Entity does not exist");

            return new EntityByIdDatabaseResult<TEntity>(entity);
        }
    }
}
