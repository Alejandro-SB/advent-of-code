using AdventOfCode2019.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Days
{
    public static class Day2
    {
        public async static Task<int> Part1()
        {
            var lines = await FileHelper.GetInputLinesAsync("2.txt");

            var input = lines.First().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            input[1] = 12;
            input[2] = 2;

            var alarm = CalculateAlarm(input);

            return alarm[0];
        }

        public async static Task<int> Part2()
        {
            throw new NotImplementedException();
        }

        public static int[] CalculateAlarm(int[] input)
        {
            if (input.Length < 4)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i + 4 <= input.Length; i += 4)
            {
                int[] slice = input.SubArray(i, 4);

                int command = slice[0];

                int result;

                if (command == 1)
                {
                    result = input[slice[1]] + input[slice[2]];
                }
                else if (command == 2)
                {
                    result = input[slice[1]] * input[slice[2]];
                }
                else if (command == 99)
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException("Something went wrong");
                }

                input[slice[3]] = result;
            }

            return input;
        }
    }
}