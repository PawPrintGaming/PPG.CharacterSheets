using PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Enums;
using PPG.CharacterSheets.Characters.Services.Builders;

namespace PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Builders
{
    public class StatBuilder : BaseStatBuilderForEnumType<StatNames>
    {
        protected override int defaultValue => 0;
    }
}
