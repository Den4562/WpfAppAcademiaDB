using System;

namespace WpfAppAcademia.Tables
{
    public class Teacher
    {
        public int Id { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Name { get; set; }
        public decimal Premium { get; set; }
        public decimal Salary { get; set; }
        public string Surname { get; set; }

        public Teacher()
        {
        }

        public Teacher(int id, DateTime employmentDate, string name, decimal premium, decimal salary, string surname)
        {
            Id = id;
            EmploymentDate = employmentDate;
            Name = name;
            Premium = premium;
            Salary = salary;
            Surname = surname;
        }
    }
}
