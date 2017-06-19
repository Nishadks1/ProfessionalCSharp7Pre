using System;

namespace BinaryCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
           BitShifts();
        }

        static void BitShifts()
        {
            ushort s1 = 0b01;
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine($"{s1} hex: {s1:X}");
                s1 = (ushort)(s1 << 1);
            }
        }
    }
}
