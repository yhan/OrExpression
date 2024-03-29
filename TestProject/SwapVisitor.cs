﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace TestProject;

/// <summary>
/// https://stackoverflow.com/questions/15677492/build-an-or-query-expression-progressively
/// https://stackoverflow.com/questions/10884651/linq-adding-conditions-to-the-where-clause-conditionally
/// </summary>
public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> AnyOf<T>(Expression<Func<T, bool>>[] expressions)
    {
        if (expressions == null || expressions.Length == 0) return x => false;
        if (expressions.Length == 1) return expressions[0];

        var body = expressions[0].Body;
        var param = expressions[0].Parameters.Single();
        for (int i = 1; i < expressions.Length; i++)
        {
            var expr = expressions[i];
            var swappedParam = new SwapVisitor(expr.Parameters.Single(), param)
                .Visit(expr.Body);
            body = Expression.OrElse(body, swappedParam);
        }
        return Expression.Lambda<Func<T, bool>>(body, param);
    }

    private class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
}