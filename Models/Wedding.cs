using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        public int WeddingId { get; set; }
        public string SpouseOne { get; set; }
        public string SpouseTwo { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }

        [InverseProperty("Wedding")]
        public List<GuestConnection> Guests { get; set; }

        public Wedding()
        {
            Guests = new List<GuestConnection>();
        }
    }
}