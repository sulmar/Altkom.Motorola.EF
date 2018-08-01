using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using MethodTimer;
using System.Data.Entity;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        [Time]
        // Lazy Loading
        public void Example2()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                context.Configuration.LazyLoadingEnabled = true;
                context.Configuration.ProxyCreationEnabled = true;

                IQueryable<Device> devices = context.Devices
                    .Where(d => d.Model == model);

                List<Device> myDevices = devices.ToList();

                foreach (var device in myDevices)
                {
                    int qty = device.Calls.Count;

                    // WriteOutput($"{device.Name} - {device.Calls.Count}");
                }

                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
            }
        }


        // Eager Loading
        [Time]
        public void Solution2()
        {
            string model = "SL2600";

            // NOTE: add using System.Data.Entity
            using (var context = new RadioContext())
            {
                IQueryable<Device> devices = context.Devices
                    .Include(d => d.Calls)
                    .Where(d => d.Model == model);

                List<Device> myDevices = devices.ToList();

                //foreach (var device in myDevices)
                //{
                //    WriteOutput($"{device.Name} - {device.Calls.Count}");
                //}
            }
        }

        [Time]
        public void Solution2B()
        {
            string model = "SL2600";
            
            using (var context = new RadioContext())
            {
                List<Device> popularDevices = context.Devices
                    .Where(d => d.Model == model)
                    .Where(d => d.Calls.Count > 100)
                    .ToList();
            }
        }
    }
}
