using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NFluent;
using NUnit.Framework;

namespace TestProject;

public class VirtualWithVTable
{


    public abstract class Super
    {
        public int Offset { get; }
        protected Super(int offset)
        {
            Offset = offset;
        }
        
    }

    private class Impl1 : Super
    {
        public Impl1() : base(1) {}
        public int Hello() => 42;
    }


    private class Impl2 : Super
    {
        public Impl2() : base(2) {}
        public int Hello() => 1;
    }

    [Test]
    public void Test()
    {
        var collection = new Super[]
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

