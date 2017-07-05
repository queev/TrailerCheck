using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrailerCheck.Models
{
    public class Owner
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}