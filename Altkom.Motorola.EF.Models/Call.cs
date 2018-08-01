using System;

namespace Altkom.Motorola.EF.Models
{
    public class Call : Base
    {
        public DateTime BeginCallDate { get; set; }
        public DateTime? EndCallDate { get; set; }
        
        // Navigation property
        public virtual Device Source { get; set; }
        public virtual Contact Sender { get; set; }
        public virtual Device Target { get; set; }
        public int ChannelId { get; set; }
        public bool IsAnswered { get; set; }
        public CallStatus Status { get; set; }
    }
}
