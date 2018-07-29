using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.DbServices
{
    public class DbCallsService
    {
        private readonly RadioContext context;

        public DbCallsService(RadioContext context)
        {
            this.context = context;
        }

        public void AddRange(ICollection<Call> calls)
        {
            context.Configuration.AutoDetectChangesEnabled = false;

            try
            {
                context.Calls.AddRange(calls);
                context.SaveChanges();
            }

            finally
            {
                context.Configuration.AutoDetectChangesEnabled = true;
            }
        }
    }
}
