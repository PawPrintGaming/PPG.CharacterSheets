using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPG.CharacterSheets._RuleSets.MalifaxTtB.Enums;
using PPG.CharacterSheets._RuleSets.MalifaxTtB.Helpers;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Services.Builders;
using PPG.CharacterSheets.Core.Helpers;

namespace PPG.CharacterSheets._RuleSets.MalifaxTtB.Builders
{
    public class CharacterRuleSetInfoBuilder : ICharacterRuleSetInfoBuilder
    {
        public async Task<CharacterRuleSetInfo> Build(CharacterRuleSetInfo build, bool trim = true)
        {
            return await Task.Run(async () => {
                var statSets = await BuildStatSets().ConfigureAwait(false);
                var dataLists = await BuildDataLists().ConfigureAwait(false);
                var skillInfoSets = await BuildSkillInfoSets().ConfigureAwait(false);
                

                return new CharacterRuleSetInfo
                {
                    StatSets = statSets,
                    DataLists = dataLists,
                    SkillInfoSets = skillInfoSets
                };
            });
        }

        private async Task<Dictionary<string, IEnumerable<string>>> BuildStatSets()
        {
            return await Task.Run(() =>
            {
                var physical = new List<StatNames> { StatNames.Might, StatNames.Grace, StatNames.Speed, StatNames.Resilience };
                var mental = new List<StatNames> { StatNames.Intellect, StatNames.Charm, StatNames.Cunning, StatNames.Tenancity };
                var statSets = new Dictionary<string, IEnumerable<string>>
                {
                    {"Physical", physical.Select(n => n.ToString().AddSpacesToCamelCase())},
                    {"Mental", mental.Select(n => n.ToString().AddSpacesToCamelCase())}
                };
                return statSets;
            });
        }

        private async Task<Dictionary<string, IEnumerable<string>>> BuildDataLists()
        {
            return await Task.Run(() =>
            {
                var stations = EnumHelper.GetAllStringValesForEnum<Stations>().Select(s => s.AddSpacesToCamelCase());
                var pursuits = EnumHelper.GetAllStringValesForEnum<Pursuits>().Select(s => s.AddSpacesToCamelCase());
                var dataLists = new Dictionary<string, IEnumerable<string>>
                {
                    {"Stations", stations},
                    {"Pursuits", pursuits}
                };
                return dataLists;
            });
        }

        private async Task<Dictionary<string, IEnumerable<SkillInfo>>> BuildSkillInfoSets()
        {
            return await Task.Run(() =>
            {
                return new Dictionary<string, IEnumerable<SkillInfo>>()
                    .AddAcademicSkills()
                    .AddCloseCombatSkills()
                    .AddCraftingSkills()
                    .AddExpertiseSkills()
                    .AddMagicalSkills()
                    .AddRangedCombatSkills()
                    .AddSocialSkills()
                    .AddTrainingSkills();
            });
        }
    }
}
