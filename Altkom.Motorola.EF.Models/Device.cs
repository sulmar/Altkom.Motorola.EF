using System.Collections.Generic;

namespace Altkom.Motorola.EF.Models
{
    public class Device : Base
    {
        public string Name { get; set; }
        public string Firmware { get; set; }
        public string Description { get; set; }
        public ICollection<Call> Calls { get; set; }

    }
}
