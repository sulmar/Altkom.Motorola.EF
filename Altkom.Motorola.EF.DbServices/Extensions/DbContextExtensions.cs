using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.DbServices.Extensions
{
    public static class DbContextExtensions
    {
        public static DbContext BulkInsert<T>(this DbContext context, T entity, int count, int batchSize) 
            where T : class
        {
            context.Set<T>().Add(entity);

            if (count % batchSize == 0)
            {                
                context.SaveChanges();

                Debug.WriteLine($"Saved {count} entities.");
            }
            return context;
        }

        /// <summary>
        /// Metoda pobiera ObjectContext z DbContext
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <returns>ObjectContext</returns>
        public static ObjectContext GetObjectContext(this IObjectContextAdapter context) => context.ObjectContext;
    }
}
