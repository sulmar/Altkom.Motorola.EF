using System.Collections.Generic;

namespace Altkom.Motorola.EF.Models
{
    public class Device : Base
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Firmware { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public float Weight { get; set; }
        // Navigation property
        public virtual ICollection<Call> Calls { get; set; }


    }
}
