using System;
using System.Collections.Generic;

namespace IteaSerialization
{
    public class Company : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();

        protected Company() { }

        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
