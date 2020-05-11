#region Using ...
using Framework.Common.Enums;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Core.Models.ViewModels.Reports;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class AccountReportsService : Base.BaseService, IAccountReportsService
    {
        #region Data Members
        private readonly ICurrencyRatesService _currencyRatesService;
        private readonly ICurrencysRepository _currencysRepository;
        private readonly IResourcesService _resourcesService;
        //private readonly IBankMovementsRepository _bankMovementsRepository;
        private readonly IPaymentMovmentsRepository _paymentMovmentsRepository;
        private readonly IPurchaseInvoicesRepository _purchaseInvoicesRepository;
        private readonly IPurchaseRebatesRepository _purchaseRebatesRepository;
        private readonly IDonationsRepository _donationsRepository;
        private readonly ISalesBillRepository _salesBillRepository;
        private readonly ISalesRebatesRepository _salesRebatesRepository;
        // private readonly IStoreMovementsRepository _storeMovementsRepository;
        private readonly IInventoryMovementsRepository _inventoryMovementsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISettingsService _settingsService;
        private readonly IVendorsRepository _vendorsRepository;

        private readonly ITransactionsRepository _TransactionsRepository;
        private readonly IAccountChartsRepository _AccountChartsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionsService.
        /// </summary>
        /// <param name="TransactionsRepository"></param>
        /// <param name="unitOfWork"></param>
        public AccountReportsService(
            ICurrencyRatesService currencyRatesService,
            ICurrencysRepository currencysRepository,
            IResourcesService resourcesService,
            //IBankMovementsRepository bankMovementsRepository,
            IPaymentMovmentsRepository paymentMovmentsRepository,
            IPurchaseInvoicesRepository purchaseInvoicesRepository,
            IPurchaseRebatesRepository purchaseRebatesRepository,
            IDonationsRepository donationsRepository,
            ISalesBillRepository salesBillRepository,
            ISalesRebatesRepository salesRebatesRepository,
            //IStoreMovementsRepository storeMovementsRepository,
            ICurrentUserService currentUserService,
            IInventoryMovementsRepository inventoryMovementsRepository,
            ISettingsService settingsService,
            IJournalsRepository JournalsRepository,
            IVendorsRepository vendorsRepository,

            ITransactionsRepository TransactionsRepository,
            IAccountChartsRepository AccountChartsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._currencyRatesService = currencyRatesService;
            this._currencysRepository = currencysRepository;
            this._resourcesService = resourcesService;
            //this._bankMovementsRepository = bankMovementsRepository;
            this._paymentMovmentsRepository = paymentMovmentsRepository;
            this._purchaseInvoicesRepository = purchaseInvoicesRepository;
            this._purchaseRebatesRepository = purchaseRebatesRepository;
            this._donationsRepository = donationsRepository;
            this._salesBillRepository = salesBillRepository;
            this._salesRebatesRepository = salesRebatesRepository;
            //this._storeMovementsRepository = storeMovementsRepository;
            this._currentUserService = currentUserService;
            this._inventoryMovementsRepository = inventoryMovementsRepository;
            this._settingsService = settingsService;
            this._vendorsRepository = vendorsRepository;

            this._TransactionsRepository = TransactionsRepository;
            this._AccountChartsRepository = AccountChartsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public IList<AccountsReportViewModel> GetAccountsReport(long AccountChartId, long? currencyId, DateTime? DateFrom, DateTime? DateTo)
        {
            var lang = this._languageService.CurrentLanguage;
            long? accountCurrencyId = 0;
            CurrencyRateLightViewModel latestCurrencyRate = null;
            //DateFrom = DateFrom.SetTimeToNow();
            DateTo = DateTo.SetTimeToMax();

            if (currencyId.HasValue)
            {
                accountCurrencyId = this._AccountChartsRepository.Get(AccountChartId).CurrencyId;
                latestCurrencyRate = this._currencyRatesService.GetLatestCurrencyRate(accountCurrencyId, currencyId);
            }

            List<AccountsReportViewModel> AccountsReport = new List<AccountsReportViewModel>();
            ConditionFilter<Transaction, long> condition = new ConditionFilter<Transaction, long>();
            AccountsReport = GetAccReportBeforeDate(AccountChartId, currencyId, DateFrom.Value).ToList();

            if (DateFrom.HasValue && DateTo.HasValue)
            {
                condition.Query = x =>
                    x.Journal.PostingStatus == PostingStatus.Approved &&
                    x.CreationDate >= DateFrom &&
                    x.CreationDate <= DateTo &&
                    x.AccountChartId == AccountChartId;
            }
            else
            {
                condition.Query = x =>
                    x.Journal.PostingStatus == PostingStatus.Approved &&
                    x.AccountChartId == AccountChartId;
            }
            var entityCollection = this._TransactionsRepository.Get(condition).ToList();
            foreach (var item in entityCollection)
            {
                if (item.Amount < 1)
                    continue;
                else
                    AccountsReport.Add(MapToReportModel(item, lang, latestCurrencyRate));
            }

            if (AccountsReport != null && AccountsReport.Count > 0)
            {
                if (currencyId.HasValue && string.IsNullOrEmpty(AccountsReport[0].AccountCurrencyName))
                {
                    AccountsReport[0].AccountCurrencyName = this._currencysRepository.Get(accountCurrencyId.Value)?.ChildTranslatedCurrencys?.FirstOrDefault(x => x.Language == lang)?.Name;
                    AccountsReport[0].ExchangeCurrencyName = this._currencysRepository.Get(currencyId.Value)?.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang)?.Name;
                    if(latestCurrencyRate != null)
                    {
                        AccountsReport[0].PriceValue = $"{AccountsReport[0].AccountCurrencyName} = {latestCurrencyRate.Price} {AccountsReport[0].ExchangeCurrencyName}";
                    }
                }
            }

            return AccountsReport;
        }

        public IList<AccountsReportViewModel> GetAccountBalanceReport(long AccountChartId, long? currencyId, DateTime? DateFrom, DateTime? DateTo)
        {
            var lang = this._languageService.CurrentLanguage;
            long? accountCurrencyId = 0;
            CurrencyRateLightViewModel latestCurrencyRate = null;

            var accountChart = this._AccountChartsRepository.Get(AccountChartId);
            string accountChartCurrencyName = "";
            string currencyName = "";
            string priceValue = "";
            //DateFrom = DateFrom.SetTimeToNow();
            DateTo = DateTo.SetTimeToMax();

            if (currencyId.HasValue)
            {
                accountCurrencyId = this._AccountChartsRepository.Get(AccountChartId).CurrencyId;
                accountChartCurrencyName = this._currencysRepository.Get(accountCurrencyId.Value)?.ChildTranslatedCurrencys?.FirstOrDefault(x => x.Language == lang)?.Name;
                latestCurrencyRate = this._currencyRatesService.GetLatestCurrencyRate(accountCurrencyId, currencyId);
                currencyName = this._currencysRepository.Get(currencyId.Value)?.ChildTranslatedCurrencys?.FirstOrDefault(x => x.Language == lang)?.Name;
                if(latestCurrencyRate != null)
                {
                    priceValue = $"{accountChartCurrencyName} = {latestCurrencyRate.Price} {currencyName}";
                }
            }

            List<AccountsReportViewModel> AccountsReport = new List<AccountsReportViewModel>();
            ConditionFilter<Transaction, long> condition = new ConditionFilter<Transaction, long>();
            AccountsReport = GetAccReportBeforeDate(AccountChartId, currencyId, DateFrom.Value).ToList();

            if (DateFrom.HasValue && DateTo.HasValue)
            {
                condition.Query = x =>
                    x.Journal.PostingStatus == PostingStatus.Approved &&
                    x.CreationDate >= DateFrom &&
                    x.CreationDate <= DateTo &&
                    x.AccountChartId == AccountChartId;
            }
            else
            {
                condition.Query = x =>
                    x.Journal.PostingStatus == PostingStatus.Approved &&
                    x.AccountChartId == AccountChartId;
            }

            var entityCollection = this._TransactionsRepository.Get(condition).ToList();

            if (entityCollection.Any())
            {
                AccountsReportViewModel accountCreditor = new AccountsReportViewModel();
                AccountsReportViewModel accountDebtor = new AccountsReportViewModel();

                accountCreditor.CreationDate = DateFrom;
                accountCreditor.MovementType = this._resourcesService[ResourceKeyEnum.TotalCreditBalanceInPeriod, lang].Value;
                accountCreditor.OriginalCreditorValue = 0;
                accountCreditor.CreditorValue = 0;
                accountCreditor.OriginalDebtorValue = 0;
                accountCreditor.DebtorValue = 0;
                accountCreditor.AccountCurrencyName = accountChartCurrencyName;
                if (latestCurrencyRate != null)
                {
                    accountCreditor.ExchangeCurrencyName = currencyName;
                    accountCreditor.PriceValue = priceValue;
                }

                accountDebtor.CreationDate = DateFrom;
                accountDebtor.MovementType = this._resourcesService[ResourceKeyEnum.TotalDebtBalanceInPeriod, lang].Value;
                accountDebtor.OriginalDebtorValue = 0;
                accountDebtor.DebtorValue = 0;
                accountDebtor.OriginalCreditorValue = 0;
                accountDebtor.CreditorValue = 0;
                accountDebtor.AccountCurrencyName = accountChartCurrencyName;
                if (latestCurrencyRate != null)
                {
                    accountDebtor.ExchangeCurrencyName = currencyName;
                    accountDebtor.PriceValue = priceValue;
                }

                foreach (var item in entityCollection)
                {
                    if (item.Amount < 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (item.IsCreditor)
                        {
                            accountCreditor.OriginalCreditorValue += item.Amount;

                            if (latestCurrencyRate != null)
                            {
                                accountCreditor.CreditorValue += (item.Amount * latestCurrencyRate.Price);
                            }
                            else
                            {
                                accountCreditor.CreditorValue += item.Amount;
                            }
                        }
                        else
                        {
                            accountDebtor.OriginalDebtorValue += item.Amount;

                            if (latestCurrencyRate != null)
                            {
                                accountDebtor.DebtorValue += (item.Amount * latestCurrencyRate.Price);
                            }
                            else
                            {
                                accountDebtor.DebtorValue += item.Amount;
                            }
                        }
                    }
                }
                AccountsReport.Add(accountCreditor);
                AccountsReport.Add(accountDebtor);
            }

            //foreach (var item in entityCollection)
            //{
            //    if (item.Amount < 1)
            //        continue;
            //    else
            //        AccountsReport.Add(MapToReportModel(item, lang));
            //}
            return AccountsReport;
        }

        public IList<BalanceSheetReportViewModel> GetBalanceSheetReport(int level, DateTime? DateFrom, DateTime? DateTo)
        {
            var lang = this._languageService.CurrentLanguage;
            //DateFrom = DateFrom.SetTimeToNow();
            DateTo = DateTo.SetTimeToMax();

            List<BalanceSheetReportViewModel> list = new List<BalanceSheetReportViewModel>();
            var accountList = this._AccountChartsRepository.Get(null).Where(x => x.AccountLevel == level).ToList();

            foreach (var item in accountList)
            {
                var reportRow = new BalanceSheetReportViewModel
                {
                    Level = level,
                    Code = item.Code,
                    CreditorValue = 0,
                    DebtorValue = 0,
                    DocumentCode = item.Id.ToString(),
                    FullCode = item.FullCode,
                    Name = item.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name,
                    OpeningCredit = 0,
                    OpeningDebit = 0
                };

                reportRow = this.GetOpeningBalance(reportRow, item.Id, DateFrom, DateTo, item);

                reportRow.TotalCreditValue = reportRow.OpeningCredit + reportRow.CreditorValue;
                reportRow.TotalDebtValue = reportRow.OpeningDebit + reportRow.DebtorValue;

                list.Add(reportRow);
            }

            return list;
        }

        public BalanceSheetReportViewModel GetOpeningBalance(BalanceSheetReportViewModel source, long accountChartId, DateTime? dateFrom, DateTime? dateTo, AccountChart accountChart = null)
        {
            if (accountChart == null)
            {
                accountChart = this._AccountChartsRepository.Get(accountChartId);
            }

            //DateTime? dateBefore = dateFrom.Value.Subtract(new TimeSpan(1, 0, 0, 0));

            if (accountChart.IsDebt.HasValue &&
                accountChart.OpeningCredit.HasValue &&
                accountChart.CreationDate <= dateTo)
            {
                if (dateFrom.HasValue && accountChart.CreationDate < dateFrom)
                {
                    source.OpeningCredit += (accountChart.IsDebt.Value == false) ? accountChart.OpeningCredit : 0;
                    source.OpeningDebit += (accountChart.IsDebt.Value == true) ? accountChart.OpeningCredit : 0;
                }
                else
                {
                    source.CreditorValue += (accountChart.IsDebt.Value == false) ? accountChart.OpeningCredit : 0;
                    source.DebtorValue += (accountChart.IsDebt.Value == true) ? accountChart.OpeningCredit : 0;
                }
            }

            if (accountChart.AccountTypeId == (long)AccountTypeEnum.Sub)
            {
                var transCollection = this._TransactionsRepository.Get(null).Where(x =>
                    x.Journal.PostingStatus == PostingStatus.Approved &&
                    x.AccountChartId == accountChartId &&
                    x.CreationDate <= dateTo
                    //x.Journal.Date <= dateTo
                    );

                if (transCollection.Count() > 0)
                {
                    foreach (var trans in transCollection)
                    {
                        if (dateFrom.HasValue && trans.CreationDate < dateFrom)
                        {
                            if (trans.IsCreditor == true)
                            {
                                source.OpeningCredit += trans.Amount;
                            }
                            else
                            {
                                source.OpeningDebit += trans.Amount;
                            }
                        }
                        else
                        {
                            if (trans.IsCreditor == true)
                            {
                                source.CreditorValue += trans.Amount;
                            }
                            else
                            {
                                source.DebtorValue += trans.Amount;
                            }
                        }
                    }
                }
            }

            if (accountChart.ChildAccountCharts.Count > 0)
            {
                foreach (var item in accountChart.ChildAccountCharts)
                {
                    source = this.GetOpeningBalance(source, item.Id, dateFrom, dateTo);
                }
            }

            return source;
        }


        public IList<AccountsReportViewModel> GetAccReportBeforeDate(long AccountChartId, long? currencyId, DateTime DateFrom)
        {
            var lang = this._languageService.CurrentLanguage;
            long? accountCurrencyId = 0;
            CurrencyRateLightViewModel latestCurrencyRate = null;
            //DateFrom = DateFrom.SetTimeToNow();
            string currencyName = "";

            if (currencyId.HasValue)
            {
                accountCurrencyId = this._AccountChartsRepository.Get(AccountChartId).CurrencyId;
                latestCurrencyRate = this._currencyRatesService.GetLatestCurrencyRate(accountCurrencyId, currencyId);
                currencyName = this._currencysRepository.Get(currencyId.Value)?.ChildTranslatedCurrencys?.FirstOrDefault(x => x.Language == lang)?.Name;
            }

            List<AccountsReportViewModel> AccountsReport = new List<AccountsReportViewModel>();
            ConditionFilter<Transaction, long> condition = new ConditionFilter<Transaction, long>
            {
                Query = x =>
                    x.Journal.PostingStatus == PostingStatus.Approved &&
                    x.CreationDate < DateFrom &&
                    x.AccountChartId == AccountChartId
            };
            var CurrentAccount = this._AccountChartsRepository.Get(AccountChartId);

            //if (CurrentAccount.OpeningCredit.HasValue)
            //{
            AccountsReportViewModel account = new AccountsReportViewModel();
            account.Name = CurrentAccount.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name;
            account.Code = CurrentAccount.Code;
            account.FullCode = CurrentAccount.FullCode;
            account.CreationDate = CurrentAccount.CreationDate;
            account.Description = "";
            account.MovementType = this._resourcesService[ResourceKeyEnum.OpeningBalance, lang].Value;
            account.DocumentCode = CurrentAccount.Code;
            account.AccountCurrencyName = CurrentAccount?.Currency?.ChildTranslatedCurrencys?.FirstOrDefault(x => x.Language == lang)?.Name;
            if (latestCurrencyRate != null)
            {
                account.ExchangeCurrencyName = currencyName;
                account.PriceValue = $"{account.AccountCurrencyName} = {latestCurrencyRate.Price} {account.ExchangeCurrencyName}";
            }

            if (CurrentAccount.IsDebt != null)
            {
                if (CurrentAccount.IsDebt == true)
                {
                    account.OriginalCreditorValue = CurrentAccount.OpeningCredit;
                    account.CreditorValue = CurrentAccount.OpeningCredit;
                    account.OriginalDebtorValue = 0;
                    account.DebtorValue = 0;

                    if (latestCurrencyRate != null)
                    {
                        account.CreditorValue = CurrentAccount.OpeningCredit * latestCurrencyRate.Price;
                    }
                }
                else
                {
                    account.OriginalCreditorValue = 0;
                    account.CreditorValue = 0;
                    account.OriginalDebtorValue = CurrentAccount.OpeningCredit;
                    account.DebtorValue = CurrentAccount.OpeningCredit;

                    if (latestCurrencyRate != null)
                    {
                        account.DebtorValue = CurrentAccount.OpeningCredit * latestCurrencyRate.Price;
                    }
                }
            }
            else
            {
                account.OriginalCreditorValue = 0;
                account.CreditorValue = 0;
                account.OriginalDebtorValue = 0;
                account.DebtorValue = 0;
            }
            AccountsReport.Add(account);
            //}

            var entityCollection = this._TransactionsRepository.Get(condition).ToList();
            if (entityCollection.Any())
            {
                AccountsReportViewModel accountCreditor = new AccountsReportViewModel();
                AccountsReportViewModel accountDebtor = new AccountsReportViewModel();

                accountCreditor.CreationDate = DateFrom.AddDays(-1);
                accountCreditor.MovementType = this._resourcesService[ResourceKeyEnum.TotalCreditBalanceBeforePeriod, lang].Value;
                accountCreditor.OriginalCreditorValue = 0;
                accountCreditor.CreditorValue = 0;
                accountCreditor.OriginalDebtorValue = 0;
                accountCreditor.DebtorValue = 0;
                accountCreditor.AccountCurrencyName = CurrentAccount.Currency?.ChildTranslatedCurrencys?.FirstOrDefault(x => x.Language == lang)?.Name;
                if (latestCurrencyRate != null)
                {
                    accountCreditor.ExchangeCurrencyName = currencyName;
                    accountCreditor.PriceValue = $"{accountCreditor.AccountCurrencyName} = {latestCurrencyRate.Price} {accountCreditor.ExchangeCurrencyName}";
                }

                accountDebtor.CreationDate = DateFrom.AddDays(-1);
                accountDebtor.MovementType = this._resourcesService[ResourceKeyEnum.TotalDebtBalanceBeforePeriod, lang].Value;
                accountDebtor.OriginalDebtorValue = 0;
                accountDebtor.DebtorValue = 0;
                accountDebtor.OriginalCreditorValue = 0;
                accountDebtor.CreditorValue = 0;
                accountDebtor.AccountCurrencyName = CurrentAccount.Currency?.ChildTranslatedCurrencys?.FirstOrDefault(x => x.Language == lang)?.Name;
                if (latestCurrencyRate != null)
                {
                    accountDebtor.ExchangeCurrencyName = currencyName;
                    accountDebtor.PriceValue = $"{accountDebtor.AccountCurrencyName} = {latestCurrencyRate.Price} {accountDebtor.ExchangeCurrencyName}";
                }

                foreach (var item in entityCollection)
                {
                    if (item.Amount < 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (item.IsCreditor)
                        {
                            accountCreditor.OriginalCreditorValue += item.Amount;

                            if (latestCurrencyRate != null)
                            {
                                accountCreditor.CreditorValue += (item.Amount * latestCurrencyRate.Price);
                            }
                            else
                            {
                                accountCreditor.CreditorValue += item.Amount;
                            }
                        }
                        else
                        {
                            accountDebtor.OriginalDebtorValue += item.Amount;

                            if (latestCurrencyRate != null)
                            {
                                accountDebtor.DebtorValue += (item.Amount * latestCurrencyRate.Price);
                            }
                            else
                            {
                                accountDebtor.DebtorValue += item.Amount;
                            }
                        }
                    }
                }
                AccountsReport.Add(accountCreditor);
                AccountsReport.Add(accountDebtor);
            }

            //foreach (var item in entityCollection)
            //{
            //    if (item.Amount < 1)
            //        continue;
            //    else
            //        AccountsReport.Add(MapToReportModel(item));
            //}

            return AccountsReport;
        }

        public AccountsReportViewModel MapToReportModel(Transaction item, Language lang, CurrencyRateLightViewModel latestCurrencyRate = null)
        {
            AccountsReportViewModel account = new AccountsReportViewModel();

            account.Name = item.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name;
            account.Code = item.AccountChart.Code;
            account.FullCode = item.AccountChart.FullCode;
            account.CreationDate = item.CreationDate;
            account.Description = item.Journal.ChildTranslatedJournals.FirstOrDefault(x => x.Language == lang).Description;
            account.MovementType = this._resourcesService.GetMovementTypeName(item.Journal.MovementType, lang);
            //account.DocumentCode = item.Journal.ObjectId.ToString();
            account.DocumentCode = item.Id.ToString();

            if (latestCurrencyRate != null)
            {
                account.AccountCurrencyName = item.AccountChart.Currency?.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang)?.Name;
                account.ExchangeCurrencyName = this._currencysRepository.Get(latestCurrencyRate.ExchangeCurrencyId.Value)?.ChildTranslatedCurrencys?.FirstOrDefault(x => x.Language == lang)?.Name;
                account.PriceValue = $"{account.AccountCurrencyName} = {latestCurrencyRate.Price} {account.ExchangeCurrencyName}";
            }


            if (item.IsCreditor)
            {
                account.OriginalCreditorValue = item.Amount;
                account.CreditorValue = item.Amount;
                account.OriginalDebtorValue = 0;
                account.DebtorValue = 0;

                if (latestCurrencyRate != null)
                {
                    account.CreditorValue = item.Amount * latestCurrencyRate.Price;
                }
            }
            else
            {
                account.OriginalDebtorValue = item.Amount;
                account.DebtorValue = item.Amount;
                account.OriginalCreditorValue = 0;
                account.CreditorValue = 0;

                if (latestCurrencyRate != null)
                {
                    account.DebtorValue = item.Amount * latestCurrencyRate.Price;
                }
            }

            return account;
        }
        #endregion
    }
}
