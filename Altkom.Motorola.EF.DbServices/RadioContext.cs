using Altkom.Motorola.EF.DbServices.Configurations;
using Altkom.Motorola.EF.DbServices.Migrations;
using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.DbServices
{
    public class RadioContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Call> Calls { get; set; }
        // public virtual DbSet<CallSummary> vwCallSummary { get; set; }

        ObjectContext ObjectContext => ((IObjectContextAdapter)this).ObjectContext;

        public RadioContext(DbConnection connection)
            : base(connection, false)
        {
        
            
        }

        public RadioContext()
            : base("RadioConnection")
        {

            // Disable Lazy Loading
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;


            if (this.Database.CompatibleWithModel(false))
            {
                Console.WriteLine("Database was changed");
            }

            ObjectContext.ObjectMaterialized += ObjectContext_ObjectMaterialized;





            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RadioContext, Configuration>());
        }

        private void ObjectContext_ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new DeviceConfiguration());
            modelBuilder.Configurations.Add(new CallConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            // modelBuilder.Configurations.Add(new CallSummaryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
