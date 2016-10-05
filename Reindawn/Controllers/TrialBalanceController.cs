using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reindawn.Domain.Constants;
using Reindawn.Domain.Models;
using Reindawn.Models;
using Reindawn.Repository;
using Reindawn.Service;

namespace Reindawn.Controllers
{
    public class TrialBalanceController : Controller
    {
        // GET: TrialBalance
        public ActionResult Index()
        {
            var unitOfWork = new UnitOfWork();
            var accountService = new AccountService(unitOfWork);
            var incomeService = new IncomeService(unitOfWork);
            var incomeDetailService = new IncomeDetailService(unitOfWork);

            var trialBalanceList = new List<TrialBalanceViewModel>();
            foreach (var income in incomeService.GetAll())
            {
                var payment = accountService.Find(income.PaymentAccountId);
                var incomeDetails = incomeDetailService.Filter(o => o.IncomeId == income.Id).ToList();
                var amount = incomeDetails.Sum(o => o.Price);

                trialBalanceList = CheckExistingAccount(trialBalanceList, amount, payment, true);

                foreach (var incomeDetail in incomeDetails)
                {
                    var incomeAccount = accountService.Find(incomeDetail.IncomeAccountId);

                    trialBalanceList = CheckExistingAccount(trialBalanceList, incomeDetail.Price, incomeAccount, false);
                }
            }

            return View(trialBalanceList.OrderBy(o=>o.AccountNo));
        }

        private List<TrialBalanceViewModel> CheckExistingAccount(
            List<TrialBalanceViewModel> trialBalanceList, 
            decimal amount, 
            Account account,
            bool debit
            )
        {
            var unitOfWork = new UnitOfWork();
            //var incomeDetailService = new IncomeDetailService(unitOfWork);
            //var incomeDetails = incomeDetailService.Filter(o => o.IncomeId == incomeId).ToList();
            //var debitCredit = incomeDetails.Sum(o => o.Price);

            var trialBalExist = trialBalanceList.Find(o => o.AccountId == account.Id);
            if (trialBalExist != null)
            {
                if (debit)
                {
                    
                    trialBalExist.Debit =
                        trialBalExist.Debit + amount;


                }
                else
                {
                    trialBalExist.Credit =
                        trialBalExist.Credit + amount;
                }
            }
            else
            {
                trialBalanceList.Add(
                    new TrialBalanceViewModel
                    {
                        AccountId = account.Id,
                        AccountNo = account.No,
                        AccountName = account.Name,
                        Debit = debit? amount : 0,
                        Credit =debit? 0 : amount
                    });
            }

            return trialBalanceList;
        }
    }
}