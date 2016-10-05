using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reindawn.Domain.Helper;
using Reindawn.Domain.Models;
using Reindawn.Models;
using Reindawn.Repository;
using Reindawn.Repository.Context;
using Reindawn.Service;
using Reindawn.Service.IdentityHelper;
using Reindawn.Utilities.Extensions;

namespace Reindawn.Controllers
{
    public class VendorController : AbstractEntryController<Vendor, VendorViewModel>
    {
        private static readonly IUnitOfWork UnitOfWork = new UnitOfWork();
        readonly IEntityService<Vendor> _vendorService = new VendorService(UnitOfWork);

        protected override Vendor AssignViewModelToEntity(VendorViewModel viewModel)
        {

            return viewModel.Convert<VendorViewModel, Vendor>();
        }

        protected override VendorViewModel AssignEntityToViewModel(Vendor entity)
        {

            var vendorViewModel = entity.Convert<Vendor, VendorViewModel>();

            vendorViewModel.Address = String.Format("{0} {1} {2} {3} {4} {5}",
            vendorViewModel.Street1,
            vendorViewModel.Street2,
            vendorViewModel.Province,
            vendorViewModel.City,
            vendorViewModel.Country,
            vendorViewModel.Postal
            );

            return vendorViewModel;
        }

        protected override IEntityService<Vendor> GetService()
        {
            return _vendorService;
        }

        protected override VendorViewModel SetViewModelData(VendorViewModel viewModel)
        {
            var accountService = new AccountService(UnitOfWork);
            var businessId = User.Identity.GetBusinessId();
            if (businessId == null)
            {
                return viewModel;
            }
            viewModel.PaymentAccounts = accountService.GetPaymentAccounts((Guid)businessId).Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            viewModel.ExpenseAccounts = accountService.GetIncomeAccounts((Guid)businessId).Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();


            viewModel.Countries = CountryHelper.CountryList().Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Code
            }).ToList();

            return viewModel;
        }

    }
}
