using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class Program
    {
        static void Main(string[] args)
        {
            var loads = new List<int[]>();
            loads.Add(new int[] { 1, 1, 1, 1 });
            loads.Add(new int[] { 1, 1, 1, 1, 1 });
            loads.Add(new int[] { 1, 2, 3, 4, 5, 6 });
            loads.Add(new int[] { 1, 2, 9, 3, 5, 1, 1, 1 });
            loads.Add(new int[] { 2, 4, 5, 3, 3, 9, 2, 2, 2});

            //  Expected output:
            //      false
            //      true
            //      false
            //      true
            //      true

            foreach (var load in loads)
            {
                Console.WriteLine(LoadBalancer(load).ToString());
            }

            Console.ReadKey();
        }

        static bool LoadBalancer(int[] numbers)
        {
            var l = 0;
            int r;

            while (l < numbers.Length - 1)
            {
                r = l + 1;
                while(r < numbers.Length)
                {
                    if (IsBalancedForPAndQPositions(numbers, l, r))
                    {
                        return true;
                    }
                    r++;
                }

                l++;
            }
            return false;
        }

        static bool IsBalancedForPAndQPositions(int[] numbers, int p, int q)
        {
            if (p == 0 || q == numbers.Length - 1 || q - p == 1)
                return false;

            var firstSum = SumElements(numbers, 0, p - 1);
            var secondSum = SumElements(numbers, p + 1, q - 1);
            var thirdSum = SumElements(numbers, q + 1, numbers.Length - 1);

            return firstSum == secondSum && firstSum == thirdSum;
        }

        static int SumElements(int[] numbers, int startIndex, int endIndex)
        {
            var sum = 0;
            for (var i = startIndex; i <= endIndex; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
    }
}
