using System;
using System.Collections.Generic;
using System.Linq;

namespace PPG.CharacterSheets.GraphQL.Helpers
{
    public static class MapTypeHelper
    {
        public static IEnumerable<KeyValuePair<TKeyType, TValueType>> AsMapType<TKeyType, TValueType>(this Dictionary<TKeyType, TValueType> dictionary)
        {
            return dictionary.Keys.Select(key =>
                new KeyValuePair<TKeyType, TValueType>(key, dictionary[key])
            );
        }

        public static Dictionary<TKeyType, TValueType> AsDictionary<TKeyType, TValueType>(this IEnumerable<KeyValuePair<TKeyType, TValueType>> keyValues)
        {
            var dictionary = new Dictionary<TKeyType, TValueType>();
            keyValues.ToList().ForEach(keyValue =>
            {
                dictionary.Add(keyValue.Key, keyValue.Value);
            });
            return dictionary;
        }
    }
}
