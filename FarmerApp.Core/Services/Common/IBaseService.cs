using FarmerApp.Core.Models;
using FarmerApp.Core.Query;
using FarmerApp.Core.Wrappers;
using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Core.Services.Common
{
    public interface IBaseService<TModel, TEntity>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        Task<TModel> GetById(int id, bool includeDeleted = false, int depth = 1, IEnumerable<string> propertyTypesToExclude = default);
        Task<TModel> GetFirstBySpecification(ISpecification<TEntity> specification, bool includeDeleted = false, int depth = 1, IEnumerable<string> propertyTypesToExclude = default);
        Task<PagedResult<TModel>> GetAll(BaseQueryModel query = null, bool includeDeleted = false, int depth = 1, IEnumerable<string> propertyTypesToExclude = default);
        Task<PagedResult<TModel>> GetAll(ISpecification<TEntity> specification, BaseQueryModel query = null, bool includeDeleted = false, int depth = 1, IEnumerable<string> propertyTypesToExclude = default);
        Task<TModel> Add(TModel model, int depth = 1, IEnumerable<string> propertyTypesToExclude = default);
        Task<TModel> Update(TModel model, int depth = 1, IEnumerable<string> propertyTypesToExclude = default);
        Task Delete(TModel model);
        Task Delete(int id);
    }
}
