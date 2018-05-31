using PPG.CharacterSheets.Characters.Services.Builders;

namespace PPG.CharacterSheets._RuleSets.DungeonsAndDragons
{
    public class StatBuilder : BaseStatBuilderForEnumType<StatNames>
    {
        protected override int defaultValue => 0;
    }
}
