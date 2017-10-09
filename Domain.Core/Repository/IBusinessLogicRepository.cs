using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core.Repository
{
    public interface IBusinessLogicRepository
    {
        void Add<TEntity>(TEntity item) where TEntity : class;
        
        void Remove<TEntity>(TEntity item) where TEntity : class;
        
        Task<int> SaveChanges();

        int SaveChangesSync();

        Task<TEntity> Find<TEntity>(object key) where TEntity : class;

        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    }
}