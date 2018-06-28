using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class Skill
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, string>>> MetaData { get; set; }
    }
}
