﻿using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services;

namespace PPG.CharacterSheets.Characters.Factories
{
    public interface IMetaDataBuilderFactory
    {
        IMetaDataBuilder Resolve(RuleSet ruleSet);
    }
}
