using AdventOfCode2019.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Days
{
    public static class Day1
    {
        public static async Task<int> Part1()
        {
            var lines = await FileHelper.GetInputLinesAsync("1.txt");

            int sum = 0;

            foreach(var line in lines)
            {
                if(int.TryParse(line, out int mass))
                {
                    sum += FuelHelper.CalculateFuelByMass(mass);
                }
            }

            return sum;
        }

        public static async Task<int> Part2()
        {
            var lines = await FileHelper.GetInputLinesAsync("1.txt");

            int sum = 0;

            foreach (var line in lines)
            {
                if (int.TryParse(line, out int mass))
                {
                    sum += FuelHelper.CalculateFuelAddingFuelMass(mass);
                }
            }

            return sum;
        }
    }
}
