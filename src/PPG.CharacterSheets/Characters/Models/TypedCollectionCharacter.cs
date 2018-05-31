using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Core;

namespace PPG.CharacterSheets.Characters.Models
{
    public abstract class TypedCharacter<TStatType, TMetaDataType> : IIdentifiable
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }

        public RuleSet RuleSet { get; set; }

        public int Experience { get; set; }

        public TStatType Stats { get; set; }

        public TMetaDataType MetaData { get; set; }
    }
}
