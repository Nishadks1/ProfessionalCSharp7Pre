using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryCalculations
{
    public static class BinaryExtensions
    {
        public static string ToBinaryString(this uint number) => Convert.ToString(number, 2).PadLeft(sizeof(uint), '0');
        public static string ToBinaryString(this int number) => Convert.ToString(number, 2).PadLeft(sizeof(int), '0');

        public static string AddSeparators(this string number) =>
            string.Join('_',
                Enumerable.Range(0, number.Length / 4)
                    .Select(i => number.Substring(i * 4, 4)).ToArray());
    }
}
