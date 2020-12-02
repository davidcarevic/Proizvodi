using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EFDataAccess.Configurations
{
   public  class DobavljacConfiguration : IEntityTypeConfiguration<Dobavljac>
    {
        public void Configure(EntityTypeBuilder<Dobavljac> builder)
        {

            builder.Property(c => c.Naziv).IsRequired();
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("GETDATE()");


        }
    }
}
