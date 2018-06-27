using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models
{
    public class GuestConnection : BaseEntity
    {
        public int GuestConnectionId { get; set; }
        
        public int GuestId { get; set; }
        
        [ForeignKey("GuestId")]
        public User Guest { get; set; }
        
        public int WeddingId { get; set; }
        
        [ForeignKey("WeddingId")]
        public Wedding Wedding { get; set; }
    }
}