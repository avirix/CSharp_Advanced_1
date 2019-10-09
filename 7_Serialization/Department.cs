using System;
using System.Collections.Generic;
using System.Text;

namespace IteaSerialization
{
    public class Department : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
       

        protected Department() { }
        public Department(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public void Hire(Person person)
        {
            People.Add(person);
        }
        public override bool Equals(object obj)
        {
            Department department = (Department)obj;
            if (Id == department.Id &&
                Name == department.Name &&
                People.Count == department.People.Count)
                return true;
            else
                return false;
        }
    }
}
