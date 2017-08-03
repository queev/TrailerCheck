using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrailerCheck.Models
{
    public class Owner
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Address Line 1 cannot be longer than 50 characters.")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [StringLength(50, ErrorMessage = "Address Line 2 cannot be longer than 50 characters.")]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Town cannot be longer than 50 characters.")]
        [Display(Name = "Town")]
        public string Town { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "County cannot be longer than 50 characters.")]
        [Display(Name = "County")]
        public string County { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return AddressLine1 + " " + AddressLine2 + " " + Town + " " + County;
            }
        }
        public ICollection<Registration> Registrations { get; set; }
    }
}