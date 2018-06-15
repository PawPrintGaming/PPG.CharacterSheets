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
            catch (InvalidCastException)
            {
                throw new PPGException($"Cannot assign {value} to property {propName} of Type {propertyInfo.PropertyType.Name} on Character Summary");
            }
        }

        public async Task<CharacterSummary> UpdateStatByName(CharacterSummary characterSummary, string statName, object value)
        {
            if (!int.TryParse(value.ToString(), out int castValue))
            {
                throw new PPGException($"Cannot convert {value} of type {value.GetType().Name} to an integer, not suitable for updating Character Summary Stat");
            }
            if (characterSummary.Stats.ContainsKey(statName))
            {
                characterSummary.Stats[statName] = castValue;
            }
            else
            {
                characterSummary.Stats.Add(statName, castValue);
            }
            return characterSummary;
        }

        public async Task<CharacterSummary> UpdateMetaData(CharacterSummary characterSummary, string dataKey, string value)
        {
            if (characterSummary.MetaData.ContainsKey(dataKey))
            {
                characterSummary.MetaData[dataKey] = value;
            }
            else
            {
                characterSummary.MetaData.Add(dataKey, value);
            }
            return characterSummary;
        }
    }
}
