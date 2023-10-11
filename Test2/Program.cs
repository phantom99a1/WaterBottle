using System;

namespace Test2
{
    public class Result
    {
        public static long knapsack(long[] a, long S,long n)
        {
            long[,] knapsacks = new long[n + 1, S + 1];
            for(long i = 0; i <= n; i++)
            {
                for(long j = 0; j <= S; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        knapsacks[i, j] = 0;                       
                    }
                    else if (a[i - 1] <= j)
                    {
                        knapsacks[i, j] = Math.Max(knapsacks[i - 1, j], a[i - 1] + knapsacks[i - 1, j - a[i - 1]]);
                    }
                    else knapsacks[i, j] = knapsacks[i - 1, j];
                }
            }
            return knapsacks[n,S];
        }
        public static long minSum(long[] a,long n)
        {
            long sum = a[0];
            long[] w = new long[n - 1];
            for(long i = 0; i < n-1; i++)
            {
                w[i] = Math.Abs(a[i + 1]);
                sum += w[i];
            }
            return sum-2*knapsack(w,sum/2,n-1);
        }
    }
    public class Solution
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine().Trim());
            long[] a = new long[n];
            for (long i = 0; i < n; i++)
                a[i] = long.Parse(Console.ReadLine().Trim());
            Console.WriteLine(Result.minSum(a,n));
            Console.ReadKey();
        }
    }
}
