using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
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
    public class CustomerController : AbstractEntryController<Customer, CustomerViewModel>
    {
        private static readonly IUnitOfWork UnitOfWork = new UnitOfWork();
        readonly IEntityService<Customer> _customerService = new CustomerService(UnitOfWork);

        protected override Customer AssignViewModelToEntity(CustomerViewModel viewModel)
        {

            return viewModel.Convert<CustomerViewModel, Customer>();
        }

        protected override CustomerViewModel AssignEntityToViewModel(Customer entity)
        {
            var customerViewModel = entity.Convert<Customer, CustomerViewModel>();

            customerViewModel.Address = String.Format("{0} {1} {2} {3} {4} {5}",
            customerViewModel.Street1,
            customerViewModel.Street2,
            customerViewModel.Province,
            customerViewModel.City,
            customerViewModel.Country,
            customerViewModel.Postal
            );
            
            return customerViewModel;
        }

        protected override IEntityService<Customer> GetService()
        {
            return _customerService;
        }

        protected override CustomerViewModel SetViewModelData(CustomerViewModel viewModel)
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

            viewModel.IncomeAccounts = accountService.GetIncomeAccounts((Guid)businessId).Select(o => new SelectListItem
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
