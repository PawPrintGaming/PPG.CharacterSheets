using PPG.CharacterSheets.Characters.Services;
using PPG.CharacterSheets.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPG.CharacterSheets._RuleSets.MalifaxTtB
{
    public class StatBuilder : IStatBuilder
    {
        public async Task<Dictionary<string, int>> Build(Dictionary<string, int> build)
        {
            if (build == null)
            {
                build = new Dictionary<string, int>();
            }

            var statNames = EnumHelper.GetAllStringValesForEnum<StatNames>();
            statNames.ToList().ForEach(name => build.AddKeyIfNotPresent(name, 0));

            return build;
        }
    }
}
