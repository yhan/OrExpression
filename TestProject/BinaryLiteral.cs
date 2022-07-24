using NFluent;
using NUnit.Framework;

namespace TestProject;

[TestFixture]
public class BinaryLiteral
{
    [Test]
    public void Hexadecimal_base16()
    {
        Check.That(0X0100).IsEqualTo(16 * 16);
    }

    [Test]
    public void Binary_base2()
    {
        Check.That(0B000000100).IsEqualTo(4);
        Check.That(0B00001_100).IsEqualTo(12);
    }
}
