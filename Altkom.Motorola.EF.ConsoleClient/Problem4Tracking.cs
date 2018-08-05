using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using MethodTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        // Problem: pobieranie obiektów z włączonym mechanizmem śledzenia
        [Time]
        public void Example4A()
        {
            using (var context = new RadioContext())
            {
                Device device = context.Devices.First();

                // Wyświetlenie stacji encji
                WriteOutput($"{context.Entry(device).State}");
            }
        }

        [Time]
        public void Solution4A()
        {
            using (var context = new RadioContext())
            {
                Device device = context
                        .Devices
                        .AsNoTracking()   // wyłączenie śledzenie zmian
                        .First();

                WriteOutput($"{context.Entry(device).State}");
            }
        }

        // Modyfikacja obiektów z użyciem mechanizmu śledzenia
        [Time]
        public void Example4B()
        {
            var myDevice = new Device { Id = 99999, Name = "My Radio" };

            using (var context = new RadioContext())
            {
                context.Configuration.AutoDetectChangesEnabled = true; // domyślnie włączone
                context.Devices.Add(myDevice);

                var entities = context.ChangeTracker.Entries();

                Device device = context.Devices.AsNoTracking().First();

                entities = context.ChangeTracker.Entries();

                device.Firmware = "10.0.0.0";

                WriteOutput($"{context.Entry(myDevice).State}");
                WriteOutput($"{context.Entry(device).State}");

                device.Firmware = "10.0.0.0";

                WriteOutput($"{context.Entry(device).State}");
            }
        }

        [Time]
        public void Solution4B()
        {
            var myDevice = new Device { Id = 99999, Name = "My Radio" };

            using (var context = new RadioContext())
            {
                try
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    context.Devices.Add(myDevice);

                    var entities = context.ChangeTracker.Entries();

                    Device device = context.Devices.AsNoTracking().First();

                    entities = context.ChangeTracker.Entries();

                    device.Firmware = "10.0.0.0";

                    WriteOutput($"{context.Entry(myDevice).State}");
                    WriteOutput($"{context.Entry(device).State}");

                    device.Firmware = "10.0.0.0";

                    WriteOutput($"{context.Entry(device).State}");
                }
                finally
                {
                    context.Configuration.AutoDetectChangesEnabled = true;
                }

            }
        }
    }
}
