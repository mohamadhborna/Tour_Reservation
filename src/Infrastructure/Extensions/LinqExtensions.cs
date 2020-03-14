using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tour.Infrastructure.Extensions
{
    public static class LinqExtensions
    {

        public static IQueryable<TEntity> AddPredicate<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
                return query.Where(predicate);

            return query;
        }
    }
}