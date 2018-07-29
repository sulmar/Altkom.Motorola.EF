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
            var calls = SampleData.Generate(100, 20, 1000);

            Debug.WriteLine("Saving do database...");

            using (var context = new RadioContext())
            {
                DbCallsService callsService = new DbCallsService(context);

                callsService.AddRange(calls);
            }

            Debug.WriteLine("Success.");

        }
    }
}
