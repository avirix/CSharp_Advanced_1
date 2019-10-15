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
            person.Department = this;
        }
        public override bool Equals(object obj)
        {
            var department = obj as Department;
            return department == null ? false : department.Name == Name;
        }
    }
}
