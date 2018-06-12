using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class CreateCharacter
    {
        public string CharacterName { get; set; }

        public string RuleSet { get; set; }

        public IEnumerable<KeyValuePair<string, int>> Stats { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MetaData { get; set; }
    }
}
