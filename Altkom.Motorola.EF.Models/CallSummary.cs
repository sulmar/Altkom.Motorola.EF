using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Motorola.EF.Models
{
    public class CallSummary : Base
    {
        public CallStatus Status { get; set; }
        public string Model { get; set; }
        public string Firmware { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }

    }
}
