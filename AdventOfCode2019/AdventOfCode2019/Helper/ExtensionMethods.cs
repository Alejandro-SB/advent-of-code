using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Helper
{
    public static class ExtensionMethods
    {
        public static T[] SubArray<T>(this T[] array, int start, int length)
        {
            var slice = new T[length];
            Array.Copy(array, start, slice, 0, length);
            return slice;
        }
    }
}