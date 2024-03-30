using System;
using System.Collections.Immutable;
using NFluent;
using NUnit.Framework;

namespace TestProject;

[TestFixture]
public class WarnShould
{
    [Test]
    public void ReferenceEqualOnValueType()
    {
        int int1 = 1;
        int int2 = 1;
        Check.That(object.ReferenceEquals(int1, int2)).IsFalse();// warning CA2013
        //pass an argument with value type 'int' to 'ReferenceEquals'.Due to value boxing,  this call to 'ReferenceEquals' will always return 'false'.
        Check.That(object.Equals(int1, int2)).IsTrue();
    }

    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/variables#94-definite-assignment
    // public void M(out ImmutableArray<int> immutableArray)// CS0177
    // {
    //     // won't compile
    // }
    //
    // public void N(out int value)
    // {
    //     // won't compile
    // }

    [Test]
    public void Unchecked()
    {
        var maxValue = int.MaxValue;
        Check.ThatCode(() => {
            checked
            {
                int a = maxValue + 1;
                TestContext.Write(a);
            }
        }).Throws<OverflowException>();
    }
}
