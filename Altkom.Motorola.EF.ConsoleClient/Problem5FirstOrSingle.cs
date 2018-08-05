using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using System;
using System.Linq;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        // Porównanie metod Find, First, Single
        public void Example5()
        {
            int deviceId = 1001;

            using (var context = new RadioContext())
            {
                context.Database.Log += msg => WriteOutput(msg);

                // top(2)

                WriteOutput("Find", ConsoleColor.DarkBlue);

                Device device = context.Devices.Find(deviceId);

                // top(1)
                WriteOutput("First", ConsoleColor.DarkBlue);

                device = context.Devices
                    .Where(u => u.Id == deviceId)
                    .First();

                // top

                WriteOutput("Single", ConsoleColor.DarkBlue);
                device = context.Devices
                    .Where(u => u.Id == deviceId)
                    .Single();

                WriteOutput("FirstOrDefault", ConsoleColor.DarkBlue);
                device = context.Devices
                    .Where(u => u.Id == deviceId)
                    .FirstOrDefault();

                WriteOutput("SingleOrDefault", ConsoleColor.DarkBlue);
                device = context.Devices
                   .Where(u => u.Id == deviceId)
                   .SingleOrDefault();

            }
        }
    }
}
