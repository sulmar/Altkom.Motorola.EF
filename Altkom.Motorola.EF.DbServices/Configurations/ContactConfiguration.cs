using Altkom.Motorola.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace Altkom.Motorola.EF.DbServices.Configurations
{
    internal class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            Property(p => p.FirstName)
                .HasMaxLength(50);

            Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Country)
                .HasMaxLength(50);

            Property(p => p.CompanyName)
                .HasMaxLength(50);

        }
    }
}
