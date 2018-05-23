using System.Threading.Tasks;

namespace PPG.CharacterSheets.Core.Services
{
    public interface IMapper<TEntityTo, TEntityFrom>
    {
        Task<TEntityTo> MapTo(TEntityFrom from);

        Task<TEntityFrom> MapFrom(TEntityTo to);
    }
}
