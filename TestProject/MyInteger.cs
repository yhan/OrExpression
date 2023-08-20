using NFluent;
using NUnit.Framework;

namespace TestProject;

public class MyInteger
{
    private int val;

    public MyInteger(int value)
    {
        val = value;
    }

    public int Value => val;

    public static implicit operator MyInteger(int value)
    {
        return new MyInteger(value);
    }

    public static implicit operator int(MyInteger myInteger)
    {
        return myInteger.val;
    }
}

[TestFixture]
public class ImplicitConvert {
    [Test]
    public void Test()
    {
        int hello = 24;
        MyInteger world = hello;

        int impliWorld = world;
        Check.That(impliWorld).IsEqualTo(hello);
    }
}
