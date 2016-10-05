using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Reindawn.Domain.Constants;
using Reindawn.Domain.Enumerations;
using Reindawn.Domain.Models;
using Reindawn.Repository;

namespace Reindawn.Service
{
    public class AccountTypeService : AbstractEntityService<AccountType>
    {
        public AccountTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Expression<Func<AccountType, bool>> FindEntityPrimaryById(Guid id)
        {
            return o => o.Id == id;
        }

        protected override Expression<Func<AccountType, object>>[] Include()
        {
            return null;
        }

        protected override IOrderedQueryable<AccountType> OrderBy(IQueryable<AccountType> arg)
        {
            return arg.OrderBy(o => o.Name);
        }
        
    }
}
