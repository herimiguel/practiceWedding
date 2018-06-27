using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace weddingPlanner.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [Display(Name="First Name")]
        public string first_name { get; set; }
 
        [Required]
        [Display(Name="Last Name")]
        public string last_name { get; set; }
 
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password and confirmation must match.")]
        [Display(Name="Confirm Password")]
        public string confirm { get; set; }
    }
}