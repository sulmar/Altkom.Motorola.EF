using Altkom.Motorola.EF.DbServices.Configurations;
using Altkom.Motorola.EF.DbServices.Migrations;
using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
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
        public DbSet<CallSummary> CallSummaries { get; set; }

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

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RadioContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new DeviceConfiguration());
            modelBuilder.Configurations.Add(new CallConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new CallSummaryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
