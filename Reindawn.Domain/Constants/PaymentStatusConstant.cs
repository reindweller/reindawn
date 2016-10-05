using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reindawn.Domain.Constants
{
    public sealed class PaymentStatusConstant
    {
        public const string Paid = "Paid";
        public const string Due = "Due in {0} days";
        public const string Overdue = "Overdue {0} days";
    }
}
