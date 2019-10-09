using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteaSerialization
{
    public class Division : IModel

    {

        public Guid Id { get; set ; }
        public string Name { get; set; }
        public List<Division> Divisions { get; set; } = new List<Division>();
        public List<Person> Employees { get; set; } = new List<Person>();
        //[JsonIgnore]
        public Company Company { get; set; }
        //[JsonIgnore]
        public Division ParentDiv { get; private set; }

        public Division(string name, Company company)
        {
            Id = Guid.NewGuid();
            Name = name;
            Company = company;
        }

        [JsonConstructor]
        public Division(string name, Company company, Division parent) : this(name, company)
        {
            if (parent != null)
            {
                ParentDiv = parent;
                parent.Divisions.Add(this);
            }
        }

        public void Addemployee(Person person) {
            this.Employees.Add(person);
            person.Division= this;
        }

        public int EmployeesCount()
        {
            int i = Employees.Count();
            while (Divisions.Count() != 0)
            {
                foreach (Division d in Divisions)
                {
                    i += d.EmployeesCount();
                }
            }
            return i;

        }
        public void MoveDivision(Division target) {
            ParentDiv.Divisions.Remove(this);
            target.Divisions.Add(this);
        }
        public void Remove() {
            ParentDiv.Divisions.Remove(this);
        }

        public override bool Equals(object obj) => !(obj is Division division) ? false : division.Id == Id;
        public override int GetHashCode() => base.GetHashCode();
    }
}
