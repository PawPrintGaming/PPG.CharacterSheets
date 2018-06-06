using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPG.CharacterSheets._RuleSets.MalifaxTtB.Enums;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Services.Builders;
using PPG.CharacterSheets.Core.Helpers;

namespace PPG.CharacterSheets._RuleSets.MalifaxTtB.Builders
{
    public class CreateCharacterInfoBuilder : ICreateCharacterInfoBuilder
    {
        public async Task<CreateCharacterInfo> Build(CreateCharacterInfo build, bool trim = true)
        {
            return await Task.Run(() => {
                var physical = new List<StatNames> { StatNames.Might, StatNames.Grace, StatNames.Speed, StatNames.Resilience };
                var mental = new List<StatNames> { StatNames.Intellect, StatNames.Charm, StatNames.Cunning, StatNames.Tenancity };
                var statSets = new Dictionary<string, IEnumerable<string>>
                {
                    {"Physical", physical.Select(n => n.ToString().AddSpacesToCamelCase())},
                    {"Mental", mental.Select(n => n.ToString().AddSpacesToCamelCase())}
                };

                var stations = EnumHelper.GetAllStringValesForEnum<Stations>().Select(s => s.AddSpacesToCamelCase());
                var pursuits = EnumHelper.GetAllStringValesForEnum<Pursuits>().Select(s => s.AddSpacesToCamelCase());
                var dataLists = new Dictionary<string, IEnumerable<string>>
                {
                    {"Stations", stations},
                    {"Pursuits", pursuits}
                };

                return new CreateCharacterInfo
                {
                    StatSets = statSets,
                    DataLists = dataLists
                };
            });
        }
    }
}
