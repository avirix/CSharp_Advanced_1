﻿using System;
using Newtonsoft.Json;

namespace IteaSerialization
{
    public enum Gender
    {
        Man,
        Woman,
        etc
    }

    [Serializable]
    public class Person : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
      //  [JsonIgnore]
 //       public Company Company { get; set; }

        protected Person() { }

        public Person(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }

        public Person(string name, Gender gender, int age, string email)
            : this(name, age)
        {
            Gender = gender;
            Email = email;
        }

        /// <summary>
        /// Set company for person
        /// </summary>
        /// <param name="company">Company to set</param>
        public override string ToString()
        {
            return $"{Id.ToString().Substring(0, 5)}_{Name}: {Gender}, {Age}, {Email}";
        }
    //    public override bool Equals(object obj)
    //    {
    //        Person person = (Person)obj;
    //        if (Id == person.Id &&
    //            Name == person.Name &&
    //            Gender == person.Gender &&
    //            Age == person.Age &&
    //            Email == person.Email)
    //            return true;
    //        else
    //            return false;
    //}
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
