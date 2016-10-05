using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reindawn.Models
{
    public class IncomeDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid IncomeAccountId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid? SalesTaxId { get; set; }
    }
}