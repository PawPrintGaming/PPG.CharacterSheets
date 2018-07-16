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
        public Dictionary<string, int> Stats { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public Dictionary<string, double> Wallets { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Ability> Abilities { get; set; }
    }

    public class Skill
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, string>>> MetaData { get; set; }
    }

    public class Class
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
    }
}
