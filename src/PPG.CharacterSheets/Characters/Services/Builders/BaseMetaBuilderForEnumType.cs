using PPG.CharacterSheets.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services.Builders
{
    public abstract class BaseMetaBuilderForEnumType<TMetaDataEnumType> : IMetaDataBuilder where TMetaDataEnumType : struct, IConvertible
    {
        protected abstract string defaultValue { get; }

        public async Task<Dictionary<string, string>> Build(Dictionary<string, string> build, bool trim = true)
        {
            if (build == null)
            {
                build = new Dictionary<string, string>();
            }

            var statNames = EnumHelper.GetAllStringValesForEnum<TMetaDataEnumType>();
            statNames.ToList().ForEach(name => build.AddKeyIfNotPresent(name, defaultValue));

            if (trim)
            {
                build.Keys.ToList().ForEach(key =>
                {
                    if (!statNames.Contains(key))
                    {
                        build.Remove(key);
                    }
                });
            }

            return build;
        }
    }
}
