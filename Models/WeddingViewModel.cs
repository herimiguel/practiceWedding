using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models
{
    public class WeddingViewModel : BaseEntity
    {
        [Required]
        public string SpouseOne { get; set; }
        
        [Required]
        public string SpouseTwo { get; set; }
        
        [Required]        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Required]
        public string Address { get; set; }
    }
}