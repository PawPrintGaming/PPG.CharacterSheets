using PPG.CharacterSheets.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services.Builders
{
    public abstract class BaseStatBuilderForEnumType<TStatEnumType> : IStatBuilder where TStatEnumType : struct, IConvertible
    {
        protected abstract int defaultValue { get; }

        public async Task<Dictionary<string, int>> Build(Dictionary<string, int> build, bool trim = true)
        {
            if (build == null)
            {
                build = new Dictionary<string, int>();
            }

            var statNames = EnumHelper.GetAllStringValesForEnum<TStatEnumType>();
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
