using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Core.Services;
using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.Services.Builders
{
    public interface ISkillMapper : IMapper<IEnumerable<Skill>, IEnumerable<CreateSkill>>
    {
    }
}
