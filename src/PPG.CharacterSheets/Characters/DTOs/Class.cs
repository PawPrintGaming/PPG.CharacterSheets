using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class Class
    {
        public string Name { get; set; }

        public int Rank { get; set; }

        public Dictionary<string, IEnumerable<string>> MetaData { get; set; }
    }
}