using AdventOfCode2019.Days;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2019Tests
{
    public class Day2Tests
    {
        [Theory]
        [InlineData(new int[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }, 3500)]
        [InlineData(new int[] { 1, 0, 0, 0, 99 }, 2)]
        [InlineData(new int[] { 2, 3, 0, 3, 99 }, 2)]
        [InlineData(new int[] { 2, 4, 4, 5, 99, 0 }, 2)]
        [InlineData(new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, 30)]
        public void Calculates_Part1_Intcode(int[] input, int expected)
        {
            var alarm = Day2.CalculateAlarm(input);

            int code = alarm[0];

            Assert.Equal(expected, code);
        }
    }
}