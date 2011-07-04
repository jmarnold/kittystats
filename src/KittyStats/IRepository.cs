using System.Linq;

namespace KittyStats
{
    public interface IRepository
    {
        TEntity Find<TEntity>(string id);
        IQueryable<TEntity> Query<TEntity>(IQuery<TEntity> query);
        void Insert<TEntity>(TEntity entity);
        void Save();
    }
}