using Reindawn.Domain.Models;

namespace Reindawn.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Reindawn.Repository.Context.ReindawnContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Reindawn.Repository.Context.ReindawnContext context)
        {


            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Accounts Payable" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Accounts Receivable" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Bank" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Cash" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Client Credit" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Cost of Goods Sold" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Credit Card" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Equity" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Expense" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Fixed Asset" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Income" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Inventory" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Long Term Liability" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Other Asset" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Other Current Asset" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Other Current Liability" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Pre-paid Expense" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Taxes and Remittances" });

            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Retained Earnings" });
            //context.AccountTypes.AddOrUpdate(p => p.Name, new AccountType { Name = "Gain/Loss on Exchange" });
            //context.SaveChanges();

            //#region asset
            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 1100, Name = "Accounts Receivable", Description = "Money owed to your company for goods or services you provided and have invoiced a customer",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Accounts Receivable").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 1020,
            //    Name = "Bank Account",
            //    Description = "Bank account",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Bank").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 1000,
            //    Name = "Cash",
            //    Description = "",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Cash").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 1300,
            //    Name = "Furniture & Equipment",
            //    Description = "Furniture and equipment that has a useful life of over one year.",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Fixed Asset").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 1200,
            //    Name = "Inventory",
            //    Description = "Inventory on hand",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Inventory").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 1400,
            //    Name = "Prepaid Expenses",
            //    Description = "Pre-paid Expense",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Accounts Payable").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 1010,
            //    Name = "Undeposited Funds",
            //    Description = "Funds (checks) which you have on hand but not yet deposited to your bank account",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Cash").Id
            //});
            //#endregion

            //#region liabilities
            ////liabilities
            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 2100,
            //    Name = "Accounts Payable",
            //    Description = "Money you owe to a vendor for goods or services provided and billed to your company",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Accounts Payable").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 2210,
            //    Name = "Corporate Taxes Payable",
            //    Description = "Income tax expenses at the end of the year",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Taxes and Remittances").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 2000,
            //    Name = "Credit Card Payable",
            //    Description = "Business transactions paid for by credit card",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Client Credit").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 2300,
            //    Name = "Deposits from Customers",
            //    Description = "Credits or deposits received from a customer in advance",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Client Credit").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 2200,
            //    Name = "Sales Tax Payable",
            //    Description = "Sales tax collected",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Taxes and Remittances").Id
            //});
            //#endregion

            //#region equity
            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 3010,
            //    Name = "Contributed Capital",
            //    Description = "Owner's contribution to the company",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Equity").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 3000,
            //    Name = "Retained Earnings",
            //    Description = "Owner's equity in the company",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Retained Earnings").Id
            //});
            //#endregion

            //#region income
            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 4200,
            //    Name = "Gain/Loss on Exchange",
            //    Description = "Gain or loss due to changes in currency exchange rates",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Gain/Loss on Exchange").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 4100,
            //    Name = "Interest Income",
            //    Description = "Income earned from interest paid to you",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Income").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 4900,
            //    Name = "Other Income",
            //    Description = "Any income which can not be attributed to one of the other income accounts",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Income").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 4000,
            //    Name = "Sales Income",
            //    Description = "Revenue from sales",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Income").Id
            //});
            //#endregion

            //#region expenses
            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5500,
            //    Name = "Advertising & Marketing Expense",
            //    Description = "Advertising and marketing expenses related to increasing sales",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5520,
            //    Name = "Bank Charges & Interest Expense",
            //    Description = "Fees and interest expenses charged by your bank associated with the accounts you hold",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5540,
            //    Name = "Contractor Expense",
            //    Description = "Expenses related to paying consultants and contractors",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5000,
            //    Name = "Cost of Goods Sold",
            //    Description = "Purchases made for the purpose of reselling",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Cost of Goods Sold").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5560,
            //    Name = "Depreciation Expense",
            //    Description = "The amount of an asset's cost, based on useful life, consumed during a period",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5580,
            //    Name = "Insurance Expense",
            //    Description = "The premium, or periodic payment, made on an insurance policy",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5600,
            //    Name = "Meals & Entertainment Expense",
            //    Description = "Meals and entertainment for the purpose of generating business (includes travel meals)",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5620,
            //    Name = "Office Expense",
            //    Description = "Basic supplies required for an office environment",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5900,
            //    Name = "Other Expense",
            //    Description = "Any expense which can not be attributed to one of the other expense accounts",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5800,
            //    Name = "Payroll Expense",
            //    Description = "All expenses related to wages & salaries",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5640,
            //    Name = "Professional Dues/Memberships/Licenses/Subscriptions Expense",
            //    Description = "Fees, licenses and dues associated with running a business or membership in a professional organization",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5660,
            //    Name = "Professional Services Expense",
            //    Description = "Legal, accounting and other fees paid for professional services",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5680,
            //    Name = "Rent Expense",
            //    Description = "Expense related to renting office space for the business",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5700,
            //    Name = "Repairs & Maintenance Expense",
            //    Description = "Incidental repairs and maintenance that do not add to the value or appreciably prolong the life of a fixed asset",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5740,
            //    Name = "Telecommunications/Internet Expense",
            //    Description = "Telephone, fax & internet expenses",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5720,
            //    Name = "Travel Expense",
            //    Description = "Costs such as flights and hotels incurred as a result of business travel",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5760,
            //    Name = "Utilities Expense",
            //    Description = "Electricity, water & other utilities",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});

            //context.Accounts.AddOrUpdate(p => p.Name, new Account
            //{
            //    No = 5780,
            //    Name = "Vehicle Expense",
            //    Description = "Fuel, parking, repairs & maintenance of vehicle(s)",
            //    AccountTypeId = context.AccountTypes.FirstOrDefault(o => o.Name == "Expense").Id
            //});
            //#endregion

        }
    }
}
