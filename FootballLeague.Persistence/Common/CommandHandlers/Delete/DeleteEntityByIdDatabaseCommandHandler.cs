using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Common.Models;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Persistence.Common.Commands.Delete;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.Common.CommandHandlers.Delete
{
    public sealed class DeleteEntityByIdDatabaseCommandHandler<TEntity> : ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<TEntity>, IResult>
           where TEntity : class, IDeletableEntity
    {
        private readonly IDeletableEntityRepository<TEntity> repo;

        public DeleteEntityByIdDatabaseCommandHandler(IDeletableEntityRepository<TEntity> repo)
        {
            this.repo = repo;
        }

        public async Task<IResult> Handle(DeleteEntityByIdDatabaseCommand<TEntity> command)
        {
            this.repo.Delete(command.Entity);
            await this.repo.SaveChangesAsync();

            return new SuccessfulResult();
        }
    }   
}
