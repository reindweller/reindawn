using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reindawn.Domain.Constants;
using Reindawn.Domain.Enumerations;
using Reindawn.Domain.Helper;
using Reindawn.Domain.Models;
using Reindawn.Models;
using Reindawn.Repository;
using Reindawn.Service;
using Reindawn.Service.IdentityHelper;
using Reindawn.Utilities.Extensions;
using WebGrease.Css.Extensions;

namespace Reindawn.Controllers
{

    public class IncomeController : AbstractEntryController<Income, IncomeViewModel>
    {
        private static readonly IUnitOfWork UnitOfWork = new UnitOfWork();
        readonly IEntityService<Income> _incomeService = new IncomeService(UnitOfWork);

        protected override Income AssignViewModelToEntity(IncomeViewModel viewModel)
        {
            var entity = viewModel.Convert<IncomeViewModel, Income>();

            var accountService = new AccountService(UnitOfWork);
            var accountTypeService =  new AccountTypeService(UnitOfWork);
            var account = accountService.Find(entity.PaymentAccountId);
            var accountType = accountTypeService.Find(account.AccountTypeId);

            entity.Status = (accountType.Name != AccountTypeConstant.AccountsReceivable);
            return entity;
        }

        protected override IncomeViewModel AssignEntityToViewModel(Income entity)
        {
            var incomeService = new IncomeService(UnitOfWork);
            var incomeDetailService = new IncomeDetailService(UnitOfWork);

            IncomeViewModel viewModel = entity.Convert<Income, IncomeViewModel>();

            viewModel.Status = incomeService.GetStatus(viewModel.Id);

            var incomeDetails = incomeDetailService.Filter(o => o.IncomeId == entity.Id);

            if (incomeDetails != null)
            {
                viewModel.IncomeDetails =
                    incomeDetails.Select(o => o.Convert<IncomeDetail, IncomeDetailViewModel>()).ToList();
                viewModel.Details = string.Join(", ", incomeDetails.Select(o => o.Description));
                viewModel.Amount = incomeDetails.Sum(o => o.Price*o.Quantity);
            }
            return viewModel;
        }

        protected override IEntityService<Income> GetService()
        {
            return _incomeService;
        }

        protected override IncomeViewModel SetViewModelData(IncomeViewModel viewModel)
        {
            var accountService = new AccountService(UnitOfWork);
            //var incomeService = new IncomeService(UnitOfWork);
            //var incomeDetailService = new IncomeDetailService(UnitOfWork);

            var businessId = User.Identity.GetBusinessId();
            if (businessId == null)
            {
                return viewModel;
            }

            if (viewModel.Date == DateTime.MinValue) viewModel.Date = DateTime.Now;
            if (viewModel.DueDate == DateTime.MinValue) viewModel.DueDate = DateTime.Now;
            viewModel.PaymentAccounts =
                accountService.GetPaymentAccounts((Guid) businessId).Select(o => o.Convert<Account, AccountViewModel>())
                    .ToList();

            viewModel.IncomeAccounts =
                accountService.GetIncomeAccounts((Guid) businessId)
                    .Select(o => o.Convert<Account, AccountViewModel>())
                    .ToList();

            var customerService = new CustomerService(UnitOfWork);
            viewModel.Customers =
                customerService.Filter(o => o.BusinessId == businessId)
                    .Select(o => o.Convert<Customer, CustomerViewModel>())
                    .ToList();

            var taxService = new TaxService(UnitOfWork);
            viewModel.Taxes =
                taxService.Filter(o => o.BusinessId == businessId).Select(o => o.Convert<Tax, TaxViewModel>())
                    .ToList();

            viewModel.PrepaymentAccounts =
                accountService.GetAll().Select(o => o.Convert<Account, AccountViewModel>())
                    .ToList();

            viewModel.InvoiceNo = IncremateInvoiceNo();

            if (viewModel.IncomeDetails == null)
            {
                viewModel.IncomeDetails = new List<IncomeDetailViewModel>
                {
                    new IncomeDetailViewModel
                    {
                        IncomeAccountId = Guid.NewGuid(),
                        Description = "",
                        Quantity = 0,
                        Price = 0,
                        SalesTaxId = Guid.NewGuid()
                    }
                };

            }
            return viewModel;
        }

