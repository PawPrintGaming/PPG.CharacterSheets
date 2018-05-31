﻿using PPG.CharacterSheets.Characters.Models;
using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.DTOs
{
    public class CharacterSummary : TypedCharacter<
        Dictionary<string, int>,
        Dictionary<string, string>
    >
    {
    }
}
