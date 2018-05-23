using Autofac;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services;
using PPG.CharacterSheets.ErrorHandling;

namespace PPG.CharacterSheets.Characters.Factories
{
    public class StatBuilderFactory : IStatBuilderFactory
    {
        private readonly ILifetimeScope _serviceProvider;

        public StatBuilderFactory(ILifetimeScope serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IStatBuilder Resolve(RuleSet ruleSet)
        {
            switch (ruleSet)
            {
                case RuleSet.MalifauxTtB:
                    return _serviceProvider.ResolveKeyed<IStatBuilder>(RuleSet.MalifauxTtB);
                default:
                    throw new PPGException($"Could not resolve a Stat Builder for the Rule Set {ruleSet}");
            }
        }
    }
}
