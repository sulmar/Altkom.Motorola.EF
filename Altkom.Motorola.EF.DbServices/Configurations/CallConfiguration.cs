using Altkom.Motorola.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace Altkom.Motorola.EF.DbServices.Configurations
{
    internal class CallConfiguration : EntityTypeConfiguration<Call>
    {
        public CallConfiguration()
        {
            HasOptional(p => p.Source)
                .WithMany(d => d.Calls);

            HasIndex(p => p.ChannelId)
                .HasName("IX_ChannelId");
        }
    }
}
