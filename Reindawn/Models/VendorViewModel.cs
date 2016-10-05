using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reindawn.Models
{
    public class VendorViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Business Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public List<SelectListItem> Countries { get; set; }

        [Display(Name = "Province/State")]
        public string Province { get; set; }
        [Display(Name = "Street Address")]
        public string Street1 { get; set; }
        [Display(Name = "Street Address")]
        public string Street2 { get; set; }
        public string City { get; set; }
        [Display(Name = "Postal/Zip Code")]
        public string Postal { get; set; }
        [Display(Name = "Use a separate shipping address")]
        public bool SeparateShippingAddress { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }
        [Display(Name = "Terms or Payment")]
        public Guid? PaymentAccountId { get; set; } //Terms or Payment
        public List<SelectListItem> PaymentAccounts { get; set; }
        [Display(Name = "Income Account")]
        public Guid? ExpenseAccountId { get; set; }
        public List<SelectListItem> ExpenseAccounts { get; set; }
    }
}