using FootballLeague.Abstraction.Builders;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Match;
using FootballLeague.Services.Implementation.Match.Models.Contexts;

namespace FootballLeague.Services.Implementation.Match.Builders
{
    public sealed class SetSportMatcEndDateBuilder : IBuilder<SportMatch, UpdateMatchContext>
    {
        public IResult Build(SportMatch entity, UpdateMatchContext context)
        {
            entity.EndDate = context.EndDate;

            return new SuccessfulResult();
        }
    }
}
