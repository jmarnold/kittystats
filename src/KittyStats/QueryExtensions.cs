using System;
using System.Linq;
using System.Linq.Expressions;

namespace KittyStats
{
    public static class QueryExtensions
    {
        public static IQueryable<TEntity> FindAll<TEntity>(this IRepository repository)
        {
            return repository.Query(new FindAllQuery<TEntity>());
        }

        public static TEntity SingleOrDefault<TEntity>(this IRepository repository, Expression<Func<TEntity, bool>> predicate)
        {
            return repository.SingleOrDefault(new LambdaQuery<TEntity>(predicate));
        }

        public static TEntity SingleOrDefault<TEntity>(this IRepository repository, IQuery<TEntity> query)
        {
            return repository
                .Query<TEntity>(query)
                .SingleOrDefault();
        }
    }
}