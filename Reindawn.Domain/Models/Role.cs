using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Reindawn.Domain.Models
{
    public class CustomUserRole : IdentityUserRole<Guid>
    {
        
    }
    public class CustomUserClaim : IdentityUserClaim<Guid> { }
    public class CustomUserLogin : IdentityUserLogin<Guid> { }

    public class Role : IdentityRole<Guid, CustomUserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
    
}
