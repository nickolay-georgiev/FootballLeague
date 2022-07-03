using FootballLeague.Abstraction.Builders;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Match;
using FootballLeague.Services.Implementation.Match.Models.Contexts;

namespace FootballLeague.Services.Implementation.Match.Builders
{
    public sealed class SportMatchNameBuilder : IBuilder<SportMatch, CreateMatchBuildContext>
    {
        public IResult Build(SportMatch entity, CreateMatchBuildContext context)
        {
            entity.Name = $"{context.HomeTeam.Name} - {context.AwayTeam.Name}";

            return new SuccessfulResult();
        }
    }
}
