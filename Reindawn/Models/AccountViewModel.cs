using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reindawn.Models
{

    public class AccountViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Account Number")]
        public int No { get; set; }
        [Display(Name = "Account Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Account Type")]
        public Guid AccountTypeId { get; set; }
        [Display(Name = "Account Type")]
        public string AccountTypeName { get; set; }
        public List<SelectListItem> AccountTypes { get; set; }

    }
}