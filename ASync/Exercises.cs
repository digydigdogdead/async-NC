using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ASync
{
    internal class Exercises
    {
        public static BigInteger CalculateFactorial(BigInteger num)
        {
            BigInteger result = BigInteger.One;
            for (BigInteger i = BigInteger.One; i.CompareTo(num) <= 0; i = BigInteger.Add(i, BigInteger.One))
            {
                result = BigInteger.Multiply(result, i);
            }
            return result;
        }

        static string data = "85671 34262 92143 50984 24515 68356 77247 12348 56789 98760";
        public static List<BigInteger> GetBigInts()
        {
            string[] separateString = data.Split(' ');
            List<BigInteger> result = new List<BigInteger>();
            foreach (string s in separateString) 
            {
                result.Add(BigInteger.Parse(s));
            }

            return result;
        }
    }
}
