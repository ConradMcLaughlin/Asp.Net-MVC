using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DOB { get; set; }

        public bool IsSubscribedToNewsletter {get; set;}

        public MembershipType MembershipType { get; set; }  //This is known as a navigation property

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }  //Entity Framework knows that this is a foreign key (based on naming convention)
    }
}