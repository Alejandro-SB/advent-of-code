using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Helper
{
    public static class FuelHelper
    {
        public static int CalculateFuelByMass(int mass)
        {
            if (mass < 6)
            {
                return 0;
            }
            else
            {
                return ((int)Math.Floor(mass / 3.0)) - 2;
            }
        }

        public static int CalculateFuelAddingFuelMass(int mass)
        {
            int fuel = CalculateFuelByMass(mass);
            int remainingMass = fuel;

            do
            {
                remainingMass = CalculateFuelByMass(remainingMass);
                fuel += remainingMass;
            } while (remainingMass > 0);

            return fuel;
        }
    }
}