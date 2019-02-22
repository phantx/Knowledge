using System;
using System.Diagnostics;

namespace ConsoleApplication
{
    class Program
    {
        // https://www.cnblogs.com/bianchengzhuji/p/10240897.html
        // https://www.zhihu.com/question/28062458
        
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            const uint n = 40;
            ulong result;

            stopwatch.Restart();
            result = Recursive(n);
            stopwatch.Stop();
            Console.WriteLine("{0,-15} -> {1}, {2}", nameof(Recursive), result, stopwatch.ElapsedTicks);

            stopwatch.Restart();
            result = RecursiveRevamp(n);
            stopwatch.Stop();
            Console.WriteLine("{0,-15} -> {1}, {2}", nameof(RecursiveRevamp), result, stopwatch.ElapsedTicks);

            stopwatch.Restart();
            result = Iteration(n);
            stopwatch.Stop();
            Console.WriteLine("{0,-15} -> {1}, {2}", nameof(Iteration), result, stopwatch.ElapsedTicks);

            stopwatch.Restart();
            result = TailRecursive(n);
            stopwatch.Stop();
            Console.WriteLine("{0,-15} -> {1}, {2}", nameof(TailRecursive), result, stopwatch.ElapsedTicks);

            Console.ReadLine();
        }

        static ulong Recursive(uint n)
        {
            // 虽然递归算法简洁，但是在这个问题中，它的时间复杂度却是难以接受的。
            // 除此之外，递归函数调用的越来越深，它们在不断入栈却迟迟不出栈，空间需求越来越大，虽然访问速度高，但大小是有限的，最终可能导致栈溢出
            return n <= 1 ? n : Recursive(n - 1) + Recursive(n - 2);
        }

        static ulong RecursiveRevamp(uint n, ulong[] buffer = null)
        {
            if (n <= 1)
            {
                return n;
            }

            // 既然我们知道最初版本的递归存在大量的重复计算，那么我们完全可以考虑将已经计算的值保存起来，从而避免重复计算
            if (buffer == null)
            {
                buffer = new ulong[n + 1];
                buffer[0] = 0;
                buffer[1] = 1;
            }

            // n - 1 递归时会填充所有数组，后续只需从缓存中取值
            buffer[n] = RecursiveRevamp(n - 1, buffer) + buffer[n - 2];
            return buffer[n];
        }

        static ulong Iteration(uint n)
        {
            if (n <= 1)
            {
                return n;
            }

            // 如果不用计算机计算，让你去算第n个斐波那契数，你会怎么做呢？
            // 我想最简单直接的方法应该是：知道第一个和第二个后，计算第三个；知道第二个和第三个后，计算第四个，以此类推。
            ulong result = 0;
            uint curr = 2;
            ulong n0 = 0, n1 = 1;
            while (curr <= n)
            {
                result = n0 + n1;
                n0 = n1;
                n1 = result;
                curr++;
            }

            return result;
        }

        static ulong TailRecursive(uint n, uint curr = 2, ulong n0 = 0, ulong n1 = 1)
        {
            if (n <= 1)
            {
                return n;
            }

            // 采用尾递归的方法来计算。
            // 要计算第n个斐波那契数，我们可以先计算第一个，第二个，如果未达到n，则继续递归计算
            if (curr == n)
            {
                return n0 + n1;
            }

            curr++;
            n1 = n0 + n1;
            n0 = n1 - n0;
            return TailRecursive(n, curr, n0, n1);
        }
    }
}
