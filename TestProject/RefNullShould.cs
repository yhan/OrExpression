using System;
using System.Collections.Generic;
using NFluent;
using NUnit.Framework;

namespace TestProject;

[TestFixture]
public class RefNullShould
{
    [Test]
    public void PassNullReferenceType()
    {
        List<string> list = null;
        Fill(list);
        Check.ThatCode(() => _ = list.Count)
            .Throws<NullReferenceException>();
    }

    [Test]
    public void PassNonNullReferenceType()
    {
        var list = new List<string>();
        Fill2(list);
        Check.That(list).HasSize(1);
    }
    private void Fill2(List<string> list)
    {
        list.Add("");
    }

    private void Fill(List<string> list)
    {
        list = new List<string>()
        {
            "hello"
        };
    }
}
