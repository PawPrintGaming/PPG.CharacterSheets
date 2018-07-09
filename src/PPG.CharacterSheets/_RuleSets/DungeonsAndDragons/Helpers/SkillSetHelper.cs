using PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Enums;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Core.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Helpers
{
    public static class SkillSetHelper
    {
        public static Dictionary<string, IEnumerable<SkillInfo>> AddDefaultSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.Acrobatics,     StatNames.Dexterity),
                BuildSkillInfo(SkillNames.AnimalHandling, StatNames.Wisdom),
                BuildSkillInfo(SkillNames.Arcana,         StatNames.Intelligence),
                BuildSkillInfo(SkillNames.Athletics,      StatNames.Strength),
                BuildSkillInfo(SkillNames.Deception,      StatNames.Charisma),
                BuildSkillInfo(SkillNames.History,        StatNames.Intelligence),
                BuildSkillInfo(SkillNames.Insight,        StatNames.Wisdom),
                BuildSkillInfo(SkillNames.Intimidation,   StatNames.Charisma),
                BuildSkillInfo(SkillNames.Investigation,  StatNames.Intelligence),
                BuildSkillInfo(SkillNames.Medicine,       StatNames.Wisdom),
                BuildSkillInfo(SkillNames.Nature,         StatNames.Intelligence),
                BuildSkillInfo(SkillNames.Perception,     StatNames.Wisdom),
                BuildSkillInfo(SkillNames.Performance,    StatNames.Charisma),
                BuildSkillInfo(SkillNames.Persuasion,     StatNames.Charisma),
                BuildSkillInfo(SkillNames.Religion,       StatNames.Intelligence),
                BuildSkillInfo(SkillNames.SleightOfHand,  StatNames.Dexterity),
                BuildSkillInfo(SkillNames.Stealth,        StatNames.Dexterity),
                BuildSkillInfo(SkillNames.Survival,       StatNames.Wisdom)
            };
            return dictionary.AddSkillSet("Default", skills);
        }

        public static Dictionary<string, IEnumerable<SkillInfo>> AddSavingThrows(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var savingThrows = EnumHelper.GetAllStringValesForEnum<StatNames>().Select(name =>
                new SkillInfo { Name = name.ToString().AddSpacesToCamelCase(), StatKeys = new [] {name.AddSpacesToCamelCase()} }
            );
            return dictionary.AddSkillSet("SavingThrows", savingThrows);
        }

        private static SkillInfo BuildSkillInfo(SkillNames name, StatNames associatedStat)
        {
            return BuildSkillInfo(name, new[] { associatedStat });
        }
        private static SkillInfo BuildSkillInfo(SkillNames name, IEnumerable<StatNames> associatedStats)
        {
            return new SkillInfo { Name = name.ToString().AddSpacesToCamelCase(), StatKeys = associatedStats.ToList().Select(s => s.ToString().AddSpacesToCamelCase()) };
        }

        private static Dictionary<string, IEnumerable<SkillInfo>> AddSkillSet(this Dictionary<string, IEnumerable<SkillInfo>> dictionary, string key, IEnumerable<SkillInfo> skillInfos)
        {
            var stringKey = key.AddSpacesToCamelCase();
            if (dictionary.ContainsKey(stringKey))
            {
                dictionary[stringKey] = skillInfos;
            }
            else
            {
                dictionary.Add(stringKey, skillInfos);
            }
            return dictionary;
        }
    }
}
