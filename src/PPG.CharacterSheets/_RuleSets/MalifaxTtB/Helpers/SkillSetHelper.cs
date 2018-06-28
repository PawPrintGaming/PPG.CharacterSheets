using PPG.CharacterSheets._RuleSets.MalifaxTtB.Enums;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Core.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace PPG.CharacterSheets._RuleSets.MalifaxTtB.Helpers
{
    public static class SkillSetHelper
    {
        public static Dictionary<string, IEnumerable<SkillInfo>> AddAcademicSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.Art,          StatNames.Cunning),
                BuildSkillInfo(SkillNames.Bureacracy,   StatNames.Cunning),
                BuildSkillInfo(SkillNames.Engineering,  StatNames.Intellect),
                BuildSkillInfo(SkillNames.Mathematics,  StatNames.Intellect),
                BuildSkillInfo(SkillNames.History,      StatNames.Intellect),
                BuildSkillInfo(SkillNames.Literacy,     StatNames.Cunning)
            };
            return dictionary.AddSkillSet(SkillCategoryNames.Academic, skills);
        }
        public static Dictionary<string, IEnumerable<SkillInfo>> AddCloseCombatSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.Flexible,     StatNames.Grace),
                BuildSkillInfo(SkillNames.HeavyMelee,   StatNames.Might),
                BuildSkillInfo(SkillNames.MartialArts,  StatNames.Speed),
                BuildSkillInfo(SkillNames.Melee,        StatNames.Might),
                BuildSkillInfo(SkillNames.Pnematic,     StatNames.Might),
                BuildSkillInfo(SkillNames.Pugilism,     StatNames.Might)
            };
            return dictionary.AddSkillSet(SkillCategoryNames.CloseCombat, skills);
        }
        public static Dictionary<string, IEnumerable<SkillInfo>> AddCraftingSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.Alchemistry,   StatNames.Intellect),
                BuildSkillInfo(SkillNames.Artefacting,   StatNames.Cunning),
                BuildSkillInfo(SkillNames.Blacksmithing, StatNames.Intellect),
                BuildSkillInfo(SkillNames.Farming,       StatNames.Tenancity),
                BuildSkillInfo(SkillNames.Homesteading,  StatNames.Tenancity),
                BuildSkillInfo(SkillNames.Printing,      StatNames.Intellect),
                BuildSkillInfo(SkillNames.Stitching,     StatNames.Cunning)
            };
            return dictionary.AddSkillSet(SkillCategoryNames.Crafting, skills);
        }
        public static Dictionary<string, IEnumerable<SkillInfo>> AddExpertiseSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.Appraise,     StatNames.Cunning),
                BuildSkillInfo(SkillNames.Doctor,       StatNames.Intellect),
                BuildSkillInfo(SkillNames.Explosives,   StatNames.Intellect),
                BuildSkillInfo(SkillNames.Forgery,      StatNames.Cunning),
                BuildSkillInfo(SkillNames.Gambling,     StatNames.Cunning),
                BuildSkillInfo(SkillNames.Husbandry,    StatNames.Charm),
                BuildSkillInfo(SkillNames.Lockpicking,  StatNames.Grace),
                BuildSkillInfo(SkillNames.Music,        StatNames.Charm),
                BuildSkillInfo(SkillNames.Navigation,   StatNames.Tenancity),
                BuildSkillInfo(SkillNames.PickPocket,   StatNames.Speed),
                BuildSkillInfo(SkillNames.Scrutiny,     StatNames.Cunning),
                BuildSkillInfo(SkillNames.Track,        StatNames.Cunning),
                BuildSkillInfo(SkillNames.Wilderness,   StatNames.Cunning),
            };
            return dictionary.AddSkillSet(SkillCategoryNames.Expertise, skills);
        }
        public static Dictionary<string, IEnumerable<SkillInfo>> AddMagicalSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.CounterSpelling,  StatNames.Tenancity),
                BuildSkillInfo(SkillNames.Enchanting,       new[]{StatNames.Charm, StatNames.Cunning }),
                BuildSkillInfo(SkillNames.HarnessSoulstone, StatNames.Charm),
                BuildSkillInfo(SkillNames.Necromancy,       new[]{StatNames.Charm, StatNames.Tenancity }),
                BuildSkillInfo(SkillNames.Sorcery,          new[]{StatNames.Intellect, StatNames.Tenancity }),
                BuildSkillInfo(SkillNames.Presidigitation,  new[]{StatNames.Cunning, StatNames.Intellect })
            };
            return dictionary.AddSkillSet(SkillCategoryNames.Magical, skills);
        }
        public static Dictionary<string, IEnumerable<SkillInfo>> AddRangedCombatSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.Archery,          StatNames.Grace),
                BuildSkillInfo(SkillNames.HeavyGuns,        StatNames.Might),
                BuildSkillInfo(SkillNames.LongArms,         StatNames.Intellect),
                BuildSkillInfo(SkillNames.Pistol,           StatNames.Grace),
                BuildSkillInfo(SkillNames.Shotgun,          StatNames.Grace),
                BuildSkillInfo(SkillNames.ThrownWeapons,    StatNames.Grace)
            };
            return dictionary.AddSkillSet(SkillCategoryNames.RangedCombat, skills);
        }
        public static Dictionary<string, IEnumerable<SkillInfo>> AddSocialSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.Barter,       StatNames.Tenancity),
                BuildSkillInfo(SkillNames.Bewitch,      StatNames.Charm),
                BuildSkillInfo(SkillNames.Convince,     StatNames.Intellect),
                BuildSkillInfo(SkillNames.Deceive,      StatNames.Intellect),
                BuildSkillInfo(SkillNames.Intimidate,   StatNames.Tenancity),
                BuildSkillInfo(SkillNames.Leadership,   StatNames.Charm),
                BuildSkillInfo(SkillNames.Teach,        StatNames.Intellect)
            };
            return dictionary.AddSkillSet(SkillCategoryNames.Social, skills);
        }
        public static Dictionary<string, IEnumerable<SkillInfo>> AddTrainingSkills(this Dictionary<string, IEnumerable<SkillInfo>> dictionary)
        {
            var skills = new List<SkillInfo>
            {
                BuildSkillInfo(SkillNames.Acrobatics,   StatNames.Grace),
                BuildSkillInfo(SkillNames.Athletics,    StatNames.Might),
                BuildSkillInfo(SkillNames.Carouse,      StatNames.Resilience),
                BuildSkillInfo(SkillNames.Centering,    StatNames.Tenancity),
                BuildSkillInfo(SkillNames.Evade,        StatNames.Speed),
                BuildSkillInfo(SkillNames.Labor,        StatNames.Resilience),
                BuildSkillInfo(SkillNames.Notice,       StatNames.Cunning),
                BuildSkillInfo(SkillNames.Stealth,      StatNames.Cunning),
                BuildSkillInfo(SkillNames.Toughness,    StatNames.Resilience)
            };
            return dictionary.AddSkillSet(SkillCategoryNames.Training, skills);
        }

        private static SkillInfo BuildSkillInfo(SkillNames name, StatNames associatedStat)
        {
            return BuildSkillInfo(name, new[] { associatedStat });
        }
        private static SkillInfo BuildSkillInfo(SkillNames name, IEnumerable<StatNames> associatedStats)
        {
            return new SkillInfo { Name = name.ToString().AddSpacesToCamelCase(), StatKeys = associatedStats.ToList().Select(s => s.ToString().AddSpacesToCamelCase()) };
        }

        private static Dictionary<string, IEnumerable<SkillInfo>> AddSkillSet(this Dictionary<string, IEnumerable<SkillInfo>> dictionary, SkillCategoryNames key, IEnumerable<SkillInfo> skillInfos)
        {
            var stringKey = key.ToString().AddSpacesToCamelCase();
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
