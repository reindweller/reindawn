using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reindawn.Domain.Enumerations;

namespace Reindawn.Models
{
    public class AccountNumberingViewModel
    {
        public Guid Id { get; set; }
        public AccountMainTypeEnum AccountMainType { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DebitCredit Increase { get; set; }
    }
}