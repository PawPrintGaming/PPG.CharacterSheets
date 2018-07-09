using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Core;
using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class CharacterSummary : IIdentifiable
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }

        public RuleSet RuleSet { get; set; }

        public int Experience { get; set; }

        public Dictionary<string, int> Stats { get; set; }

        public Dictionary<string, string> MetaData { get; set; }

        public IEnumerable<Skill> Skills { get; set; }

        //public IEnumerable<Class> Classes { get; set; }
    }
}