        private string IncremateInvoiceNo()
        {
            var incomeService = new IncomeService(UnitOfWork);
            var incomeOrderByDesc = incomeService.GetAll().OrderByDescending(o => o.Date).FirstOrDefault();
            string invoiceNo = "00001";
            try
            {
                if (incomeOrderByDesc != null)
                {
                    var invoiceInt = Convert.ToInt32(incomeOrderByDesc.InvoiceNo);
                    invoiceInt = invoiceInt+1;
                    return invoiceInt.ToString().PadLeft(5, '0');
                }
                else
                {
                    return invoiceNo;
                }
            }
            catch (Exception)
            {
                return invoiceNo;
            }
            
        }

        public override ActionResult Create(IncomeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(SetViewModelData(viewModel));

            Income entity = AssignViewModelToEntity(viewModel);
            //var helper = new ActionResultHelper<TEntity>(typeof(TViewModel));
            //helper.Method += Add;
            var businessId = User.Identity.GetBusinessId();
            if (businessId != null) entity.BusinessId = businessId.Value;
            Add(entity);

            var incomeDetailService = new IncomeDetailService(UnitOfWork);
            foreach (var incomeDetail in viewModel.IncomeDetails)
            {
                var detail = new IncomeDetail
                {
                    BusinessId = (Guid)businessId,
                    IncomeId = entity.Id,
                    IncomeAccountId = incomeDetail.IncomeAccountId,
                    Description = incomeDetail.Description,
                    Quantity = incomeDetail.Quantity,
                    Price = incomeDetail.Price,
                    SalesTaxId = incomeDetail.SalesTaxId
                };

                incomeDetailService.Insert(detail);
                
            }

            incomeDetailService.Save();
            return RedirectToAction("Index");
        }

        public override ActionResult Edit(IncomeViewModel viewModel)
        {
            Income entity = AssignViewModelToEntity(viewModel);
            var businessId = User.Identity.GetBusinessId();
            if (businessId != null) entity.BusinessId = businessId.Value;

            //delete existing income detail
            var incomeDetailService = new IncomeDetailService(UnitOfWork);
            incomeDetailService.Filter(o => o.IncomeId == viewModel.Id)
                .ForEach(o=> incomeDetailService.Delete(o.Id));
            //incomeDetailService.Save();

            foreach (var incomeDetail in viewModel.IncomeDetails)
            {
                var detail = new IncomeDetail
                {
                    BusinessId = (Guid)businessId,
                    IncomeId = entity.Id,
                    IncomeAccountId = incomeDetail.IncomeAccountId,
                    Description = incomeDetail.Description,
                    Quantity = incomeDetail.Quantity,
                    Price = incomeDetail.Price,
                    SalesTaxId = incomeDetail.SalesTaxId
                };

                incomeDetailService.Insert(detail);
            }
            //incomeDetailService.Save();


            //var actionExceptionHelper = new ActionResultHelper<TEntity>(typeof(TViewModel));
            //actionExceptionHelper.Method += Update;
            Update(entity);
            //var result = Validate(entity, _CleanUpControllerName(), "Edit");
            //if (!result.Passed)
            //    _EditReturnPartialViewOnError(viewModel);

            //var actionResultMessage = actionExceptionHelper.Process(entity, ModelState, CrudTransactionResultConstant.Update);
            //var actionResultMessage = actionExceptionHelper.Process(entity, ModelState, _setting.GetMessage(SystemMessageConstant.RecordUpdated));

            //return Json(actionResultMessage, JsonRequestBehavior.AllowGet);
            //return actionResultMessage.ActionStatus == ActionStatusResult.Failed
            //   ? _EditReturnPartialViewOnError(viewModel)
            //   : Json(actionResultMessage, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddNewRow(IncomeViewModel viewModel)
        {
            viewModel.IncomeDetails.Add(new IncomeDetailViewModel());
            return PartialView("_NewRowPartial", SetViewModelData(viewModel));
        }


        

    }
}