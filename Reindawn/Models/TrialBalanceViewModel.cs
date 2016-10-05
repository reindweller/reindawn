using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reindawn.Models
{
    public class TrialBalanceViewModel
    {
        public Guid AccountId { get; set; }
        public int AccountNo { get; set; }
        public string AccountName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}