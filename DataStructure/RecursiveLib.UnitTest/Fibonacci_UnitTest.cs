using System;
using Xunit;

namespace MyMathLib.UnitTest
{
    public class Fibonacci_UnitTest
    {
        [Fact]
        public void GetNumber(int value)
        {
            Assert.Equal<int>(1, Fibonacci.GetNumber(1));
            Assert.Equal<int>(1, Fibonacci.GetNumber(2));
            Assert.Equal<int>(2, Fibonacci.GetNumber(3));
            Assert.Equal<int>(3, Fibonacci.GetNumber(4));
            Assert.Equal<int>(5, Fibonacci.GetNumber(5));
            Assert.Equal<int>(8, Fibonacci.GetNumber(6));
            Assert.Equal<int>(13, Fibonacci.GetNumber(7));
            Assert.Equal<int>(21, Fibonacci.GetNumber(8));
            Assert.Equal<int>(34, Fibonacci.GetNumber(9));
            Assert.Equal<int>(55, Fibonacci.GetNumber(10));
        }
    }
    
}
