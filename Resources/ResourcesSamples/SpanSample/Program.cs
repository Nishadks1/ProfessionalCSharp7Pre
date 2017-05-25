using System;

namespace SpanSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: implement samples
            SpanOnTheHeap();
            SpanOnTheStack();
            SpanOnNativeMemory();
        }

        private static void SpanOnNativeMemory()
        {
        }

        private static void SpanOnTheStack()
        {
        }

        private static void SpanOnTheHeap()
        {
            var span1 = new Span<int>(new int[] { 1, 5, 11, 71, 22, 19, 21, 33 });

            span1.Fill(42);
            foreach (int i in span1.ToArray())
            {
                Console.WriteLine(i);
            }
        }
    }
}
