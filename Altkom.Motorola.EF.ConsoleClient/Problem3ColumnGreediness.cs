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
        [Time]
        public void Example3()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                List<Device> devices = context.Devices
                    .Where(d => d.Model == model)
                    .ToList();

                foreach (var device in devices)
                {
                    WriteOutput($"{device.Name} {device.Firmware}");
                }
            }
        }


        [Time]
        public void Solution3()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                var devices = context.Devices
                    .Where(d => d.Model == model)
                    .Select(d => new { d.Name, d.Firmware} )
                    .ToList();

                foreach (var device in devices)
                {
                    WriteOutput($"{device.Name} {device.Firmware}");
                }
            }
        }

        [Time]
        public void Solution3B()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                var devices = context.Devices
                    .Where(d => d.Model == model)
                    .Select(d => new DeviceNameFirmware { Name = d.Name, Firmware = d.Firmware} )
                    .ToList();

                foreach (var device in devices)
                {
                    WriteOutput($"{device.Name} {device.Firmware}");
                }
            }
        }
    }

    // DTO (Data Transfer Ojbect)
    public class DeviceNameFirmware
    {
        public string Name { get; set; }
        public string Firmware { get; set; }
    }
}
