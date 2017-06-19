using System;

namespace EqualsSample
{
    class Person : IEquatable<Person>
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Person other)
        {
            if (other == null) return false;
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode() => FirstName.GetHashCode() ^ LastName.GetHashCode();

        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p2);

    }
}
