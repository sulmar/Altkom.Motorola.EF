using Altkom.Motorola.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.Generator
{
    public class SampleData
    {
        public static ICollection<Call> Generate(int contactCount, int deviceCount, int callCount)
        {
            var contacts = Fake.Contacts.Generate(contactCount);
            var devices = Fake.Devices.Generate(deviceCount);

            var calls = Fake.Calls(devices, contacts).Generate(callCount);

            return calls;
        }
    }
}
