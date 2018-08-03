using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.DbServices.Configurations
{
    public class CallSummaryConfiguration : EntityTypeConfiguration<CallSummary>
    {
        public CallSummaryConfiguration()
        {            
        }
    }
}
