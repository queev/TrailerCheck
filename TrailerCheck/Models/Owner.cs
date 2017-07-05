using System;
using System.Collections.Generic;

namespace TrailerCheck.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}