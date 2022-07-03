namespace FootballLeague.Services.Implementation.Team.Validators.Create.Models
{
    public class CreateTeamValidationModel
    {
        public CreateTeamValidationModel(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
