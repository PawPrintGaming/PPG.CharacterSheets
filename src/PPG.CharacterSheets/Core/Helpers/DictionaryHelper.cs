using System.Collections.Generic;
using System.Linq;

namespace PPG.CharacterSheets.Core.Helpers
{
    public static class DictionaryHelper
    {
        public static Dictionary<TKey, TValue> AddKeyIfNotPresent<TKey, TValue> (this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if(!dictionary.Keys.Contains(key))
            {
                dictionary.Add(key, defaultValue);
            }
            return dictionary;
        }
    }
}
