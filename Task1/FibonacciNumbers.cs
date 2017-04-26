using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class FibonacciNumbers
    {
        static Func<int, int, int> calculatorPos = (int first, int second) => first + second;
        static Func<int, int, int> calculatorNeg = (int first, int second) => first - second;
        /// <summary>
        /// The method calculates fibonacci numbers
        /// </summary>
        /// <param name="number">power</param>
        /// <returns></returns>
        public static IEnumerable<int> Fibonacci(int number)
        {
            if (number == 0)
            {
                yield return 0;
                yield break;
            }

            Func<int, int, int> calculator = calculatorPos;
            int first = 0, second = 1, sum = 0;
            if (number < 0)
            {
                calculator = calculatorNeg;
                first = 0;
                second = 1;
                sum = 0;
                number = Math.Abs(number);
            }
            //first three value
            yield return first;
            yield return second;
            int i = 1;
            while (i < number)
            {
                yield return sum = calculator(first, second);
                first = second;
                second = sum;
                i++;
            }
        }
    }
}
