﻿using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPG.CharacterSheets.RuleSets.Entities
{
    [Table("RuleSets")]
    public class RuleSetInfo : IIdentifiable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RuleSet RuleSet { get; set; }

        public string CoverImageUrl { get; set; }
    }
}
