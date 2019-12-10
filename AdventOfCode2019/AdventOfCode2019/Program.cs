using AdventOfCode2019.Days;
using System;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var s = await Day2.Part1();

            Console.WriteLine(s);
        }
    }
}
