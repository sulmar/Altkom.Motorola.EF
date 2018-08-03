namespace Altkom.Motorola.EF.DbServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Calls
    {
        public int Id { get; set; }

        public DateTime BeginCallDate { get; set; }

        public DateTime? EndCallDate { get; set; }

        public int ChannelId { get; set; }

        public bool IsAnswered { get; set; }

        public int Status { get; set; }

        public int? Sender_Id { get; set; }

        public int? Source_Id { get; set; }

        public int? Target_Id { get; set; }

        public int? Device_Id { get; set; }

        public virtual Contacts Contacts { get; set; }

        public virtual Devices Devices { get; set; }

        public virtual Devices Devices1 { get; set; }
    }
}
