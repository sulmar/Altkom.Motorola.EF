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
            DataLayer dataLayer = new DataLayer();
            dataLayer.Example1();

            //dataLayer.Example1();
            dataLayer.Solution1A();
            dataLayer.Solution1B();
            dataLayer.Solution1C();

            //dataLayer.Example2();
            // dataLayer.Solution2();
            // dataLayer.Solution2B();

            // dataLayer.Example4();

            // dataLayer.Example5();

            //for (int i = 0; i < 10; i++)
            //{
            //    dataLayer.Example6();
            //    dataLayer.Solution6A();
            //}

            // dataLayer.Solution6B();

            //dataLayer.Example6C();
            //dataLayer.Solution6C();

            dataLayer.Solution6E();

            // dataLayer.Solution9A();
            //dataLayer.Solution9B();
            //dataLayer.Solution9C();

            // dataLayer.Example10();
            //            dataLayer.Solution10B();

            //            dataLayer.Solution10C();

            //dataLayer.Solution11A();

            //dataLayer.Example12();
            //dataLayer.Solution12();

            // dataLayer.Example13();

            dataLayer.Example14();
            dataLayer.Solution14();

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
                    var calls = SampleData.Generate(1000, 1000, 1000, 700000);

                    Debug.WriteLine("Saving to database...");
                    // callsService.AddRange(calls);
                    callsService.AddBatch(calls);

                    Debug.WriteLine("Success.");
                }
            }

            

        }
    }
}
