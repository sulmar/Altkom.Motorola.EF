using Altkom.Motorola.EF.DbServices;
using Altkom.Motorola.EF.Generator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureDebug();

            Debug.WriteLine($"Started at {DateTime.Now} . ");

            Generate();

            // TODO: Create tests



            Debug.WriteLine($"Finished.");

            Debug.Flush();

        }


        static void ConfigureDebug()
        {
            TraceListener listener = new DelimitedListTraceListener(@"debug.txt");
            TraceListener consoleListener = new ConsoleTraceListener();

            Debug.Listeners.Add(listener);
            Debug.Listeners.Add(consoleListener);
        }

        static void Generate()
        {
            
            using (var context = new RadioContext())
            {
                if (!context.Database.Exists())
                {
                    Debug.WriteLine("Creating database...");
                }
                
                DbCallsService callsService = new DbCallsService(context);

                if (!callsService.Any())
                {
                    var calls = SampleData.Generate(1000, 1000, 1000000);

                    Debug.WriteLine("Saving to database...");
                    // callsService.AddRange(calls);
                    callsService.AddBatch(calls);

                    Debug.WriteLine("Success.");
                }
            }

            

        }
    }
}
