using System.Linq;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Core.Services
{
    public interface ICRUDService<TEntityType, TModelType> where TEntityType : class, IIdentifiable where TModelType : class, IIdentifiable
    {
        Task<TModelType> Create(TModelType entity);

        Task<TModelType> Read(int id);
        Task<IQueryable<TModelType>> Read();

        Task<TModelType> Update(TModelType entity);

        Task Delete(int id);
    }
}
