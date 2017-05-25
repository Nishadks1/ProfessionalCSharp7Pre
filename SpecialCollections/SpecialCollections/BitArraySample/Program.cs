using System;
using System.Collections;

namespace BitArraySample
{
    class Program
    {
        static void Main()
        {
            var bits1 = new BitArray(8);
            bits1.SetAll(true);
            bits1.Set(1, false);
            bits1[5] = false;
            bits1[7] = false;
            Console.Write("initialized: ");
            DisplayBits(bits1);
            Console.WriteLine();

            Console.Write("not ");
            DisplayBits(bits1);
            bits1.Not();
            Console.Write(" = ");
            DisplayBits(bits1);
            Console.WriteLine();

            var bits2 = new BitArray(bits1);
            bits2[0] = true;
            bits2[1] = false;
            bits2[4] = true;
            DisplayBits(bits1);
            Console.Write(" or ");
            DisplayBits(bits2);
            Console.Write(" = ");
            bits1.Or(bits2);
            DisplayBits(bits1);
            Console.WriteLine();

            DisplayBits(bits2);
            Console.Write(" and ");
            DisplayBits(bits1);
            Console.Write(" = ");
            bits2.And(bits1);
            DisplayBits(bits2);
            Console.WriteLine();

            DisplayBits(bits1);
            Console.Write(" xor ");
            DisplayBits(bits2);
            bits1.Xor(bits2);
            Console.Write(" = ");
            DisplayBits(bits1);
            Console.WriteLine();

            Console.ReadLine();
        }

        static void DisplayBits(BitArray bits)
        {
            foreach (bool bit in bits)
            {
                Console.Write(bit ? 1 : 0);
            }
        }
    }
}
