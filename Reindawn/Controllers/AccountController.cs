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
    [Authorize]
    public class AccountController : AbstractEntryController<Account, AccountViewModel>
    {
        private static readonly IUnitOfWork UnitOfWork = new UnitOfWork();
        readonly IEntityService<Account> _accountService = new AccountService(UnitOfWork);

        //public override ActionResult Index(Guid? id = null)
        //{
        //    var businessId = User.Identity.GetBusinessId();
        //    var records = GetService().Filter(o => o.BusinessId == businessId).Select(AssignEntityToViewModel);
        //    return View(records);
        //}


        protected override Account AssignViewModelToEntity(AccountViewModel viewModel)
        {

            return viewModel.Convert<AccountViewModel, Account>();
        }

        protected override AccountViewModel AssignEntityToViewModel(Account entity)
        {
            var viewModel = entity.Convert<Account, AccountViewModel>();

            var accountType = new AccountTypeService(UnitOfWork);
            viewModel = entity.Convert<Account, AccountViewModel>();
            viewModel.AccountTypeName = accountType.Find(entity.AccountTypeId).Name;
            return viewModel;
        }
        

        protected override AccountViewModel SetViewModelData(AccountViewModel viewModel)
        {
            var accountType = new AccountTypeService(UnitOfWork);
            viewModel.AccountTypes = accountType.GetAll().Select(o=> new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            return viewModel;
        }

        protected override IEntityService<Account> GetService()
        {
            return _accountService;
        }
    }
}
