using System;
using System.Linq.Expressions;

namespace KittyStats
{
    public interface IQuery<TEntity>
    {
        Expression<Func<TEntity, bool>> Matches();
    }
}