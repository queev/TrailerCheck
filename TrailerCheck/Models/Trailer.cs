using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerCheck.Models
{
    public class Trailer
    {
        public int ID { get; set; }
        public string SerialNumber { get; set; }
        public string ProductGroup { get; set; }
        public string Description { get; set; }
        public string YearOfManufacture { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
