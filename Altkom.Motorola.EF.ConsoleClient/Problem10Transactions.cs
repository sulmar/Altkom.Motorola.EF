using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        public void Example10()
        {
            const string sql = @"update Devices 
                                    set Firmware = '9.9.9.9' 
                                    where Model = 'SL2600'";

            const string deleteSql = @"delete from Contacts where Id = 2011";


            using (var context = new RadioContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                Contact contact = context.Contacts.Single(p => p.Id == 2011);

                context.Database.ExecuteSqlCommand(deleteSql);

                context.Contacts.Remove(contact);

                context.SaveChanges();

                transaction.Commit();

            }
        }


        public void Solution10B()
        {
            const string sql = @"update Devices 
                                    set Firmware = '9.9.9.9' 
                                    where Model = 'SL2600'";

            const string deleteSql = @"delete from Contacts where Id = 2011";

            int contactId = 2011;

            using (var context = new RadioContext())
            using (var context2 = new RadioContext(context.Database.Connection))
            using (var transaction = context.Database.BeginTransaction())
            {
                // context 2
                context2.Database.UseTransaction(transaction.UnderlyingTransaction);
                Contact contact = context2.Contacts.Find(contactId);
                contact.Country = "Poland";
                context2.SaveChanges();

                // context 1
                context.Database.ExecuteSqlCommand(deleteSql);
                context.Contacts.Remove(contact);

                context.SaveChanges();

                transaction.Commit();
            }
        }

        public void Solution10C()
        {
            int contactId = 2016;
            int deviceId = 1007;

            // Add reference: System.Transactions
            using (var transactionScope = new TransactionScope())
            using (var context1 = new RadioContext())
            using (var context2 = new RadioContext())
            {
                // operacje na context1
                var contact = context1.Contacts.Find(contactId);
                contact.CompanyName = "Altkom";
                context1.SaveChanges();

                // operacje na context2
                var device = context2.Devices.Find(deviceId);
                device.Color = "Blue";
                context2.SaveChanges();

                transactionScope.Complete();
            }
        }
    }
}
