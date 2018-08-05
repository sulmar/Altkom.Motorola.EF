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
        public void Example8()
        {
            int userId = 2004;

            using (var context = new RadioContext())
            {
                User user = context.Contacts.OfType<User>().Single(u => u.Id == userId);

                context.Contacts.Remove(user);

                context.SaveChanges();
            }
        }

        public void Solution8()
        {
            // 
        }
    }
}
