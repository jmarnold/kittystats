using System;
using System.Linq.Expressions;

namespace KittyStats
{
    public class LambdaQuery<TEntity> : IQuery<TEntity>
    {
        private readonly Expression<Func<TEntity, bool>> _predicate;

        public LambdaQuery(Expression<Func<TEntity, bool>> predicate)
        {
            _predicate = predicate;
        }

        public Expression<Func<TEntity, bool>> Matches()
        {
            return _predicate;
        }
    }
}