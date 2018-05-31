using System.Threading.Tasks;

namespace PPG.CharacterSheets.Core.Services
{
    public interface IBuilder<TBuilderType>
    {
        Task<TBuilderType> Build(TBuilderType build, bool trim = true);
    }
}
