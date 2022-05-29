using System;

namespace TestProject
{
    public class Kpi :  IEquatable<Kpi>
    {
        public string Stock { get; }
        public int Amount { get; }
        public string Market { get; }
        public Kpi(string stock, int amount, string market)
        {
            Stock = stock;
            Amount = amount;
            Market = market;
        }
        public bool Equals(Kpi other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Stock == other.Stock && Amount == other.Amount && Market == other.Market;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals((Kpi)obj);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Stock, Amount, Market);
        }
    }
}
