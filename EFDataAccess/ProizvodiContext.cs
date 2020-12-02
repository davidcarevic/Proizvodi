using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using EFDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;


namespace EFDataAccess
{
    public class ProizvodiContext:DbContext
    {
      public  DbSet<Dobavljac> Dobavljacs { get; set; }
      public  DbSet<Kategorija> Kategorijas { get; set; }
      public  DbSet<Proizvod> Proizvods { get; set; }
      public  DbSet<Proizvodjac> Proizvodjacs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=proizvodi;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DobavljacConfiguration());
            modelBuilder.ApplyConfiguration(new KategorijaConfiguration());
            modelBuilder.ApplyConfiguration(new ProizvodConfiguration());
            modelBuilder.ApplyConfiguration(new ProizvodjacConfiguration());


        }
    }
}
