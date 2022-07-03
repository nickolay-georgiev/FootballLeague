using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Add.Team;
using FootballLeague.Persistence.Result.Add.Team;
using FootballLeague.Services.Implementation.Team.Commands;
using FootballLeague.Services.Implementation.Team.Models.Result.Create;
using FootballLeague.Services.Implementation.Team.Validators.Create.Models;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Team.CommandHandlers.Create
{
    public class CreateTeamCommandHandler : ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>
    {
        private readonly IValidator<CreateTeamValidationModel> validator;
        private readonly ICommandHandlerAsync<AddSportTeamToDatabaseCommand, AddSportTeamToDatabaseResult> addTeamDBHandler;

        public CreateTeamCommandHandler(IValidator<CreateTeamValidationModel> validator, ICommandHandlerAsync<AddSportTeamToDatabaseCommand, AddSportTeamToDatabaseResult> addTeamDBHandler)
        {
            this.validator = validator;
            this.addTeamDBHandler = addTeamDBHandler;
        }

        public async Task<CreateTeamResult> Handle(CreateTeamCommand command)
        {
            var validationResult = this.validator.Validate(new CreateTeamValidationModel(command.Name));
            if (!validationResult.Succeed) return new CreateTeamResult(validationResult.Message);

            var result = await this.addTeamDBHandler.Handle(new AddSportTeamToDatabaseCommand(new SportTeam { Name = command.Name }));
            if(!result.Succeed) return new CreateTeamResult();

            return new CreateTeamResult();
        }
    }
}
