using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.ConsoleClient
{
    public partial class DataLayer
    {
        private void WriteOutput(string messsage, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(messsage);
            Console.ResetColor();

        }
    }
}
