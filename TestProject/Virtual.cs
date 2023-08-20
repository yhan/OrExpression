using System;
using NUnit.Framework;

namespace TestProject;

public class Virtual
{
    public virtual void Hello(){}
}

class VirtualImpl : Virtual
{
    public override void Hello()
    {
        Console.WriteLine("hello");
    }
}

[TestFixture]
public class TestVirtualNavigation
{
    [Test]
    public void Test()
    {
        var vi = new VirtualImpl();
        vi.Hello();
    }

    [Test]
    public void TestVirtual()
    {
        var vi = new Virtual();
        vi.Hello();
    }
}
