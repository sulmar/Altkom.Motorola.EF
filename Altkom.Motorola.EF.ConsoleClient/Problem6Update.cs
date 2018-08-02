using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using MethodTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        [Time]
        public void Example6()
        {
            int userId = 2009;

            string firstName = "Marcin";
            string lastName = "Sulecki";

            using (var context = new RadioContext())
            {
                User user = context.Contacts
                    .OfType<User>()
                    .Single(c => c.Id == userId);

                WriteOutput(context.Entry(user).State.ToString());

                user.FirstName = firstName;
                user.LastName = lastName;

                WriteOutput(context.Entry(user).State.ToString());

                context.SaveChanges();

                WriteOutput(context.Entry(user).State.ToString());

                user.Country = "Poland";

                WriteOutput(context.Entry(user).State.ToString());

                context.SaveChanges();

                WriteOutput(context.Entry(user).State.ToString());

            }
        }

        [Time]
        public void Solution6A()
        {
            int userId = 2009;

            string firstName = "Bartek";
            string lastName = "Sulecki";

            using (var context = new RadioContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                User user = context.Contacts
                    .AsNoTracking()
                    .OfType<User>()
                    .Single(c => c.Id == userId);

                // TODO: Long process

                WriteOutput(context.Entry(user).State.ToString());

                context.Contacts.Attach(user);

                user.FirstName = firstName;
                user.LastName = lastName;

                WriteOutput(context.Entry(user).State.ToString());

                

                WriteOutput(context.Entry(user).State.ToString());

                context.ChangeTracker.DetectChanges();

                WriteOutput(context.Entry(user).State.ToString());

                context.SaveChanges();

                WriteOutput(context.Entry(user).State.ToString());

                user.Country = "Poland";

                WriteOutput(context.Entry(user).State.ToString());

                context.SaveChanges();

                WriteOutput(context.Entry(user).State.ToString());

            }
        }

        public void Example6C()
        {
            int userId = 2008;

            using (var context = new RadioContext())
            {
                User user = context.Contacts.OfType<User>().Single(u => u.Id == userId);

                // User user = context.Contacts.Include(c=>c.Calls).OfType<User>().Single(u => u.Id == userId);

                context.Contacts.Remove(user);

                var entities = context.ChangeTracker.Entries();

                context.SaveChanges();
            }
        }

        public void Solution6C()
        {
            int userId = 1000;

            User user = new User { Id = userId };

            using (var context = new RadioContext())
            {
                context.Contacts.Attach(user);
                context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();                
            }
        }

        public void Solution6B()
        {
            int userId = 747474;

            string firstName = "Bartek";
            string lastName = "Sulecki";
            string country = "Country";
            string companyName = "Altkom";

            // symulacja deserializacji
            User user = new User
            {
                Id = userId,
                FirstName = firstName,
                LastName = lastName,
                Country = country,
                CompanyName = companyName
            };

            using (var context = new RadioContext())
            {
                //if (context.Contacts.Any(u=>u.Id == user.Id))
                //{
                    WriteOutput(context.Entry(user).State.ToString());

                    context.Contacts.Attach(user);

                    WriteOutput(context.Entry(user).State.ToString());

                    context.Entry(user).State = System.Data.Entity.EntityState.Modified;

                    WriteOutput(context.Entry(user).State.ToString());

                    var entities = context.ChangeTracker.Entries()
                        .Select(x => new { x.Entity, x.State });

                    context.SaveChanges();

                    WriteOutput(context.Entry(user).State.ToString());
                //}
                //else
                //{
                //    return;
                //}

               
            }




        }
    }

    //public static class DbSetExtensions    
    //{

    //    public 

    //}
}
