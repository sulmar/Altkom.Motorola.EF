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
        public void Example12()
        {
            UserSearchCriteria criteria = new UserSearchCriteria
            {
                Country = "Poland"
            };

            using (var context = new RadioContext())
            {
                context.Database.Log += msg => WriteOutput(msg, ConsoleColor.Blue);

                List<User> contacts = context.Contacts
                    .OfType<User>()
                    .Where(c => criteria.FirstName == null || c.FirstName == criteria.FirstName)
                    .Where(c => criteria.LastName == null || c.LastName == criteria.LastName)
                    .Where(c => criteria.Country == null || c.Country == criteria.Country)
                    .Take(100)
                    .ToList();
            }



        }

        [Time]
        public void Solution12()
        {
            UserSearchCriteria criteria = new UserSearchCriteria
            {
                Country = "Poland"
            };

            using (var context = new RadioContext())
            {
                context.Database.Log += msg => WriteOutput(msg, ConsoleColor.Green);

                IQueryable<User> contacts = context.Contacts.OfType<User>();

                if (!string.IsNullOrEmpty(criteria.FirstName))
                {
                    contacts = contacts.Where(c => c.FirstName == criteria.FirstName);
                }

                if (!string.IsNullOrEmpty(criteria.LastName))
                {
                    contacts = contacts.Where(c => c.LastName  == criteria.LastName);
                }

                if (!string.IsNullOrEmpty(criteria.Country))
                {
                    contacts = contacts.Where(c => c.Country == criteria.Country);
                }

                List<User> filteredUsers = contacts.Take(100).ToList();
            }



        }
    }


    public abstract class ContactSearchCriteria
    {
        public string Country { get; set; }
    }

    public class UserSearchCriteria : ContactSearchCriteria
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
    }
}
