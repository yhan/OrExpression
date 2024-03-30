using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestProject;

[TestFixture]
public class SortShould
{
    class Person
    {
        public uint Age { get; }
        public string Name { get; }
        public Person(uint age, string name)
        {
            Age = age;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Age} {Name}";
        }
    }

    class Person2 : IComparable<Person2>
    {
        public uint Age { get; }
        public string Name { get; }
        public Person2(uint age, string name)
        {
            Age = age;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Age} {Name}";
        }
        
        public int CompareTo(Person2 other)
        {
            if (ReferenceEquals(this, other))
                return 0;
            if (ReferenceEquals(null, other))
                return 1;

            var ageComparison = Age.CompareTo(other.Age);
            if (ageComparison != 0)
                return ageComparison;

            return string.Compare( other.Name, Name, StringComparison.Ordinal);
        }
    }

    class PersonComparer: IComparer<Person>
    {

        public int Compare(Person x, Person y)
        {
            if (ReferenceEquals(x, y))
                return 0;
            if (ReferenceEquals(null, y))
                return 1;
            if (ReferenceEquals(null, x))
                return -1;

            var ageComparison = x.Age.CompareTo(y.Age);
            if (ageComparison != 0)
                return ageComparison;

            return string.Compare(y.Name, x.Name, StringComparison.Ordinal);
        }
    }

    [Test]
    public void SortByAgeAscendingAndNameAlphabeticallyDescending()
    {
        var people =  new []
        {
            new Person(25, "Alice"),
            new Person(30, "Bob"),
            new Person(22, "Charlie"),
            new Person(25, "David"),
        };
        
        Array.Sort(people, new PersonComparer());

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
    [Test]
    public void SortByAgeAscendingAndNameAlphabeticallyDescending_withComparable()
    {
        var people = new[]
        {
            new Person2(25, "Alice"), new Person2(30, "Bob"), new Person2(22, "Charlie"), new Person2(25, "David"),
        };

        Array.Sort(people);

        foreach (var p2 in people)
        {
            Console.WriteLine(p2);
        }

        var hash = HashCode.Combine("hello", 42);
    }
}