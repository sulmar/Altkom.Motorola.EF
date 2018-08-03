using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MethodTimer;

namespace Altkom.Motorola.EF.ConsoleClient
{
    // Problem14CacheBlot
    public partial class DataLayer
    {
        [Time]
        public void Example14()
        {
            var model = new Model { Page = 2, ResultsPerPage = 10 };
            
            using (var context = new RadioContext())
            {
                context.Database.Log += msg => WriteOutput(msg, ConsoleColor.Red);

                List<Device> devices = context.Devices
                    .OrderBy(d=>d.Model)
                    .Skip(model.Page * model.ResultsPerPage)
                    .Take(model.ResultsPerPage)
                    .ToList();
            }

        }

        [Time]
        public void Solution14()
        {
            var model = new Model { Page = 2, ResultsPerPage = 10 };

            int resulstsToSkip = model.Page * model.ResultsPerPage;

            // note: using System.Data.Entity;
            using (var context = new RadioContext())
            {
                context.Database.Log += msg => WriteOutput(msg, ConsoleColor.Green);

                List<Device> devices = context.Devices
                    .OrderBy(d => d.Model)
                    .Skip(()=>resulstsToSkip)
                    .Take(()=>model.ResultsPerPage)
                    .ToList();
            }

        }
    }


    public class Model
    {
        public int Page { get; set; }
        public int ResultsPerPage { get; set; }
    }
}
