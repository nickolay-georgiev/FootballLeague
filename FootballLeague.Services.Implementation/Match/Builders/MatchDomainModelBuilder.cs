using FootballLeague.Abstraction.Builders;
using FootballLeague.Data.Models.Match;
using FootballLeague.Services.Implementation.Match.Models.Contexts;
using System.Collections.Generic;

namespace FootballLeague.Services.Implementation.Match.Builders
{
    public sealed class MatchDomainModelBuilder : IDomainEntityBuilder<SportMatch, CreateMatchBuildContext>
    {
        private readonly IEnumerable<IBuilder<SportMatch, CreateMatchBuildContext>> builders;

        public MatchDomainModelBuilder(IEnumerable<IBuilder<SportMatch, CreateMatchBuildContext>> builders)
        {
            this.builders = builders;
        }

        public EntityBuildResult<SportMatch> Build(CreateMatchBuildContext context)
        {
            var match = new SportMatch();

            foreach (var builder in builders)
            {
                var buildResult = builder.Build(match, context);

                if (!buildResult.Succeed)
                {
                    break;
                }
            }

            return new EntityBuildResult<SportMatch>(match);
        }
    }
}
