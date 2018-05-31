using PPG.CharacterSheets.Characters.Models;
using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class UpdateCharacter : TypedCharacter<
        IEnumerable<KeyValuePair<string, int>>,
        IEnumerable<KeyValuePair<string, string>>
    >
    {
    }
}
