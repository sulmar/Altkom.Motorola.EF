using System.Collections.Generic;

namespace Altkom.Motorola.EF.Models
{
    public abstract class Contact : Base
    {        
        public abstract string FullName { get; }
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public bool IsRemoved { get; set; }
        public ICollection<Call> Calls { get; set; }
    }

    public class User : Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string FullName => $"{FirstName} {LastName}";
    }

    public class Group : Contact
    {
        public string Name { get; set; }
        public override string FullName => this.Name; 
    }
}
