using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class CreateCharacter
    {
        public string CharacterName { get; set; }

        public string Ruleset { get; set; }

        public Dictionary<string, int> Stats { get; set; }

        public Dictionary<string, string> MetaData { get; set; }
    }
}
