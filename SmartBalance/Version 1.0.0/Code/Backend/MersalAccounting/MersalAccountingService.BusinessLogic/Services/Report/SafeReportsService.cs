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
using MersalAccountingService.Core.Models.ViewModels.Reports;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class SafeReportsService : ISafeReportsService
    {
        #region Data Members
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
        private readonly ISafesRepository _safesRepository;
        private readonly ICurrencyRatesService _currencyRatesService;

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
        public SafeReportsService(
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
            ISafesRepository safesRepository,
            ICurrencyRatesService currencyRatesService,

            ITransactionsRepository TransactionsRepository,
            IAccountChartsRepository AccountChartsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
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
            this._safesRepository = safesRepository;
            this._currencyRatesService = currencyRatesService;

            this._TransactionsRepository = TransactionsRepository;
            this._AccountChartsRepository = AccountChartsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public IList<Transaction> VirtualPostPaymentMovement(long safeId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
            {
                Query = (x => x.SafeId.HasValue && x.SafeId.Value == safeId &&
                              x.ParentKeyPaymentMovmentId.HasValue == false &&
                              x.Date <= toDate.Value)
            };

            var sourceEntities = this._paymentMovmentsRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                DateTime now = DateTime.Now;
                //var userId = this._currentUserService.CurrentUserId;
                //var financialSetting = this._settingsService.GetFinancialSetting();
                var systemCurrency = this._settingsService.GetSystemCurrency();

                foreach (var source in sourceEntities)
                {
                    if (source.Date > toDate.Value) continue;

                    //source.IsPosted = true;
                    //source.PostingDate = now;
                    //source.PostedByUserId = userId;

                    //this._paymentMovmentsRepository.Update(source);
                    LatestCurrencyRate latestCurrencyRate = this._currencyRatesService.GetLatestCurrencyRate(source.Amount, source.Currency, systemCurrency);

                    #region Set Journal Description
                    var ar = source.ChildTranslatedPaymentMovments.FirstOrDefault(x => x.Language == Language.Arabic);
                    var en = source.ChildTranslatedPaymentMovments.FirstOrDefault(x => x.Language == Language.English);

                    string journalDescriptionAr = this._resourcesService[ResourceKeyEnum.RelayFromPaymentMovementNo, Language.Arabic].Value + source.Code + latestCurrencyRate.AppendedDescriptionAr;
                    string journalDescriptionEn = this._resourcesService[ResourceKeyEnum.RelayFromPaymentMovementNo, Language.English].Value + source.Code + latestCurrencyRate.AppendedDescriptionEn;

                    if (ar?.Description != null) journalDescriptionAr = ar.Description + " - " + journalDescriptionAr;
                    if (en?.Description != null) journalDescriptionEn = en.Description + " - " + journalDescriptionEn;
                    #endregion

                    var journal = new Journal
                    {
                        Date = source.Date,
                        MovementType = MovementType.PaymentMovement,
                        ObjectId = source.Id,
                        CreationDate = now,
                    };
                    var journalAr = new Journal
                    {
                        Description = journalDescriptionAr,                
                        Language = Language.Arabic,
                        CreationDate = now,
                        Date = source.Date
                    };
                    var journalEn = new Journal
                    {
                        Description = journalDescriptionEn,
                        Language = Language.English,
                        CreationDate = now,
                        Date = source.Date
                    };

                    journal.ChildTranslatedJournals.Add(journalAr);
                    journal.ChildTranslatedJournals.Add(journalEn);

                    #region الطرف المدين
                    // الطرف المدين

                    var transactionD = new Transaction
                    {
                        IsCreditor = false,
                        Amount = latestCurrencyRate.NewAmount,
                        CreationDate = now,
                        DescriptionAR = journalAr.Description,
                        DescriptionEN = journalEn.Description,
                        //DescriptionAR = "معاملة طرف مدين لحركة مدفوعات",
                        //DescriptionEN = "Treating the debtor of a payment transaction",
                        Journal = journal
                    };

                    if (source.SafeId.HasValue)
                    {
                        if (source.Safe == null) source.Safe = this._safesRepository.Get(source.SafeId.Value);

                        transactionD.AccountChartId = source.Safe.SafeAccountCharts.FirstOrDefault().AccountChartId;
                        transactionD.AccountChart = source.Safe.SafeAccountCharts.FirstOrDefault().AccountChart;

                        #region Record The Owner Of This Transaction
                        transactionD.ObjectType = ObjectType.Safe;
                        transactionD.ObjectId = source.SafeId;
                        #endregion
                    }

                    journal.Transactions.Add(transactionD);
                    #endregion

                    list.AddRange(journal.Transactions);
                }
            }

            return list;
        }

        public IList<Transaction> VirtualPostPurchaseInvoice(long safeId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
            {
                Query = (x => x.SafeId.HasValue && x.SafeId.Value == safeId &&
                              x.Date <= toDate.Value)
            };
            var sourceEntities = this._purchaseInvoicesRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                DateTime now = DateTime.Now;
                //var userId = this._currentUserService.CurrentUserId;
               // var SafeSetting = this._settingsService.GetSafeSetting();

                foreach (var source in sourceEntities)
                {
                    if (source.Date > toDate.Value) continue;

                    //source.IsPosted = true;
                    //source.PostingDate = now;
                    //source.PostedByUserId = userId;

                    //this._purchaseInvoicesRepository.Update(source);

                    var journal = new Journal
                    {
                        Date = source.Date,
                        MovementType = MovementType.PurchaseInvoice,
                        ObjectId = source.Id,
                        CreationDate = now,
                    };
                    var journalAr = new Journal
                    {
                        Description = this._resourcesService[ResourceKeyEnum.RelayFromPurchaseInvoiceNo, Language.Arabic].Value + source.Id,
                        Language = Language.Arabic,
                        CreationDate = now,
                        Date = source.Date,
                    };
                    var journalEn = new Journal
                    {
                        Description = this._resourcesService[ResourceKeyEnum.RelayFromPurchaseInvoiceNo, Language.English].Value + source.Id,
                        Language = Language.English,
                        CreationDate = now,
                        Date = source.Date
                    };

                    journal.ChildTranslatedJournals.Add(journalAr);
                    journal.ChildTranslatedJournals.Add(journalEn);


                    #region الطرف الدائن  - صافى القيمة
                    // الطرف الدائن

                    var transactionC_1 = new Transaction
                    {
                        IsCreditor = true,
                        Amount = source.NetAmount,
                        CreationDate = now,
                        DescriptionAR = journalAr.Description,
                        DescriptionEN = journalEn.Description,
                        //DescriptionAR = "معاملة طرف دائن لفاتورة مشتريات - صافى القيمة",
                        //DescriptionEN = "Transaction of a crediting party for the purchase invoice - NetAmount",
                        Journal = journal
                    };

                    if (source.Safe == null) source.Safe = this._safesRepository.Get(source.SafeId.Value);

                    transactionC_1.AccountChartId = source.Safe.SafeAccountCharts.FirstOrDefault().AccountChartId;
                    transactionC_1.AccountChart = source.Safe.SafeAccountCharts.FirstOrDefault().AccountChart;

                    #region Record The Owner Of This Transaction
                    transactionC_1.ObjectType = ObjectType.Safe;
                    transactionC_1.ObjectId = source.SafeId;
                    #endregion

                    journal.Transactions.Add(transactionC_1);
                    #endregion                                                                              

                    list.AddRange(journal.Transactions);
                }
            }

            return list;
        }

        public IList<Transaction> VirtualPostPurchaseRebate(long safeId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>
            {
                Query = (x => x.SafeId.HasValue && x.SafeId.Value == safeId &&
                              x.Date <= toDate.Value)
            };
            var sourceEntities = this._purchaseRebatesRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                DateTime now = DateTime.Now;
                //var userId = this._currentUserService.CurrentUserId;
               // var SafeSetting = this._settingsService.GetSafeSetting();

                foreach (var source in sourceEntities)
                {
                    if (source.Date > toDate.Value) continue;

                    //source.IsPosted = true;
                    //source.PostingDate = now;
                    //source.PostedByUserId = userId;

                    this._purchaseRebatesRepository.Update(source);

                    var journal = new Journal
                    {
                        Date = source.CreationDate,
                        MovementType = MovementType.PurchaseRebate,
                        ObjectId = source.Id,
                        CreationDate = now
                    };
                    var journalAr = new Journal
                    {
                        Description = this._resourcesService[ResourceKeyEnum.RelayFromPurchaseRebateNo, Language.Arabic].Value + source.Id,
                        Language = Language.Arabic,
                        CreationDate = now,
                        Date = source.CreationDate
                    };
                    var journalEn = new Journal
                    {
                        Description = this._resourcesService[ResourceKeyEnum.RelayFromPurchaseRebateNo, Language.English].Value + source.Id,
                        Language = Language.English,
                        CreationDate = now,
                        Date = source.CreationDate,
                    };

                    journal.ChildTranslatedJournals.Add(journalAr);
                    journal.ChildTranslatedJournals.Add(journalEn);


                    #region الطرف المدين - صافى القيمة
                    // الطرف المدين

                    var transactionD_1 = new Transaction
                    {
                        IsCreditor = false,
                        Amount = source.NetAmount,
                        CreationDate = now,
                        DescriptionAR = journalAr.Description,
                        DescriptionEN = journalEn.Description,
                        //DescriptionAR = "معاملة طرف مدين لمرتد مشتريات - صافى القيمة",
                        //DescriptionEN = "Treating the debtor of a purchase rebate transaction - NetAmount",
                        Journal = journal
                    };

                    if (source.Safe == null) source.Safe = this._safesRepository.Get(source.SafeId.Value);

                    transactionD_1.AccountChartId = source.Safe.SafeAccountCharts.FirstOrDefault().AccountChartId;
                    transactionD_1.AccountChart = source.Safe.SafeAccountCharts.FirstOrDefault().AccountChart;

                    #region Record The Owner Of This Transaction
                    transactionD_1.ObjectType = ObjectType.Safe;
                    transactionD_1.ObjectId = source.SafeId;
                    #endregion

                    journal.Transactions.Add(transactionD_1);
                    #endregion

                    list.AddRange(journal.Transactions);
                }
            }

            return list;
        }

        public IList<Transaction> VirtualPostReceiptsMovement(long safeId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                Query = (x => x.SafeId.HasValue && x.SafeId.Value == safeId &&
                              x.ParentKeyDonationId.HasValue == false &&
                              x.Date <= toDate.Value)
            };

            var sourceEntities = this._donationsRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                DateTime now = DateTime.Now;
                //var userId = this._currentUserService.CurrentUserId;
                var financialSetting = this._settingsService.GetFinancialSetting();
                var systemCurrency = this._settingsService.GetSystemCurrency();

                foreach (var source in sourceEntities)
                {
                    if (source.Date > toDate.Value) continue;

                    //source.IsPosted = true;
                    //source.PostingDate = now;
                    //source.PostedByUserId = userId;

                    //this._donationsRepository.Update(source);
                    LatestCurrencyRate latestCurrencyRate = this._currencyRatesService.GetLatestCurrencyRate(source.Amount, source.Currency, systemCurrency);

                    #region Set Journal Description
                    var ar = source.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.Arabic);
                    var en = source.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.English);

                    string journalDescriptionAr = this._resourcesService[ResourceKeyEnum.RelayFromReceiptsMovementNo, Language.Arabic].Value + source.Code + latestCurrencyRate.AppendedDescriptionAr;
                    string journalDescriptionEn = this._resourcesService[ResourceKeyEnum.RelayFromReceiptsMovementNo, Language.English].Value + source.Code + latestCurrencyRate.AppendedDescriptionEn;

                    if (ar?.Description != null) journalDescriptionAr = ar.Description + " - " + journalDescriptionAr;
                    if (en?.Description != null) journalDescriptionEn = en.Description + " - " + journalDescriptionEn;
                    #endregion

                    var journal = new Journal
                    {
                        Date = source.Date,
                        MovementType = MovementType.ReceiptsMovement,
                        ObjectId = source.Id,
                        CreationDate = now
                    };
                    var journalAr = new Journal
                    {
                        Description = journalDescriptionAr,                   
                        Language = Language.Arabic,
                        CreationDate = now,
                        Date = source.Date,
                    };
                    var journalEn = new Journal
                    {
                        Description = journalDescriptionEn,
                        Language = Language.English,
                        CreationDate = now,
                        Date = source.Date,
                    };

                    journal.ChildTranslatedJournals.Add(journalAr);
                    journal.ChildTranslatedJournals.Add(journalEn);


                    #region الطرف الدائن
                    // الطرف الدائن

                    var transactionC = new Transaction
                    {
                        IsCreditor = true,
                        Amount = latestCurrencyRate.NewAmount,
                        CreationDate = now,
                        DescriptionAR = journalAr.Description,
                        DescriptionEN = journalEn.Description,
                        //DescriptionAR = "معاملة طرف دائن لحركة مقبوضات",
                        //DescriptionEN = "Transaction of a crediting party for the movement of receipts",
                        Journal = journal
                    };

                    if (source.SafeId.HasValue)
                    {
                        if (source.Safe == null) source.Safe = this._safesRepository.Get(source.SafeId.Value);

                        transactionC.AccountChartId = source.Safe.SafeAccountCharts.FirstOrDefault().AccountChartId;
                        transactionC.AccountChart = source.Safe.SafeAccountCharts.FirstOrDefault().AccountChart;

                        #region Record The Owner Of This Transaction
                        transactionC.ObjectType = ObjectType.Safe;
                        transactionC.ObjectId = source.SafeId;
                        #endregion
                    }

                    journal.Transactions.Add(transactionC);
                    #endregion                   

                    list.AddRange(journal.Transactions);
                }
            }

            return list;
        }

        public IList<Transaction> VirtualPostSalesInvoice(long safeId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            return list;
        }

        public IList<Transaction> VirtualPostSalesRebate(long safeId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            return list;
        }

        public IList<Transaction> VirtualPostStoreMovement(long safeId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            return list;
        }



        public IList<SafeReportViewModel> GetSafeReport(long SafeId, DateTime? DateFrom, DateTime? DateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            DateTo = DateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;

            List<Transaction> source = new List<Transaction>();
            source.AddRange(this.VirtualPostPaymentMovement(SafeId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostPurchaseInvoice(SafeId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostPurchaseRebate(SafeId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostReceiptsMovement(SafeId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostSalesInvoice(SafeId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostSalesRebate(SafeId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostStoreMovement(SafeId, DateTo, lang, userId));

            //DateTime dateBefore = DateFrom.Value.Subtract(new TimeSpan(1, 0, 0, 0, 0));
            List<SafeReportViewModel> AccountsReport = new List<SafeReportViewModel>();
            AccountsReport = GetSafeReportBeforeDate(SafeId, DateFrom.Value, source).ToList();

            var entityCollection = source.FindAll(x => x.Journal.Date > DateFrom);

            foreach (var item in entityCollection)
            {
                if (item.Amount < 1)
                    continue;
                else
                    AccountsReport.Add(mapToReportModel(item, lang));
            }
            return AccountsReport;
        }
        
        public IList<SafeReportViewModel> GetSafeBalanceReport(long SafeId, DateTime? DateFrom, DateTime? DateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            DateTo = DateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;

            List<Transaction> source = new List<Transaction>();
            source.AddRange(this.VirtualPostPaymentMovement(SafeId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostPurchaseInvoice(SafeId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostPurchaseRebate(SafeId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostReceiptsMovement(SafeId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostSalesInvoice(SafeId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostSalesRebate(SafeId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostStoreMovement(SafeId, DateTo, lang, userId));

            //DateTime dateBefore = DateFrom.Value.Subtract(new TimeSpan(1, 0, 0, 0, 0));
            List<SafeReportViewModel> AccountsReport = new List<SafeReportViewModel>();
            AccountsReport = GetSafeReportBeforeDate(SafeId, DateFrom.Value, source).ToList();

            var entityCollection = source.FindAll(x => x.Journal.Date > DateFrom);

            if (entityCollection.Any())
            {
                SafeReportViewModel accountCreditor = new SafeReportViewModel();
                SafeReportViewModel accountDebtor = new SafeReportViewModel();
                accountCreditor.CreationDate = DateFrom;
                accountCreditor.MovementType = this._resourcesService[ResourceKeyEnum.TotalCreditBalanceInPeriod, lang].Value;
                accountCreditor.CreditorValue = 0;
                accountCreditor.DebtorValue = 0;

                accountDebtor.CreationDate = DateFrom;
                accountDebtor.MovementType = this._resourcesService[ResourceKeyEnum.TotalDebtBalanceInPeriod, lang].Value;
                accountDebtor.DebtorValue = 0;
                accountDebtor.CreditorValue = 0;
                foreach (var item in entityCollection)
                {
                    if (item.Amount < 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (item.IsCreditor)
                            accountCreditor.CreditorValue += item.Amount;
                        else
                            accountDebtor.DebtorValue += item.Amount;
                    }
                }
                AccountsReport.Add(accountCreditor);
                AccountsReport.Add(accountDebtor);
            }
            return AccountsReport;
        }


        public IList<SafeReportViewModel> GetSafeReportBeforeDate(long SafeId, DateTime DateFrom, List<Transaction> source)
        {
            var lang = this._languageService.CurrentLanguage;
            //DateFrom = DateFrom.SetTimeToNow();

            List<SafeReportViewModel> AccountsReport = new List<SafeReportViewModel>();
            var currentSafe = this._safesRepository.Get(SafeId);
            //var currentAccount = currentSafe.AccountChart;

            #region OpeningBalance
            SafeReportViewModel account = new SafeReportViewModel();
            account.Name = currentSafe.ChildTranslatedSafes.FirstOrDefault(x => x.Language == lang).Name;
            account.Code = currentSafe.Code; //currentAccount.Code;
            account.FullCode = currentSafe.Code; //currentAccount.FullCode;
            account.CreationDate = currentSafe.CreationDate;
            account.Description = "";
            account.MovementType = this._resourcesService[ResourceKeyEnum.OpeningBalance, lang].Value;
            account.DocumentCode = currentSafe.Code;
            if (currentSafe.IsDebt != null)
            {
                if (currentSafe.IsDebt == true)
                {
                    account.CreditorValue = currentSafe.OpeningCredit;
                    account.DebtorValue = 0;
                }
                else
                {
                    account.CreditorValue = 0;
                    account.DebtorValue = currentSafe.OpeningCredit;
                }
            }
            else
            {
                account.CreditorValue = 0;
                account.DebtorValue = 0;
            }
            account.SafeName = currentSafe.ChildTranslatedSafes.FirstOrDefault(x => x.Language == lang).Name;
            AccountsReport.Add(account);


            //SafeReportViewModel account = new SafeReportViewModel();
            //account.Name = currentAccount.ChildTranslatedAccountCharts.First().Name;
            //account.Code = currentSafe.Code; //currentAccount.Code;
            //account.FullCode = currentSafe.Code; //currentAccount.FullCode;
            //account.CreationDate = currentAccount.CreationDate;
            //account.Description = "";
            //account.MovementType = this._resourcesService[ResourceKeyEnum.OpeningBalance, lang].Value;
            //account.DocumentCode = currentAccount.Code;
            //if (currentAccount.IsDebt != null)
            //{
            //    if (currentAccount.IsDebt == true)
            //    {
            //        account.CreditorValue = currentAccount.OpeningCredit;
            //        account.DebtorValue = 0;
            //    }
            //    else
            //    {
            //        account.CreditorValue = 0;
            //       account.DebtorValue = currentAccount.OpeningCredit;
            //    }
            //}
            //else
            //{
            //    account.CreditorValue = 0;
            //    account.DebtorValue = 0;
            //}
            //account.SafeName = currentSafe.Name;
            //AccountsReport.Add(account);
            #endregion

            var entityCollection = source.FindAll(x => x.Journal.Date <= DateFrom);
            if (entityCollection.Any())
            {
                SafeReportViewModel accountCreditor = new SafeReportViewModel();
                SafeReportViewModel accountDebtor = new SafeReportViewModel();
                accountCreditor.CreationDate = DateFrom.AddDays(-1);
                accountCreditor.MovementType = this._resourcesService[ResourceKeyEnum.TotalCreditBalanceBeforePeriod, lang].Value;
                accountCreditor.CreditorValue = 0;
                accountCreditor.DebtorValue = 0;

                accountDebtor.CreationDate = DateFrom.AddDays(-1);
                accountDebtor.MovementType = this._resourcesService[ResourceKeyEnum.TotalDebtBalanceBeforePeriod, lang].Value;
                accountDebtor.DebtorValue = 0;
                accountDebtor.CreditorValue = 0;
                foreach (var item in entityCollection)
                {
                    if (item.Amount < 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (item.IsCreditor)
                            accountCreditor.CreditorValue += item.Amount;
                        else
                            accountDebtor.DebtorValue += item.Amount;
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
            //        AccountsReport.Add(mapToReportModel(item, lang));
            //}
            return AccountsReport;
        }
        
        public SafeReportViewModel mapToReportModel(Transaction item, Language lang)
        {
            SafeReportViewModel account = new SafeReportViewModel();
            account.Name = item.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name;
            account.Code = item.AccountChart.Code;
            account.FullCode = item.AccountChart.FullCode;

            account.CreationDate = item.Journal.Date;
            //account.CreationDate = item.CreationDate;

            if (lang == Language.English)
                account.Description = item.DescriptionEN;
            else
                account.Description = item.DescriptionAR;

            account.MovementType = this._resourcesService.GetMovementTypeName(item.Journal.MovementType, lang);

            account.DocumentCode = item.Journal.ObjectId.ToString();
            //account.DocumentCode = item.Id.ToString();

            if (item.IsCreditor)
            {
                account.CreditorValue = item.Amount;
                account.DebtorValue = 0;
            }
            else
            {
                account.CreditorValue = 0;
                account.DebtorValue = item.Amount;
            }

            return account;
        }
        #endregion
    }
}
