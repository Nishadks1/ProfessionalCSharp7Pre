using System;
using System.Collections.Generic;

namespace EqualsSample
{
    class SomeClass { }

    class Program
    {
        static void Main(string[] args)
        {
            ReferenceEqualsSample();
            OverrideEqualsSample();
        }

        private static void OverrideEqualsSample()
        {
            Person p1 = new Person("Stephanie", "Nagel");
            Person p2 = new Person("Stephanie", "Nagel");

            bool b1 = p1 == p2;
            Console.WriteLine($"p1 == p2 returns {b1}");

            bool b2 = object.ReferenceEquals(p1, p2);
            Console.WriteLine($"ReferenceEquals returns {b2}");

            bool b3 = p1.Equals(p2);
            Console.WriteLine($"overridden Equals returns {b3}");

            
            bool b4 = EqualityComparer<Person>.Default.Equals(p1, p2);
            Console.WriteLine($"EqualityComparer returns {b4}");
        }

        static void ReferenceEqualsSample()
        {
            SomeClass x = new SomeClass(), y = new SomeClass(), z = x;
            bool b1 = object.ReferenceEquals(null, null);  // returns true
            Console.WriteLine(b1);
            bool b2 = object.ReferenceEquals(null, x);     // returns false
            Console.WriteLine(b2);
            bool b3 = object.ReferenceEquals(x, y);        // returns false because x and y
                                                           // references different objects
            Console.WriteLine(b3);
            bool b4 = object.ReferenceEquals(x, z);        // returns true because x and z
                                                           // references the same object


            Console.WriteLine(b4);
        }
    }
}
