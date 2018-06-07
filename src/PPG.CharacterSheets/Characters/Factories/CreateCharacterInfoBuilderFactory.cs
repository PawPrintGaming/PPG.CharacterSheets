using Autofac;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services.Builders;
using PPG.CharacterSheets.ErrorHandling;

namespace PPG.CharacterSheets.Characters.Factories
{
    public class CreateCharacterInfoBuilderFactory : ICreateCharacterInfoBuilderFactory
    {
        private readonly ILifetimeScope _serviceProvider;

        public CreateCharacterInfoBuilderFactory(ILifetimeScope serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICharacterRuleSetInfoBuilder Resolve(RuleSet ruleSet)
        {
            switch (ruleSet)
            {
                case RuleSet.MalifauxTTB:
                    return _serviceProvider.ResolveKeyed<ICharacterRuleSetInfoBuilder>(RuleSet.MalifauxTTB);
                case RuleSet.DungeonsandDragons:
                    return _serviceProvider.ResolveKeyed<ICharacterRuleSetInfoBuilder>(RuleSet.DungeonsandDragons);
                default:
                    throw new PPGException($"Could not resolve a Meta Data Builder for the Rule Set {ruleSet}");
            }
        }
    }
}
