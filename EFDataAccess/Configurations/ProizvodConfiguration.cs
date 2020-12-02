using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EFDataAccess.Configurations
{
   public class ProizvodConfiguration : IEntityTypeConfiguration<Proizvod>
    {
        public void Configure(EntityTypeBuilder<Proizvod> builder)
        {

            builder.Property(c => c.Naziv).IsRequired();
            builder.Property(c => c.Opis).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Cena).IsRequired();
            builder.Property(c => c.ProId).IsRequired();
            builder.Property(c => c.KatId).IsRequired();
            builder.Property(c => c.DobId).IsRequired();
            builder.Property(r => r.CreatedOn).HasDefaultValueSql("GETDATE()");


        }
    }
}
