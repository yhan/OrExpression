using System;

namespace TestProject.KataSendMonitoring;

internal class MonitoringTradingOrder
{
    public MonitoringTradingOrder(TradingOrder tradingOrder)
    {
        throw new NotImplementedException();
    }
    public MonitoringSendMode SendMode { get; set; }
    public void SendIncremental()
    {
        throw new NotImplementedException();
    }
    public void SendSnapshot()
    {
        throw new NotImplementedException();
    }
    public MonitoringTradingOrder UpdateWith(TradingOrder tradingOrder)
    {
        throw new NotImplementedException();
    }
}