using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Yensi_P1_AP1.Entities;

namespace Yensi_P1_AP1.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Ciudades> Ciudades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\CiudadesControl.db");
        }

    }
}
