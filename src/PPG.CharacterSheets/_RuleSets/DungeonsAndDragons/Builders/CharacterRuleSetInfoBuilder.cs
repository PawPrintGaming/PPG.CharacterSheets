using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Enums;
using PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Helpers;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Services.Builders;
using PPG.CharacterSheets.Core.Helpers;

namespace PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Builders
{
    public class CharacterRuleSetInfoBuilder : ICharacterRuleSetInfoBuilder
    {
        public async Task<CharacterRuleSetInfo> Build(CharacterRuleSetInfo build, bool trim = true)
        {
            return await Task.Run(() =>
            {
                var stats = EnumHelper.GetAllStringValesForEnum<StatNames>().Select(s => s.AddSpacesToCamelCase());
                var statSets = new Dictionary<string, IEnumerable<string>> {
                    {"stats", stats}
                };

                var alignments = AlignmentsHelper.GetAlignments();
                var backgrounds = EnumHelper.GetAllStringValesForEnum<Backgrounds>().Select(s => s.AddSpacesToCamelCase());
                var classes = EnumHelper.GetAllStringValesForEnum<Classes>().Select(s => s.AddSpacesToCamelCase());
                var races = EnumHelper.GetAllStringValesForEnum<Races>().Select(s => s.AddSpacesToCamelCase());
                var dataLists = new Dictionary<string, IEnumerable<string>> {
                    {"Alignments", alignments},
                    {"Backgrounds", backgrounds},
                    {"Classes", classes},
                    {"Races", races }
                };

                return new CharacterRuleSetInfo
                {
                    StatSets = statSets,
                    DataLists = dataLists
                };
            });
        }
    }
}
