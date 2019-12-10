using AdventOfCode2019.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2019Tests
{
    public class Day1Tests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Calculates_Part1_Fuel_Requirements(int mass, int expected)
        {
            var fuel = FuelHelper.CalculateFuelByMass(mass);

            Assert.Equal(expected, fuel);
        }

        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void Calculates_Part2_Fuel_Requirements(int mass, int expected)
        {
            int fuel = FuelHelper.CalculateFuelAddingFuelMass(mass);

            Assert.Equal(expected, fuel);
        }
    }
}
