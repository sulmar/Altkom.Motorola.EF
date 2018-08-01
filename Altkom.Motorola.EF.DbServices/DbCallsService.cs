using Altkom.Motorola.EF.DbServices.Extensions;
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

        public void AddBatch<T>(IEnumerable<T> entities, int batchSize = 50000)
              where T : class
        {
            
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                int count = 1;

                try
                {

                    foreach (var entity in entities)
                    {
                        context.BulkInsert<T>(entity, count, batchSize);
                        count++;
                    }

                    transaction.Commit();
                }

                catch (Exception e)
                {
                    transaction.Rollback();

                    throw;
                }
            }
            

        }

            public bool Any() => context.Calls.Any();
    }
}
