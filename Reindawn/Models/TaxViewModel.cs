using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reindawn.Models
{
    public class TaxViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Abbreviation")]
        public string Code { get; set; }
        public string Description { get; set; }
        [Display(Name = "Registration #")]
        public string RegistrationNo { get; set; }
        [Display(Name = "Rate(%)")]
        public decimal Rate { get; set; }
        [Display(Name = "Effective Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveDate { get; set; }
        [Display(Name = "Registered?")]
        public bool Registered { get; set; }
        [Display(Name = "Cumulative?")]
        public bool Cumulative { get; set; }
        [Display(Name = "Receivable Account")]
        public Guid? ReceivableAccountId { get; set; }
        public List<SelectListItem> ReceivableAccounts { get; set; }
        [Display(Name = "Payable Account")]
        public Guid? PayableAccountId { get; set; }
        public List<SelectListItem> PayableAccounts { get; set; }
        [Display(Name = "Expense Account")]
        public Guid? ExpenseAccountId { get; set; }
        public List<SelectListItem> ExpenseAccounts { get; set; }
    }
}