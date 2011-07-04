using System.Linq;
using Raven.Client;

namespace KittyStats
{
    public class Repository : IRepository
    {
        private readonly IDocumentSession _session;

        public Repository(IDocumentSession session)
        {
            _session = session;
        }

        public TEntity Find<TEntity>(string id)
        {
            return _session.Load<TEntity>(id);
        }

        public IQueryable<TEntity> Query<TEntity>(IQuery<TEntity> query)
        {
            return _session
                .Query<TEntity>()
                .Where(query.Matches());
        }

        public void Insert<TEntity>(TEntity entity)
        {
            _session.Store(entity);
        }

        public void Save()
        {
            _session.SaveChanges();
        }
    }
}