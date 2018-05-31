using Autofac;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services.Builders;
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
                case RuleSet.MalifauxTTB:
                    return _serviceProvider.ResolveKeyed<IStatBuilder>(RuleSet.MalifauxTTB);
                case RuleSet.DungeonsandDragons:
                    return _serviceProvider.ResolveKeyed<IStatBuilder>(RuleSet.DungeonsandDragons);
                default:
                    throw new PPGException($"Could not resolve a Stat Builder for the Rule Set {ruleSet}");
            }
        }
    }
}
