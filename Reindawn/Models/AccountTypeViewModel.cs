using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reindawn.Models
{
    public class AccountTypeViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}