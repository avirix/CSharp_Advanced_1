using System;
using System.Collections.Generic;

namespace IteaSerialization
{
    public class Company : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Division RootDivision { get; private set; }

        protected Company() { }

        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            RootDivision = new Division("root", this);
        }
        public int EmployeesCount()
        {
            return RootDivision.EmployeesCount();
        }

        public Division AddDivision(string name) {
            Division division = new Division(name, this,RootDivision);
            return division;
        }

        public Division AddDivision(string name, Division parent) {
            Division division = new Division(name, this,parent);
            return division;
        }
        public void AddEmployee(Person person) => person.SetDivision(RootDivision);


        public void AddEmployee(Person person, Division division) => person.SetDivision(division);

        public override bool Equals(object obj) => !(obj is Company company) ? false : company.Id == Id;
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
