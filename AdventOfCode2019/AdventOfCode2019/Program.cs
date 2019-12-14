using AdventOfCode2019.Days;
using System;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var solution = await Day5.Part1();

            Console.WriteLine(solution);
        }
    }
}