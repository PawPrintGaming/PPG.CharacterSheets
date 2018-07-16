using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services.Mappers
{
    public interface IAbilityMapper : IMapper<IEnumerable<Ability>, IEnumerable<CreateAbility>>
    {

    }
}
