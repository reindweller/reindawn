using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Reindawn.Repository;

namespace Reindawn.Service.IdentityHelper
{
    public static class IdentityExtensions
    {
        //public static Guid? GetBusinessId(this IIdentity identity)
        //{
        //    //identity.get
        //    var claim = ((ClaimsIdentity)identity).FindFirst("BusinessId");
        //    // Test for null to avoid issues during local testing
        //    return (claim != null) ? new Guid(claim.Value) : Guid.Empty;
        //}

        //public static string GetBusinessName(this IIdentity identity)
        //{
        //    //identity.get
        //    var claim = ((ClaimsIdentity)identity).FindFirst("BusinessId");
        //    // Test for null to avoid issues during local testing
        //    if (claim == null)
        //    {
        //        return "Reindawn";
        //    }

        //    BusinessService businessService = new BusinessService(new UnitOfWork());
        //    var business = businessService.Find(new Guid(claim.Value));
        //    return business != null? business.Name : "Reindawn";
        //}
    }
}
