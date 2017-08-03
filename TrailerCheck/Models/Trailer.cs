using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrailerCheck.Models
{
    public class Trailer
    {
        public int ID { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Product Group")]
        public string ProductGroup { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Year Of Manufacture")]
        public string YearOfManufacture { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
