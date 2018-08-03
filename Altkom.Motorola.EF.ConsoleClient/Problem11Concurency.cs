using Altkom.Motorola.EF.DbServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        int contactId = 2021;

        public void Example11()
        {
            using (var context1 = new RadioContext())
            using (var context2 = new RadioContext())
            {
                // user 1
                var contact1 = context1.Contacts.Find(contactId);
                contact1.CompanyName = "Altkom 2";

                // user 2
                var contact2 = context1.Contacts.Find(contactId);
                contact2.CompanyName = "Motorola 2";
                context2.SaveChanges();

                // user 1
                context1.SaveChanges();
            }
        }

        public void Solution11A()
        {
            using (var context1 = new RadioContext())
            using (var context2 = new RadioContext())
            {
                context1.Database.Log += msg => WriteOutput(msg, ConsoleColor.Green);
                context2.Database.Log += msg => WriteOutput(msg, ConsoleColor.Blue);

                Random random = new Random();

                // user 1
                var contact1 = context1.Contacts.Find(contactId);
                contact1.CompanyName = $"Altkom {random.Next(1, 100)}";

                try
                {
                    // user 2
                    var contact2 = context2.Contacts.Find(contactId);
                    contact2.CompanyName = $"Motorola {random.Next(1, 100)}";
                    context2.SaveChanges();

                    // user 1
                    context1.SaveChanges();
                }
                catch(DbUpdateConcurrencyException e)
                {
                    WriteOutput("Another user was changed data", ConsoleColor.Red);

                   // var original = context1.Entry(contact1).OriginalValues.ToObject();
                     var my = context1.Entry(contact1).CurrentValues.ToObject();

                    // Refresh object from database
                    context1.Entry(contact1).Reload();

                    var current = context1.Entry(contact1).OriginalValues.ToObject();
                }
            }
        }


        public void Solution11B()
        {
            int deviceId = 1001;

            using (var context1 = new RadioContext())
            using (var context2 = new RadioContext())
            {
                context1.Database.Log += msg => WriteOutput(msg, ConsoleColor.Green);
                context2.Database.Log += msg => WriteOutput(msg, ConsoleColor.Blue);

                Random random = new Random();

                // user 1
                var device1 = context1.Devices.Find(deviceId);
                device1.Model = $"DP {random.Next(1, 100)}";

                try
                {
                    // user 2
                    var device2 = context2.Devices.Find(deviceId);
                    device2.Firmware = $"1.0.0.{random.Next(1, 10)}";
                    context2.SaveChanges();

                    // user 1
                    context1.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    WriteOutput("Another user was changed data", ConsoleColor.Red);
                }
            }
        }
    }
}
