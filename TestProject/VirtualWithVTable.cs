using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NFluent;
using NUnit.Framework;

namespace TestProject;

public class VirtualWithVTable
{


    public abstract class NonVirtual
    {
        public int Offset { get; }
        protected NonVirtual(int offset)
        {
            Offset = offset;
        }

        public int Area => 0;

    }

    private class Impl1 : NonVirtual
    {
        public Impl1() : base(1) {}
        public int Hello() => 42;

        public int Area => 100;
    }


    private class Impl2 : NonVirtual
    {
        public Impl2() : base(2) {}
        public int Hello() => 1;
        public int Area => 200;
    }

    [Test]
    public void NoVirtualTestRuntimeCall()
    {
        NonVirtual[] arr = new NonVirtual[]
        {
            new Impl1(), new Impl2()
        };
        for (int i = 0; i < arr.Length; i++)
        {
            var impl = arr[i];
            Console.WriteLine($"{impl.GetType().Name} Area={impl.Area}");
        }
    }
    [Test]
    public void Test()
    {
        var collection = new NonVirtual[]
        {
            new Impl1(), new Impl2()
        };

        int sum = 0;
        for (int i = 0; i < collection.Length; i++)
        {
            var s = collection[i];
            if (s.Offset == 1)
                sum += ((Impl1)s).Hello();
            if (s.Offset == 2)
                sum += ((Impl2)s).Hello();
        }

        Check.That(sum).IsEqualTo(43);
    }

}

