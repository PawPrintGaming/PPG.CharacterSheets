using PPG.CharacterSheets.Store;

namespace PPG.CharacterSheets.Core.Services
{
    public class PassThroughCRUDService<TEntityType> : CRUDService<TEntityType, TEntityType>, ICRUDService<TEntityType> where TEntityType : class, IIdentifiable
    {
        public PassThroughCRUDService(IMapper<TEntityType> mapper, IRepository<TEntityType> repository)
            : base(mapper, repository)
        {}
    }
}
