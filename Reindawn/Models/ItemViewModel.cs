using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reindawn.Models
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "SKU")]
        public string Unit { get; set; }
        [Display(Name = "Tax")]
        public Guid? TaxId { get; set; }
        public List<SelectListItem> Taxes { get; set; }
        public string Description { get; set; }
        [Display(Name = "I Sell This")]
        public bool Sell { get; set; }
        [Display(Name = "Sell Price")]
        public decimal SellPrice { get; set; }
        [Display(Name = "Income Account")]
        public Guid? IncomeAccountId { get; set; }
        public List<SelectListItem> IncomeAccounts { get; set; }
        [Display(Name = "I Buy This")]
        public bool Buy { get; set; }
        [Display(Name = "Buy Price")]
        public decimal BuyPrice { get; set; }
        [Display(Name = "Expense Account")]
        public Guid? ExpenseAccountId { get; set; }
        public List<SelectListItem> ExpenseAccounts { get; set; }


    }
}