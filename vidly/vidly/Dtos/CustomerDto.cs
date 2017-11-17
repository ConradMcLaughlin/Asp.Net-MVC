using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Dtos
{
    public class CustomerDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? DOB { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}