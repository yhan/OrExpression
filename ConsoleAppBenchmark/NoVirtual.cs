namespace ConsoleAppBenchmark;


public abstract class NoVirtual
{
    public int Offset { get; }
    protected NoVirtual(int offset)
    {
        Offset = offset;
    }
    public int World() => 42;
}

public class NoVirtualImpl1 : NoVirtual
{
    public NoVirtualImpl1() : base(1) {}
    public int Hello() => 42;
    public int World() => 1;
}


public class NoVirtualImpl2 : NoVirtual
{
    public NoVirtualImpl2() : base(2) {}
    public int Hello() => 1;
}

public abstract class WithVirtual
{
    public abstract int Hello();
    public virtual int World() => 42;
}

class WithVirtualImpl1 : WithVirtual
{
    public override int Hello() => 42;
    public override int World() => 1;

}

class WithVirtualImpl2 : WithVirtual
{
    public override int Hello() => 1;
}
