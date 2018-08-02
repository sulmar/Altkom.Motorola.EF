using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        public void Example4()
        {

            string model = "SL2600";

            var myDevice = new Device { Id = 99999, Name = "My Radio" };

           
            using (var context = new RadioContext())
            {
               //  context.Configuration.AutoDetectChangesEnabled = false;
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
    }
}
