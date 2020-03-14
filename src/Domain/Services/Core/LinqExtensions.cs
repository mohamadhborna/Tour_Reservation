using System;
using System.Linq;
using System.Linq.Expressions;
using Tour.Domain.Core;

namespace Tour.Domain.Extensions
{
    public static class LinqExtensions
    {

        public static IQueryable<TEntity> ApplyPaging<TEntity>(this IQueryable<TEntity> query, IPagingFilterOptions options, Expression<Func<TEntity, object>> sortSelector)
        {
            query = query.OrderBy(sortSelector);
            return query = query.Skip((options.Page - 1) * options.PerPage).Take(options.PerPage);
        }

        public static IQueryable<TEntity> ApplyDateFilter<TEntity>(this IQueryable<TEntity> query, IDateFilterOptions options, string dateField)
        {
            return query.ApplyDateFilters(options.FromDate, options.ToDate, dateField);
        }

        public static IQueryable<TEntity> ApplyTodayFilter<TEntity>(this IQueryable<TEntity> query, string dateField)
        {
            var from = DateTime.Now.Date;
            var to = DateTime.Now.Date.AddDays(1);

            return query.ApplyDateFilters(from, to, dateField);
        }

        public static IQueryable<TEntity> ApplyDateFilters<TEntity>(this IQueryable<TEntity> query, DateTime? fromDate, DateTime? toDate, string dateField)
        {
            var parameter = Expression.Parameter(query.ElementType, "p");
            var propertyExp = Expression.Property(parameter, dateField);
            BinaryExpression expression = null;

            if (fromDate.HasValue)
            {
                var from = fromDate.Value.Date;

                expression = Expression.GreaterThanOrEqual(propertyExp, Expression.Constant(from));

                query = query.WhereExpression(parameter, expression);
            }

            if (toDate.HasValue)
            {
                var to = toDate.Value.Date.AddDays(1);

                expression = Expression.LessThan(propertyExp, Expression.Constant(to));

                query = query.WhereExpression(parameter, expression);
            }

            return query;
        }

        public static IQueryable<TEntity> WhereExpression<TEntity>(this IQueryable<TEntity> query, ParameterExpression parameter, Expression expression)
        {
            var callExpression = Expression.Call(typeof(Queryable), nameof(Queryable.Where), new Type[] { query.ElementType }, query.Expression, Expression.Quote(Expression.Lambda(expression, parameter)));

            return query.Provider.CreateQuery<TEntity>(callExpression);
        }

    }
}