using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Repositories;

namespace FarmerApp.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        Task SaveChangesAsync();
    }
}
