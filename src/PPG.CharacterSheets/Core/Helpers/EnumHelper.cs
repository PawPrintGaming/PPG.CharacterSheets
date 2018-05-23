using System;
using System.Collections.Generic;

namespace PPG.CharacterSheets.Core.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<string> GetAllStringValesForEnum<TType>() where TType : struct, IConvertible
        {
            return Enum.GetNames(typeof(TType));
        }
    }
}
