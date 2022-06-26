using System.Collections.Generic;

namespace TestProject.KataSendMonitoring;

internal class TradingOrderContainer
{
    private readonly Dictionary<string, MonitoringTradingOrder> memory = new();
    private readonly HashSet<string> finals = new();
    public MonitoringTradingOrder BuildMonitoring(TradingOrder tradingOrder)
    {
        if (memory.ContainsKey(tradingOrder.UniqueId))
        {
            var incremental = memory[tradingOrder.UniqueId];
            memory[tradingOrder.UniqueId] = incremental.UpdateWith(tradingOrder);
            incremental.SendMode = MonitoringSendMode.Incremental;

            if (tradingOrder.IsFinal())
                finals.Add(tradingOrder.UniqueId);

            return incremental;
        }
            
        var snapshot = new MonitoringTradingOrder(tradingOrder);
        memory.Add(tradingOrder.UniqueId, snapshot);
        snapshot.SendMode = MonitoringSendMode.Snapshot;

        if (tradingOrder.IsFinal())
            finals.Add(tradingOrder.UniqueId);

        return snapshot;
    }
    public bool AlreadyFinal(TradingOrder tradingOrder)
    {
        return finals.Contains(tradingOrder.UniqueId);
    }
}