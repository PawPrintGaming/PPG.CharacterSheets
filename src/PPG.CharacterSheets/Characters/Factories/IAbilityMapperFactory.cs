using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services.Mappers;

namespace PPG.CharacterSheets.Characters.Factories
{
    public interface IAbilityMapperFactory
    {
        IAbilityMapper Resolve(RuleSet ruletSet);
    }
}
