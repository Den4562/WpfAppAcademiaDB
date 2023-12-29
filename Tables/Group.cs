using System;


namespace WpfAppAcademia.Tables
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int Year { get; set; }

        public Group()
        {
        }

        public Group(int id, string name, int rating, int year)
        {
            Id = id;
            Name = name;
            Rating = rating;
            Year = year;
        }
    }
}
