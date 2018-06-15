using PPG.CharacterSheets.Characters.DTOs;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services
{
    public interface ICharacterPolymorphService
    {
        Task<CharacterSummary> UpdatePropertyByName(CharacterSummary characterSummary, string propName, object value);
        Task<CharacterSummary> UpdateStatByName(CharacterSummary characterSummary, string statName, object value);
        Task<CharacterSummary> UpdateMetaData(CharacterSummary characterSummary, string dataKey, string value);
    }
}
