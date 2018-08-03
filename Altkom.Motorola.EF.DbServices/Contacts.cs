namespace Altkom.Motorola.EF.DbServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contacts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contacts()
        {
            Calls = new HashSet<Calls>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public bool IsRemoved { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calls> Calls { get; set; }
    }
}
