using System;
using System.Reflection;
using System.Threading.Tasks;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.ErrorHandling;

namespace PPG.CharacterSheets.Characters.Services
{
    public class CharacterPolymorphService : ICharacterPolymorphService
    {
        public async Task<CharacterSummary> UpdatePropertyByName(CharacterSummary characterSummary, string propName, object value)
        {
            var propertyInfo = typeof(CharacterSummary).GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                throw new PPGException($"Could not find property {propName} on Character Summary");
            }
            if (!propertyInfo.CanWrite)
            {
                throw new PPGException($"Property {propName} on Character Summary is read only");
            }
            try
            {
                var castValue = Convert.ChangeType(value, propertyInfo.PropertyType);
                propertyInfo.SetValue(characterSummary, value);
                return characterSummary;
            }
            catch
            {
                throw new PPGException($"Cannot assign {value} to property {propName} of Type {propertyInfo.PropertyType.Name} on Character Summary");
            }
        }
    }
}
