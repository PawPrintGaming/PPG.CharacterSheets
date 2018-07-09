using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class SkillInfo
    {
        public string Name { get; set; }
        public IEnumerable<string> StatKeys { get; set; }
    }
}
