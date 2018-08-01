using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodTimer;

namespace Altkom.Motorola.EF.ConsoleClient
{

    // Biblioteka do pomiaru czasu
    // PM> Install-Package MethodTimer.Fody
    public partial class DataLayer
    {
        [Time]
        public void Example1()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                List<Device> devices = context.Devices.ToList();
                List<Device> myDevices = devices.Where(d => d.Model == model).ToList();                
            }
        }

        [Time]
        public void Solution1A()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                List<Device> myDevices = context
                    .Devices
                    .Where(d => d.Model == model)
                    .ToList();
            }
        }

        [Time]
        public void Solution1B()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                IQueryable<Device> devices = context.Devices.Where(d => d.Model == model);
                List<Device> myDevices = devices.ToList();
            }
        }

        [Time]
        public void Solution1C()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                List<Device> myDevices = (from d in context.Devices
                                          where d.Model == model
                                          select d)
                                          .ToList();
            }
        }

    }
}
