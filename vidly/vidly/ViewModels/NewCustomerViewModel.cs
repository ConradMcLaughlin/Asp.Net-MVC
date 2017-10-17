using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public string FormTitle
        {
            get
            {
                return (Customer == null || Customer.ID == 0) ? "New Customer" : "Edit Customer";
            }
        }
    }
}