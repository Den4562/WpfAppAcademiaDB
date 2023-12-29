using System;


namespace WpfAppAcademia.Tables
{
    public class Faculties
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Faculties()
        {
        }

        public Faculties(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
