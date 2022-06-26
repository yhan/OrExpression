using System;

namespace TestProject.KataSendMonitoring;

/// <summary>
/// Order generates TradingOrder
/// </summary>
class PTOrder : IDisposable
{
    private readonly TradingOrderBook book = new();
    private readonly TradingOrderContainer container = new();

    public void SendMonitoring()
    {
        foreach (TradingOrder tradingOrder in book)
        {
            if (container.AlreadyFinal(tradingOrder))
                continue;

            Send(tradingOrder);
        }
    }
    
    private void Send(TradingOrder tradingOrder)
    {
        var monitoringTradingOrder = container.BuildMonitoring(tradingOrder);
        if (monitoringTradingOrder.SendMode == MonitoringSendMode.Incremental)
        {
            monitoringTradingOrder.SendIncremental();
        }
        else
        {
            monitoringTradingOrder.SendSnapshot();
        }
    }

    public void Dispose()
    {
        foreach (TradingOrder tradingOrder in book)
        {
            // if never sent -> snapshot; otherwise incremental
            Send(tradingOrder);
        }
    }
}