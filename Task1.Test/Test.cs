using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1.Test
{
    [TestFixture]
    public class Test
    {
        [TestCase("0, 1, 1, 2, 3, 5, 8, ", 6)]
        [TestCase("0, 1, -1, 2, -3, 5, -8, ", -6 )]
        [TestCase("0, 1, -1, 2, -3, 5, -8, 13, -21, 34, -55, ", -10)]
        [TestCase("0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, ", 18)]
        [TestCase("0, 1, 1, ", 2)]
        [TestCase("0, ", 0)]
        [TestCase("0, 1, ", 1)]
        [Test]
        public void Fibonacci_Positive_Test(string result, int inputNumber)
        {
            string str = String.Empty;
            foreach (var number in FibonacciNumbers.Fibonacci(inputNumber))
                str += number + ", ";
            Assert.AreEqual(result, str);

        }
    }
}
