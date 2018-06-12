using PPG.CharacterSheets.Characters.DTOs;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services
{
    public interface ICharacterPolymorphService
    {
        Task<CharacterSummary> UpdatePropertyByName(CharacterSummary characterSummary, string propName, object value);
    }
}
