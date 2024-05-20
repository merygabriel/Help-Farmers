using FarmerApp.Data.DAO;
using FarmerApp.Data.Entities;
using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Specifications;
using FarmerApp.Data.Specifications.Common;
using FarmerApp.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FarmerApp.Data.Repositories
{
    internal class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly FarmerDbContext _context;

        public BaseRepository(FarmerDbContext context)
        {
            _context = context;
        }

        #region Public methods

        public async Task<IEnumerable<TEntity>> GetAll(bool includeDeleted = false)
        {
            var entities = _context.Set<TEntity>().AsQueryable();

            if (includeDeleted)
            {
                entities = entities.IgnoreQueryFilters();
            }

            return await entities.ToListAsync();
        }
        public async Task<List<TEntity>> GetAllBySpecification(ISpecification<TEntity> specification, bool includeDeleted = false)
        {
            var result = await ApplySpecification(specification, includeDeleted).ToListAsync();
            return result;
        }

        public async Task<TEntity> GetById(int id, bool includeDeleted = false, IEnumerable<string> propertyNamesToInclude = default)
        {
            var entities = _context.Set<TEntity>().AsQueryable();

            if (propertyNamesToInclude is not null)
            {
                foreach (var propertyName in propertyNamesToInclude)
                {
                    entities = entities.Include(propertyName);
                }
            }

            if (includeDeleted)
            {
                entities = entities.IgnoreQueryFilters();
            }

            return await entities.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TEntity> GetFirstBySpecification(ISpecification<TEntity> specification, bool includeDeleted = false)
        {
            var result = ApplySpecification(specification, includeDeleted);

            return await result.FirstOrDefaultAsync();
        }

        
        public async Task Add(TEntity entity)
        {
            await _context.AddAsync(entity);
        }
        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            TryAttachEntity(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        

        public async Task Delete(int id, DeleteOptions deleteOption = DeleteOptions.Soft)
        {
            var entity = await GetById(id);

            switch (deleteOption)
            {
                case DeleteOptions.Soft:
                    SoftDelete(entity);
                    break;
                case DeleteOptions.Hard:
                    HardDelete(entity);
                    break;
                default:
                    break;
                
            }
        }

        public void Delete(TEntity entity, DeleteOptions deleteOption = DeleteOptions.Soft)
        {
            switch (deleteOption)
            {
                case DeleteOptions.Soft:
                    SoftDelete(entity);
                    break;
                case DeleteOptions.Hard:
                    HardDelete(entity);
                    break;
                default:
                    break;
            }
        }

        public void DeleteRange(IEnumerable<TEntity> entities, DeleteOptions deleteOption = DeleteOptions.Soft)
        {
            switch (deleteOption)
            {
                case DeleteOptions.Soft:
                    foreach (var entity in entities)
                    {
                        SoftDelete(entity);
                    }
                    break;
                case DeleteOptions.Hard:
                    HardDeleteRange(entities);
                    break;
                default:
                    break;
            }
            _context.Set<TEntity>().RemoveRange(entities);
        }


        public async Task<int> Count(ISpecification<TEntity> specification = null, bool includeDeleted = false)
        {
            if (specification == null)
            {
                specification = new EmptySpecification<TEntity>();
            }

            var query = ApplySpecification(specification, includeDeleted).AsNoTracking();
            var count = await query.CountAsync();

            return count;
        }

        public async Task<double> Sum(Expression<Func<TEntity, double>> propertySelector, ISpecification<TEntity> specification = null, bool includeDeleted = false)
        {
            if (specification == null)
            {
                specification = new EmptySpecification<TEntity>();
            }

            var query = ApplySpecification(specification, includeDeleted).AsNoTracking();
            var sum = await query.SumAsync(propertySelector);

            return sum;
        }

        #endregion

        #region Private methods

        private void SoftDelete(TEntity entity)
        {
            entity.IsDeleted = true;
        }

        private void HardDelete(TEntity entity)
        {
            _context.Remove(entity);
        }

        private void HardDeleteRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification, bool includeDeleted)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (includeDeleted)
            {
                query = query.IgnoreQueryFilters();
            }

            query = SpecificationEvaluator<TEntity>.GetQuery(query, specification);

            return query;
        }

        private void TryAttachEntity(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Attach(entity);
            }
            catch (Exception)
            {
                // Even with .AsNoTracking, entities are attached to the context
                // If entity could not be attached to context, ignore the exception and continue with following steps
            }
        }

        #endregion
    }
}
