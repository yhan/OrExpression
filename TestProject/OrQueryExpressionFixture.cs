using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NFluent;
using NUnit.Framework;

namespace TestProject;

[TestFixture]
public class OrQueryExpressionFixture
{
    [Test]
    public void OrFilters()
    {
        var kpi = new Kpi("BNP.PA", 15, "PAR");
        var kpi2 = new Kpi("SG.PA", 140, "PAR");
        var kpi3 = new Kpi("MS.US", 42, "US");
        var kpis = new List<Kpi>()
        {
            new Kpi("VOD.L", 14, "LSE"),
            kpi,
            kpi2,
            kpi3,
        };

        var filters = new List<Expression<Func<Kpi, bool>>>();
        filters.Add(kpi => kpi.Market=="PAR");
        filters.Add(kpi => kpi.Amount > 40 );

        Expression<Func<Kpi, bool>> lambda = ExpressionExtensions.AnyOf(filters.ToArray());
        var filtered = kpis.Where(lambda.Compile());
        var arr = filtered as Kpi[] ?? filtered.ToArray();
        Check.That(arr).HasSize(3);
        Check.That(arr[0]).IsEqualTo(kpi);
        Check.That(arr[1]).IsEqualTo(kpi2);
        Check.That(arr[2]).IsEqualTo(kpi3);
    }
}