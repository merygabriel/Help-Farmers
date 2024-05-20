using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Specifications.Common;
using FarmerApp.Shared.Enums;
using System.Linq.Expressions;

namespace FarmerApp.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll(bool includeDeleted = false);

        Task<List<TEntity>> GetAllBySpecification(ISpecification<TEntity> specification, bool includeDeleted = false);

        Task<TEntity> GetById(int id, bool includeDeleted = false, IEnumerable<string> propertyNamesToInclude = default);

        Task<TEntity> GetFirstBySpecification(ISpecification<TEntity> specification, bool includeDeleted = false);


        Task Add(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);


        Task Delete(int id, DeleteOptions deleteOption = DeleteOptions.Soft);

        void Delete(TEntity entity, DeleteOptions deleteOption = DeleteOptions.Soft);

        void DeleteRange(IEnumerable<TEntity> entities, DeleteOptions deleteOption = DeleteOptions.Soft);

        Task<int> Count(ISpecification<TEntity> specification = null, bool includeDeleted = false);
        Task<double> Sum(Expression<Func<TEntity, double>> propertySelector, ISpecification<TEntity> specification = null, bool includeDeleted = false);
    }
}
