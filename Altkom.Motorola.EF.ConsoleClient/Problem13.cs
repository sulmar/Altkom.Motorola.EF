using Altkom.Motorola.EF.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MethodTimer;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        [Time]
        public void Example13()
        {
            using (var context = new RadioContext())
            {
                context.Database.Log += msg
                    => WriteOutput(msg, ConsoleColor.Green);


                // note: using System.Data.Entity;
                var calls = context.Calls
                    .Include(p => p.Source)
                    .Include(p => p.Sender)
                    .AsNoTracking()
                    .Select(c => new
                    {
                        c.Id,
                        c.Status,
                        c.Source.Model,
                        c.Source.Firmware,
                        c.Sender.Country,
                        c.Sender.CompanyName
                    })
                    .ToList();
            }
        }
    }
}
