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
    public class TaxController : AbstractEntryController<Tax, TaxViewModel>
    {
        private static readonly IUnitOfWork UnitOfWork = new UnitOfWork();
        readonly IEntityService<Tax> _taxService = new TaxService(UnitOfWork);

        protected override Tax AssignViewModelToEntity(TaxViewModel viewModel)
        {

            return viewModel.Convert<TaxViewModel, Tax>();
        }

        protected override TaxViewModel AssignEntityToViewModel(Tax entity)
        {

            return entity.Convert<Tax, TaxViewModel>();
        }

        protected override IEntityService<Tax> GetService()
        {
            return _taxService;
        }

        protected override TaxViewModel SetViewModelData(TaxViewModel viewModel)
        {
            var accountService = new AccountService(UnitOfWork);
            var businessId = User.Identity.GetBusinessId();
            if (businessId == null)
            {
                return viewModel;
            }
            viewModel.ReceivableAccounts = accountService.GetTaxesAndRemitances((Guid)businessId).Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            viewModel.PayableAccounts = accountService.GetTaxesAndRemitances((Guid)businessId).Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            viewModel.ExpenseAccounts = accountService.GetExpenseAccounts((Guid)businessId).Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            if (viewModel.EffectiveDate == DateTime.MinValue) viewModel.EffectiveDate = DateTime.Now;

            return viewModel;
        }
        

    }
}
