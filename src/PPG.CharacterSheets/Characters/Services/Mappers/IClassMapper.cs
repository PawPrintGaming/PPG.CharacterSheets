using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Core.Services;
using System.Collections.Generic;

namespace PPG.CharacterSheets.Characters.Services.Mappers
{
    public interface IClassMapper : IMapper<IEnumerable<Class>, IEnumerable<CreateClass>>
    {
    }
}
