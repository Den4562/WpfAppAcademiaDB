﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppAcademia.Tables;

namespace WpfAppAcademia
{
     class AcademiaDBContext : DbContext
    {

        public DbSet<Department> Department { get; set; }
        public DbSet<Faculties> Faculties { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
