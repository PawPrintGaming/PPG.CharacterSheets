using PPG.CharacterSheets.Characters.DTOs;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services
{
    public interface ICharacterPolymorphService
    {
        Task<CharacterSummary> UpdatePropertyByName(CharacterSummary characterSummary, string propName, object value);
        Task<CharacterSummary> UpdateStatByName(CharacterSummary characterSummary, string statName, object value);
        Task<CharacterSummary> UpsertSkillByName(CharacterSummary characterSummary, Skill skill);
        Task<CharacterSummary> UpdateMetaData(CharacterSummary characterSummary, string dataKey, string value);
        Task<CharacterSummary> UpdateSkillTriggerDescription(CharacterSummary characterSummary, string skillName, string triggerName, string updatedDescription);
        Task<CharacterSummary> DeleteSkillTrigger(CharacterSummary characterSummary, string skillName, string triggerName);
        Task<CharacterSummary> UpdateSkillRank(CharacterSummary characterSummary, string skillName, object rank);
    }
}
