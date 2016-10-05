using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reindawn.Domain.Models;
using Reindawn.Models;
using Reindawn.Repository;
using Reindawn.Service;
using Reindawn.Utilities;
using Reindawn.Utilities.Extensions;


namespace Reindawn.Controllers
{
    public class AccountTypeController : AbstractEntryController<AccountType, AccountTypeViewModel>
    {
        private static readonly IUnitOfWork UnitOfWork = new UnitOfWork();
        readonly IEntityService<AccountType> _accountTypeService = new AccountTypeService(UnitOfWork);
        
        protected override AccountType AssignViewModelToEntity(AccountTypeViewModel viewModel)
        {

            return viewModel.Convert<AccountTypeViewModel, AccountType>();
        }

        protected override AccountTypeViewModel AssignEntityToViewModel(AccountType entity)
        {

            return entity.Convert<AccountType, AccountTypeViewModel>();
        }

        protected override IEntityService<AccountType> GetService()
        {
            return _accountTypeService;
        }

        
    }
}
