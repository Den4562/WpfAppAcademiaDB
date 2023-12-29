using System;


namespace WpfAppAcademia.Tables
{
    public class Department
    {
        public int Id { get; set; }
        public decimal Financing { get; set; }
        public string Name { get; set; }

        public Department()
        {
        }

        public Department(int id, decimal financing, string name)
        {
            Id = id;
            Financing = financing;
            Name = name;
        }
    }
}
