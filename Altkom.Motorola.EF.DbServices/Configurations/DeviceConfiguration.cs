using Altkom.Motorola.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace Altkom.Motorola.EF.DbServices.Configurations
{
    internal class DeviceConfiguration : EntityTypeConfiguration<Device>
    {
        public DeviceConfiguration()
        {
            Property(p => p.Name)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);


            Property(p => p.Firmware)
                .IsUnicode(false)
                .HasMaxLength(20);
          
        }
    }
}
