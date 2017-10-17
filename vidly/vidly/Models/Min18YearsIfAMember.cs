using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.DOB == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age = DateTime.Now.Year - customer.DOB.Value.Year;

            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to be a member");  
        }
    }
}