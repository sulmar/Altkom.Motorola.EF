﻿using Altkom.Motorola.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace Altkom.Motorola.EF.DbServices.Configurations
{
    internal class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            Property(p => p.Country)
                .HasMaxLength(100);

            Property(p => p.CompanyName)
                .HasMaxLength(100)
                .IsConcurrencyToken();

            Property(p => p.IsRemoved)
                .IsConcurrencyToken();

            HasIndex(p => p.Country)
                .HasName("IX_Country");


        }
    }
}
