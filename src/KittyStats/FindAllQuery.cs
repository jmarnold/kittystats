using System;
using System.Linq.Expressions;

namespace KittyStats
{
    public class FindAllQuery<TEntity> : IQuery<TEntity>
    {
        public Expression<Func<TEntity, bool>> Matches()
        {
            return t => true;
        }
    }
}