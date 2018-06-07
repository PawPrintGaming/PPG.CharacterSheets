using PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Enums;
using PPG.CharacterSheets.Core.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace PPG.CharacterSheets._RuleSets.DungeonsAndDragons.Helpers
{
    public static class AlignmentsHelper
    {
        public static IEnumerable<string> GetAlignments()
        {
            var horizontals = EnumHelper.GetAllStringValesForEnum<AlignmentsHorizontal>();
            var verticals = EnumHelper.GetAllStringValesForEnum<AlignmentsVertical>();

            return horizontals.SelectMany(horizontal =>
                verticals.Select(vertical =>
                    horizontal.ToString() == vertical.ToString()
                        ? horizontal.ToString()
                        : $"{horizontal} {vertical}"
                )
            );
        }
    }
}
