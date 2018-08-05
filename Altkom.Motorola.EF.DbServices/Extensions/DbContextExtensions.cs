using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// Metoda usuwa obiekt na podstawie id
        /// </summary>
        /// <param name="set">DbContext</param>
        /// <param name="id">Identifier</param>
        public static void Remove<TEntity>(this DbContext context, int id) 
            where TEntity : Base, new()
        {
            TEntity entityToDelete = new TEntity();
            entityToDelete.Id = id;
            context.Set<TEntity>().Attach(entityToDelete);
            context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        /// <summary>
        /// Metoda usuwa obiekt na podstawie id
        /// </summary>
        /// <param name="dbSet">DbSet</param>
        /// <param name="id">Identifier</param>
        public static void Remove<TEntity>(this DbSet<TEntity> dbSet, int id)
            where TEntity : Base, new()
        {
            TEntity entityToDelete = new TEntity();
            entityToDelete.Id = id;
            dbSet.Attach(entityToDelete);

            DbContext context = GetContext(dbSet);
            context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        // Pobranie DbContext z DbSet
        // na podst.
        // https://stackoverflow.com/questions/17710769/can-you-get-the-dbcontext-from-a-dbset
        private static DbContext GetContext<TEntity>(this DbSet<TEntity> dbSet)
            where TEntity : class
        {
            object internalSet = dbSet
                .GetType()
                .GetField("_internalSet", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(dbSet);
            object internalContext = internalSet
                .GetType()
                .BaseType
                .GetField("_internalContext", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(internalSet);
            return (DbContext)internalContext
                .GetType()
                .GetProperty("Owner", BindingFlags.Instance | BindingFlags.Public)
                .GetValue(internalContext, null);
        }

    }
}
