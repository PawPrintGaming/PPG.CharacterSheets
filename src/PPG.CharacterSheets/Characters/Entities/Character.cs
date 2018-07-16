using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPG.CharacterSheets.Characters.Entities
{
    [Table("Characters")]
    public class Character : IIdentifiable
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }

        public RuleSet RuleSet { get; set; }

        public string Stats { get; set; }

        public string MetaData { get; set; }

        public string Skills { get; set; }

        public string Wallets { get; set; }

        public string Classes { get; set; }

        public string Abilities { get; set; }
    }
}
