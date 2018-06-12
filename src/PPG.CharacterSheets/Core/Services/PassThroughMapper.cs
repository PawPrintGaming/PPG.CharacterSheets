using System.Threading.Tasks;
using PPG.CharacterSheets.Core.Services;

namespace PPG.CharacterSheets.Core.Services
{
    public class PassThroughMapper<TEntityType> : IMapper<TEntityType>
    {
        public async Task<TEntityType> MapFrom(TEntityType to)
        {
            return to;
        }

        public async Task<TEntityType> MapTo(TEntityType from)
        {
            return from;
        }
    }
}
