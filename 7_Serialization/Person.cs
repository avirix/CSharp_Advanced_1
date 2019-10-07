using System;

namespace IteaSerialization
{
    public enum Gender
    {
        Man,
        Woman,
        etc
    }

    [Serializable]
    public class Person
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        protected Person() { }

        public Person(string name, int age)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Age = age;
        }

        public Person(string name, Gender gender, int age, string email)
            : this(name, age)
        {
            Gender = gender;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Guid.ToString().Substring(0, 5)}_{Name}: {Gender}, {Age}, {Email}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
