using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reindawn.Domain.Enumerations
{
    public enum TermsEnum
    {
        [Description("Due On Receipt")]
        DueOnReceipt = 0,

        [Description("30 Days")]
        Days30 = 1,

        [Description("60 Days")]
        Days60 = 2,

        [Description("90 Days")]
        Days90 = 3
    }
}
