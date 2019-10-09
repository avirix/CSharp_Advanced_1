using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IteaSerialization
{
    public class Company : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        protected Company() { }

        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        //public override bool Equals(object obj)
        //{
        //        Company company = (Company)obj;
        //        if (Id == company.Id &&
        //            Name == company.Name &&
        //            Departments.Count == company.Departments.Count)
        //            return true;
        //        else
        //            return false;
            
        //}
        public void CreateDepartment(int count)
        {
            for (int i = 0; i < count; i++)
                Departments.Add(new Department("Dep" + i.ToString()));
        }
    }
}
