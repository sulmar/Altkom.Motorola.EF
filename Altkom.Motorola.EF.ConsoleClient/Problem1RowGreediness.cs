using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MethodTimer;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Altkom.Motorola.EF.DbServices.Extensions;

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
                List<Device> devices = context.Devices.ToList(); // Pobieramy wszystkie urządzenia 
                List<Device> myDevices = devices.Where(d => d.Model == model).ToList(); // Filtrujemy dopiero po stronie klienta
            }
        }

        [Time]
        public void Solution1A()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                // Podpięcie się pod zdarzenie materializacji 
                // DbContext tego nie upublicznia dlatego wymagane jest pobranie ObjectContext)
                context.GetObjectContext().ObjectMaterialized += (s, e) => WriteOutput($"Object materialized {e.Entity}", ConsoleColor.DarkMagenta);

                List<Device> myDevices = context
                    .Devices
                    .Where(d => d.Model == model)   // utworzenie wyrażenia
                    .ToList();    // materializacja
            }
        }

        [Time]
        // Method Syntax
        public void Solution1B()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                IQueryable<Device> devices = context
                    .Devices
                    .Where(d => d.Model == model); // utworzenie wyrażenia

                List<Device> myDevices = devices.ToList(); // materializacja
            }
        }

        [Time]
        // Query Syntax
        public void Solution1C()
        {
            string model = "SL2600";

            using (var context = new RadioContext())
            {
                
                List<Device> myDevices = (from d in context.Devices
                                          where d.Model == model
                                          select d)         // utworzenie wyrażenia
                                          .ToList();        // materializacja
            }
        }
    }

   
        
}
