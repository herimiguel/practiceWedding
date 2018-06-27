using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        
        [InverseProperty("Guest")]
        public List<GuestConnection> WeddingsAttending { get; set; }

        public User()
        {
            WeddingsAttending = new List<GuestConnection>();
        }
    }
}