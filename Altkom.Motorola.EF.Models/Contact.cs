using System.Collections.Generic;

namespace Altkom.Motorola.EF.Models
{
    public class Contact : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public bool IsRemoved { get; set; }
        public ICollection<Call> Calls { get; set; }
    }
}
