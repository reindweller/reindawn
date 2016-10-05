using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reindawn.Domain.Enumerations;
using Reindawn.Domain.Models;

namespace Reindawn.Models
{
    public class IncomeViewModel
    {
        
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Customer")]
        [Required]
        public Guid CustomerId { get; set; }
        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        public List<CustomerViewModel> Customers { get; set; }


        [Display(Name = "Invoice #")]
        [Required]
        public string InvoiceNo { get; set; }

        [Display(Name = "Payment Account")]
        [Required]
        public Guid PaymentAccountId { get; set; }
        public List<AccountViewModel> PaymentAccounts { get; set; }

        [Display(Name = "Payment Terms")]
        public TermsEnum PaymentTerms { get; set; }
        //public TermsEnum PaymentTermsList { get; set; }

        [Display(Name = "Pre-payment, credit, or overpayment")]
        public Guid? PrepaymentId { get; set; }
        public List<AccountViewModel> PrepaymentAccounts { get; set; }
        public decimal PrepaymentAmount { get; set; }

        [Display(Name = "P.O./S.O.#")]
        [Required]
        public string PoSoNo { get; set; }

        [Required]
        public string Terms { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? DueDate { get; set; }
        [Required]
        public string Memo { get; set; }

        public List<IncomeDetailViewModel> IncomeDetails { get; set; }

        public string Details { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }

        [Display(Name = "Income Account")]
        public Guid IncomeAccountId { get; set; }
        public List<AccountViewModel> IncomeAccounts { get; set; }

        public List<TaxViewModel> Taxes { get; set; }

    }
}