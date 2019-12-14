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
            var input = await GetInputFromFile();

            input[1] = 12;
            input[2] = 2;

            var alarm = CalculateAlarm(input);

            return alarm[0];
        }

        public async static Task<int> Part2()
        {
            var input = await GetInputFromFile();

            for (int verb = 0; verb < 100; ++verb)
            {
                for (int noun = 0; noun < 100; ++noun)
                {
                    int[] copy = new int[input.Length];
                    Array.Copy(input, 0, copy, 0, input.Length);
                    copy[1] = noun;
                    copy[2] = verb;

                    var alarm = CalculateAlarm(copy);

                    if (alarm[0] == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return 0;
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

        private static async Task<int[]> GetInputFromFile()
        {
            var lines = await FileHelper.GetInputLinesAsync("2.txt");

            return lines.First().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        }
    }
}