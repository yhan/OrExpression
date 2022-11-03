using System;
using System.Data;
using NFluent;
using NUnit.Framework;

namespace TestProject;

[TestFixture]
public class EnumFlagsShould
{
    [Test]
    public void FlagRemoval()
    {
        TestContext.WriteLine(8 & 1); //0
        TestContext.WriteLine(8 ^ 1); //9 
        TestContext.WriteLine(8 | 1); //9
        // 1000
        // 0001

        TestContext.WriteLine(9 ^ 1);//8
        //1001
        //0001
        
        // 1010 : 10
        // 0101 :  5
        //-----------
        // 1111:  15   1+2+4+8
        Check.That(10 ^ 5).IsEqualTo(15);
        
        // why XOR ^ can do flag exclusion ?
        //      1111 : 15     1 + 2 + 4 + 8 
        // XOR  0100 :  4
        //-----------
        //      1011:     8 + 2 + 1 = 11
        // XOR  0100 :  4     <----- flag removal is not reentrant
                
        Check.That(15 ^ 4 ^ 4).IsEqualTo(0b1111);
    }

    [Test]
    public void BitwiseComplement()
    {
        //https://stackoverflow.com/questions/791328/how-does-the-bitwise-complement-operator-tilde-work
        
        /**
            Simply speaking, ~ is to find the symmetric value (to -0.5).

            ~a and a should be symmetric to the mirror in the middle of 0 and -1.

            -5,-4,-3,-2,-1 | 0, 1, 2, 3, 4

            ~0 == -1
            ~1 == -2
            ~2 == -3
            ~3 == -4
            The reason for this is due to how computers represent negative values.

            Say, if positive value uses 1 to count, negative value uses 0.

            1111 1111 == -1

            1111 1110 == -2; // add one more '0' to '1111 1111'

            1111 1101 == -3; // add one more '0' to '1111 1110'
            Finally, ~i == -(i+1).
         */
    }
}