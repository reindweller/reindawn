using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reindawn.Domain.Models;
using Reindawn.Models;
using Reindawn.Repository;
using Reindawn.Repository.Context;
using Reindawn.Service;
using Reindawn.Service.IdentityHelper;
using Reindawn.Utilities.Extensions;

namespace Reindawn.Controllers
{
    public class ItemController : AbstractEntryController<Item, ItemViewModel>
    {
        private static readonly IUnitOfWork UnitOfWork = new UnitOfWork();
        readonly IEntityService<Item> _itemService = new ItemService(UnitOfWork);

        protected override Item AssignViewModelToEntity(ItemViewModel viewModel)
        {

            if (!viewModel.Sell)
            {
                viewModel.SellPrice = 0;
                viewModel.IncomeAccountId = null;
            }

            if (!viewModel.Buy)
            {
                viewModel.BuyPrice = 0;
                viewModel.ExpenseAccountId = null;
            }

            return viewModel.Convert<ItemViewModel, Item>();
        }

        protected override ItemViewModel AssignEntityToViewModel(Item entity)
        {

            return entity.Convert<Item, ItemViewModel>();
        }

        protected override IEntityService<Item> GetService()
        {
            return _itemService;
        }

        protected override ItemViewModel SetViewModelData(ItemViewModel viewModel)
        {
            var accountService = new AccountService(UnitOfWork);
            var businessId = User.Identity.GetBusinessId();
            if (businessId == null)
            {
                return viewModel;
            }
            viewModel.IncomeAccounts = accountService.GetIncomeAccounts((Guid)businessId).Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            viewModel.ExpenseAccounts = accountService.GetExpenseAccounts((Guid)businessId).Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            var taxService = new TaxService(UnitOfWork);
            viewModel.Taxes = taxService.Filter(o=>o.BusinessId == businessId).Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            return viewModel;
        }

    }
}
