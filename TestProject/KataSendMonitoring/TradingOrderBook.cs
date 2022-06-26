using System;
using System.Collections;
using System.Collections.Generic;

namespace TestProject.KataSendMonitoring;

internal class TradingOrderBook : IEnumerable<TradingOrder>
{
    private readonly IEnumerable<TradingOrder> collection = new List<TradingOrder>();
    IEnumerator<TradingOrder> IEnumerable<TradingOrder>.GetEnumerator()
    {
        return collection.GetEnumerator();
    }
    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable<TradingOrder>)this).GetEnumerator();
    }
}