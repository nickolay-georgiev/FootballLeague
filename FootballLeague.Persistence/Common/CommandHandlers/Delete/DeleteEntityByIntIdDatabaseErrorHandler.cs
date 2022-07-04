using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Contracts;
using FootballLeague.Persistence.Common.Commands.Delete;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.Common.CommandHandlers.Delete
{
    public sealed class DeleteEntityByIntIdDatabaseErrorHandler<TEntity> : ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<TEntity>, IResult>
             where TEntity : IIHaveIntId
    {
        private readonly ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<TEntity>, IResult> decorated;

        public DeleteEntityByIntIdDatabaseErrorHandler(ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<TEntity>, IResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<IResult> Handle(DeleteEntityByIdDatabaseCommand<TEntity> command)
        {
            try
            {
                return await decorated.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to delete entity with ID {command.Entity.Id} and type {typeof(TEntity)} , {ex}");

                return new FailedResult();
            }
        }
    }
}
