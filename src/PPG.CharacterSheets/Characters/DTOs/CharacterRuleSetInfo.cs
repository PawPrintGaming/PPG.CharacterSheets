using PPG.CharacterSheets._RuleSets;
using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class CharacterRuleSetInfo
    {
        public RuleSet RuleSet { get; set; }
        public Dictionary<string, IEnumerable<string>> StatSets { get; set; }
        public Dictionary<string, IEnumerable<SkillInfo>> SkillInfoSets { get; set; }
        public Dictionary<string, IEnumerable<string>> DataLists { get; set; }
    }
}
