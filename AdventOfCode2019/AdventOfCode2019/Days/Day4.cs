using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Days
{
    public static class Day4
    {
        public static int Part1()
        {
            const int start = 125730;
            const int end = 579381;

            int validPasswords = 0;

            for (int i = start; i < end; ++i)
            {
                if (ValidatePassword(i.ToString()))
                {
                    ++validPasswords;
                }
            }

            return validPasswords;
        }

        public static int Part2()
        {
            const int start = 125730;
            const int end = 579381;

            int validPasswords = 0;

            for (int i = start; i < end; ++i)
            {
                if (ValidatePasswordInGroup(i.ToString()))
                {
                    ++validPasswords;
                }
            }

            return validPasswords;
        }

        private static bool ValidatePassword(string p)
        {
            return HasEqualAdjacentDigits(p) && DigitsNeverDecrease(p);
        }

        private static bool ValidatePasswordInGroup(string p)
        {
            return DigitsNeverDecrease(p) && HasEqualAdjacentDigits(p) && AdjacentDigitsAreInGroup(p);
        }

        private static bool HasEqualAdjacentDigits(string password)
        {
            return password[0] == password[1]
                || password[1] == password[2]
                || password[2] == password[3]
                || password[3] == password[4]
                || password[4] == password[5];
        }

        private static bool AdjacentDigitsAreInGroup(string p)
        {
            return p.GroupBy(c => c).Any(g => {
                var equalChars = g.Count();

                return equalChars == 2;
            });
        }

        private static bool DigitsNeverDecrease(string p)
        {
            int previousDigit = p[0] - '0';

            for (int i = 1; i < p.Length; ++i)
            {
                int digit = p[i] - '0';

                if(digit<previousDigit)
                {
                    return false;
                }
                previousDigit = digit;
            }

            return true;
        }
    }
}