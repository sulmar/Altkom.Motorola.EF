using Altkom.Motorola.EF.Models;
using System.Data.Entity.ModelConfiguration;

namespace Altkom.Motorola.EF.DbServices.Configurations
{
    internal class CallConfiguration : EntityTypeConfiguration<Call>
    {
        public CallConfiguration()
        {
            HasOptional(p => p.Sender)
                .WithMany(d => d.Calls)
                .WillCascadeOnDelete(true);

            HasIndex(p => p.ChannelId)
                .HasName("IX_ChannelId");

            HasIndex(p => new { p.BeginCallDate, p.EndCallDate });

            /* 
             * CREATE NONCLUSTERED INDEX MyIndex
	on dbo.Calls(ChannelId)
		INCLUDE	(BeginCallDate, EndCallDate)
        */
        }
    }
}
