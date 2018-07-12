using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class CreateCharacter
    {
        public string CharacterName { get; set; }
        public string RuleSet { get; set; }
        public IEnumerable<KeyValuePair<string, int>> Stats { get; set; }
        public IEnumerable<KeyValuePair<string, string>> MetaData { get; set; }
        public IEnumerable<CreateSkill> Skills { get; set; }
        public IEnumerable<KeyValuePair<string, double>> Wallets { get; set; }
    }

    public class CreateSkill
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public IEnumerable<KeyValuePair<string, IEnumerable<KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>>>> MetaData { get; set; }
    }
}
