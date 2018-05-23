using Autofac;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services;
using PPG.CharacterSheets.ErrorHandling;

namespace PPG.CharacterSheets.Characters.Factories
{
    public class MetaDataBuilderFactory : IMetaDataBuilderFactory
    {
        private readonly ILifetimeScope _serviceProvider;

        public MetaDataBuilderFactory(ILifetimeScope serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMetaDataBuilder Resolve(RuleSet ruleSet)
        {
            switch (ruleSet)
            {
                case RuleSet.MalifauxTtB:
                    return _serviceProvider.ResolveKeyed<IMetaDataBuilder>(RuleSet.MalifauxTtB);
                default:
                    throw new PPGException($"Could not resolve a Meta Data Builder for the Rule Set {ruleSet}");
            }
        }
    }
}
