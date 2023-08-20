using System;
using System.Linq;
using NFluent;
using NUnit.Framework;

namespace TestProject;

public class SwapReferenceTests{
    class Flight
    {
        public Flight(int number)
        {
            this.Number = number;
        }
        public int Number { get; set; }
        public virtual void NonVirtual(){}
    }

    class AirFranceFlight : Flight
    {
        public AirFranceFlight(int number) : base(number) {}
        public override void NonVirtual(){} // override exige le parent method soit virtual 
    }
    
    [Test]
    public void SwapReference()
    {
        var f = new Flight(10);
        var f2 = new Flight(20);
        Swap(f, f2);
        Check.That(f.Number).IsEqualTo(10);
        Check.That(f2.Number).IsEqualTo(20);
    }


    [Test]
    public void SingleCanThrow()
    {
        var arr = new int[]
        {
            1, 1, 1, 2, 3, 212, 31, 32
        };
        Check.ThatCode(() => arr.SingleOrDefault(x => x % 2 == 1))
            .Throws<InvalidOperationException>();

    }
    private static void Swap(Flight f1, Flight f2) =>
        (f2, f1) = (f1, f2);

    [Test]
    public void Debugger()
    {
        int a = 42, b = 4, c = 10;
        //TestContext.Write("hello");
    }
}