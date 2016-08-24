using System;
using System.Collections.Generic;

namespace CommonTests.ExampleTypes
{
    public class Person
    {
        public Person()
        {
            
        }

        protected bool Equals(Person other)
        {
            return string.Equals(Name, other.Name) && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name?.GetHashCode() ?? 0)*397) ^ (LastName?.GetHashCode() ?? 0);
            }
        }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public Guid Id
        {
            get
            {
                return new Guid();
            }
        }


        public string Name { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, LastName: {LastName}";
        }
    }
}
