using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPG.CharacterSheets.Characters.Services;
using PPG.CharacterSheets.Core.Helpers;

namespace PPG.CharacterSheets._RuleSets.MalifaxTtB
{
    public class MetaDataBuilder : IMetaDataBuilder
    {
        public async Task<Dictionary<string, string>> Build(Dictionary<string, string> build)
        {
            if (build == null)
            {
                build = new Dictionary<string, string>();
            }

            var statNames = EnumHelper.GetAllStringValesForEnum<MetaDataNames>();
            statNames.ToList().ForEach(name => build.AddKeyIfNotPresent(name, null));

            return build;
        }
    }
}
