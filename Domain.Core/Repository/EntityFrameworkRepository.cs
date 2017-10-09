using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core.Repository
{
    public class EntityFrameworkRepository<TDbContext> : IBusinessLogicRepository where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public EntityFrameworkRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add<TEntity>(TEntity item) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(item);
        }

        public void Remove<TEntity>(TEntity item) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(item);
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveChangesSync()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TEntity> Find<TEntity>(object key) where TEntity : class
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(key);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }
    }
}