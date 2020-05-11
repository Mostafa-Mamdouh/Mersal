#region Using ...
using Framework.Common.Enums;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
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
    public class VendorReportsService : IVendorReportsService
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
        private readonly IVendorsRepository _vendorsRepository;
        private readonly ICurrencyRatesService _currencyRatesService;

        private readonly ITransactionsRepository _TransactionsRepository;
        private readonly IAccountChartsRepository _AccountChartsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrencysRepository _currencysRepository;
        private readonly IBanksRepository _banksRepository;
        private readonly IAccountChartsRepository _accountChartsRepository;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type TransactionsService.
        /// </summary>
        /// <param name="TransactionsRepository"></param>
        /// <param name="unitOfWork"></param>
        public VendorReportsService(
            IResourcesService resourcesService,
            //IBankMovementsRepository bankMovementsRepository,
            IPaymentMovmentsRepository paymentMovmentsRepository,
            IPurchaseInvoicesRepository purchaseInvoicesRepository,
            IPurchaseRebatesRepository purchaseRebatesRepository,
            IDonationsRepository donationsRepository,
             ICurrencysRepository currencysRepository,
            ISalesBillRepository salesBillRepository,
            ISalesRebatesRepository salesRebatesRepository,
            //IStoreMovementsRepository storeMovementsRepository,
            ICurrentUserService currentUserService,
            IInventoryMovementsRepository inventoryMovementsRepository,
            ISettingsService settingsService,
            IJournalsRepository JournalsRepository,
            IVendorsRepository vendorsRepository,
            ICurrencyRatesService currencyRatesService,
            ITransactionsRepository TransactionsRepository,
            IAccountChartsRepository AccountChartsRepository,
            ILanguageService languageService,
            IBanksRepository banksRepository,
             IAccountChartsRepository accountChartsRepository,
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
            this._vendorsRepository = vendorsRepository;
            this._currencyRatesService = currencyRatesService;
            this._accountChartsRepository = accountChartsRepository;

            this._TransactionsRepository = TransactionsRepository;
            this._AccountChartsRepository = AccountChartsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
            this._currencysRepository = currencysRepository;
            this._banksRepository = banksRepository;
        }
        #endregion

        #region Methods
        public IList<Transaction> VirtualPostPaymentMovement(long vendorId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
            {
                Query = (x => x.PaymentMovmentVendors.Count > 0 && x.PaymentMovmentVendors.Any(c => c.VendorId == vendorId) &&
                              x.ParentKeyPaymentMovmentId.HasValue == false &&
                              x.Date <= toDate.Value)
            };

            var sourceEntities = this._paymentMovmentsRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                var postingSetting = this._settingsService.GetPostingSetting();
                var financialSetting = this._settingsService.GetFinancialSetting();
                DateTime now = DateTime.Now;
                //var financialSetting = this._settingsService.GetFinancialSetting();
                var systemCurrency = this._settingsService.GetSystemCurrency();

                foreach (var source in sourceEntities)
                {
                    if (source.Date > toDate.Value) continue;

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
                        Description = journalDescriptionEn
,
                        Language = Language.English,
                        CreationDate = now,
                        Date = source.Date
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
                        DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForPaymentMovement, Language.Arabic].Value,
                        DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForPaymentMovement, Language.English].Value
                    };

                    if (source.SafeAccountChartId.HasValue)
                    {
                        transactionC.AccountChartId = source.SafeAccountChartId;
                        #region Record The Owner Of This Transaction
                        transactionC.ObjectType = ObjectType.Safe;
                        transactionC.ObjectId = source.SafeId;

                        #endregion
                    }
                    else if (source.ChequeToBankId.HasValue)
                    {
                        if (source.ToBankAccountChart == null) source.ToBankAccountChart = this._accountChartsRepository.Get(source.ToBankAccountChartId.Value);

                        var acc = source.ToBankAccountChart;
                        if (acc != null)
                            transactionC.AccountChartId = acc.Id;
                        else
                        {
                            if (postingSetting.AllowPostingAccountCurrencyMisMatch)
                            {
                                transactionC.AccountChartId = source.ToBankAccountChartId;
                            }
                            else
                            {
                                throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                            }
                        }

                        #region Record The Owner Of This Transaction
                        transactionC.ObjectType = ObjectType.Bank;
                        transactionC.ObjectId = source.BankId;
                        #endregion
                    }
                    else if (source.BankId.HasValue)
                    {
                        if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

                        if (source.Bank.BankAccountCharts.Count == 0)
                            throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                        //-transactionC.AccountChartId = source.Bank.AccountChartId;
                        var acc = source.Bank.BankAccountCharts
                           .FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

                        if (acc != null)
                            transactionC.AccountChartId = acc.AccountChartId;
                        else
                        {
                            if (postingSetting.AllowPostingAccountCurrencyMisMatch)
                            {
                                transactionC.AccountChartId = source.Bank.BankAccountCharts.FirstOrDefault().AccountChartId;
                            }
                            else
                            {
                                throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                            }
                        }

                        #region Record The Owner Of This Transaction
                        transactionC.ObjectType = ObjectType.Bank;
                        transactionC.ObjectId = source.BankId;
                        #endregion
                    }
                    transactionC.Amount = source.Amount;
                    journal.Transactions.Add(transactionC);


                    //if (source.InvoiceAmount.HasValue)
                    //{
                    //    var invoiceTransaction = new Transaction
                    //    {
                    //        IsCreditor = true,
                    //        Amount = latestCurrencyRate.NewAmount,
                    //        CreationDate = now,
                    //        DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForPaymentMovement, Language.Arabic].Value,
                    //        DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForPaymentMovement, Language.English].Value
                    //    };
                    //    invoiceTransaction.AccountChartId = financialSetting.VATAccount.Id;
                    //    invoiceTransaction.Amount = (decimal)source.DiscountAmount;
                    //    journal.Transactions.Add(invoiceTransaction);

                    //}



                    #endregion

                    #region الطرف المدين
                    // الطرف المدين

                    //if (source.PaymentMovmentNotificationDiscounts.Any())
                    //{
                    //    //transactionD.AccountChartId = source.AccountChartId;

                    //    //#region Record The Owner Of This Transaction
                    //    //transactionD.ObjectType = ObjectType.AccountChart;
                    //    //transactionD.ObjectId = source.AccountChartId;
                    //    //#endregion
                    //    //transactionD.Amount = (decimal)source.InvoiceAmount;
                    //    //journal.Transactions.Add(transactionD);
                    //}
                
                        var TransactionCount = 0;
                        //if (source.VendorId.HasValue)
                        //    TransactionCount += 1;
                        if (source.PaymentMovmentAccountCharts.Any())
                        {
                            foreach (var item in source.PaymentMovmentAccountCharts)
                            {
                                TransactionCount += 1;

                            }
                        }
                        if (source.PaymentMovementDonators.Any())
                        {
                            foreach (var item in source.PaymentMovementDonators)
                            {
                                TransactionCount += 1;

                            }
                        }

                        if (source.PaymentMovmentVendors.Any())
                        {
                            foreach (var item in source.PaymentMovmentVendors)
                            {
                                TransactionCount += 1;

                            }
                        }


                        if (source.PaymentMovmentAccountCharts.Any())
                        {
                            foreach (var item in source.PaymentMovmentAccountCharts)
                            {

                                var transactionD = new Transaction
                                {
                                    IsCreditor = false,
                                    Amount = latestCurrencyRate.NewAmount,
                                    CreationDate = now,
                                    DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForPaymentMovement, Language.Arabic].Value,
                                    DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForPaymentMovement, Language.English].Value
                                };


                                transactionD.AccountChartId = item.AccountChartId;
                                #region Record The Owner Of This Transaction
                                transactionD.ObjectType = ObjectType.AccountChart;
                                transactionD.ObjectId = item.AccountChartId;
                                #endregion
                                transactionD.Amount = source.Amount / TransactionCount;

                                journal.Transactions.Add(transactionD);

                            }

                        }
                        if (source.PaymentMovementDonators.Any())
                        {
                            foreach (var item in source.PaymentMovementDonators)
                            {

                                var transactionD = new Transaction
                                {
                                    IsCreditor = false,
                                    Amount = latestCurrencyRate.NewAmount,
                                    CreationDate = now,
                                    DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForPaymentMovement, Language.Arabic].Value,
                                    DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForPaymentMovement, Language.English].Value
                                };

                                transactionD.AccountChartId = financialSetting.DonationAccount.Id;

                                #region Record The Owner Of This Transaction
                                transactionD.ObjectType = ObjectType.Donator;
                                transactionD.ObjectId = item.DonatorId;
                                #endregion
                                transactionD.Amount = source.Amount / TransactionCount;

                                journal.Transactions.Add(transactionD);
                            }


                        }

                        if (source.PaymentMovmentVendors.Any())
                        {
                            foreach (var item in source.PaymentMovmentVendors)
                            {


                                var transactionD = new Transaction
                                {
                                    IsCreditor = false,
                                    Amount = latestCurrencyRate.NewAmount,
                                    CreationDate = now,
                                    DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForPaymentMovement, Language.Arabic].Value,
                                    DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForPaymentMovement, Language.English].Value
                                };


                                ConditionFilter<Vendor, long> vendorCondition = new ConditionFilter<Vendor, long>
                                {
                                    Query = (x => x.Id == item.VendorId)
                                };

                                var vendorAccountChateID = _vendorsRepository.Get(vendorCondition).FirstOrDefault().AccountChartId;
                                transactionD.AccountChartId = vendorAccountChateID;

                                #region Record The Owner Of This Transaction
                                transactionD.ObjectType = ObjectType.Donator;
                                transactionD.ObjectId = item.VendorId;
                                #endregion
                                transactionD.Amount = source.Amount / TransactionCount;

                                journal.Transactions.Add(transactionD);
                            }


                        }

                    



                    #endregion

                    list.AddRange(journal.Transactions);
                }
            }

            return list;
        }

        public IList<Transaction> VirtualPostPurchaseInvoice(long vendorId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
            {
                Query = (x => x.VendorId.HasValue && x.VendorId.Value == vendorId &&
                              x.Date <= toDate.Value)
            };
            var sourceEntities = this._purchaseInvoicesRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                DateTime now = DateTime.Now;
                var vendorSetting = this._settingsService.GetVendorSetting();

                foreach (var source in sourceEntities)
                {
                    if (source.Date > toDate.Value) continue;

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

                    if (source.Vendor == null) source.Vendor = this._vendorsRepository.Get(source.VendorId.Value);

                    transactionC_1.AccountChartId = source.Vendor.AccountChartId;
                    transactionC_1.AccountChart = source.Vendor.AccountChart;

                    #region Record The Owner Of This Transaction
                    transactionC_1.ObjectType = ObjectType.Vendor;
                    transactionC_1.ObjectId = source.VendorId;
                    #endregion

                    journal.Transactions.Add(transactionC_1);
                    #endregion                                                                              

                    list.AddRange(journal.Transactions);
                }
            }

            return list;
        }

        public IList<Transaction> VirtualPostPurchaseRebate(long vendorId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>
            {
                Query = (x => x.VendorId.HasValue && x.VendorId.Value == vendorId &&
                              x.Date <= toDate.Value)
            };
            var sourceEntities = this._purchaseRebatesRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                DateTime now = DateTime.Now;
                var vendorSetting = this._settingsService.GetVendorSetting();

                foreach (var source in sourceEntities)
                {
                    if (source.Date > toDate.Value) continue;

                    var journal = new Journal
                    {
                        Date = source.CreationDate,
                        MovementType = MovementType.PurchaseRebate,
                        ObjectId = source.Id,
                        CreationDate = now,
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

                    if (source.Vendor == null) source.Vendor = this._vendorsRepository.Get(source.VendorId.Value);

                    transactionD_1.AccountChartId = source.Vendor.AccountChartId;
                    transactionD_1.AccountChart = source.Vendor.AccountChart;

                    #region Record The Owner Of This Transaction
                    transactionD_1.ObjectType = ObjectType.Vendor;
                    transactionD_1.ObjectId = source.VendorId;
                    #endregion

                    journal.Transactions.Add(transactionD_1);
                    #endregion

                    list.AddRange(journal.Transactions);
                }
            }

            return list;
        }

        public IList<Transaction> VirtualPostReceiptsMovement(long vendorId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();
            List<Journal> journalList = new List<Journal>();

            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                Query = (x => x.DonationVendors.Count > 0 && x.DonationVendors.Any(c => c.VendorId == vendorId) &&
                              x.ParentKeyDonationId.HasValue == false &&
                              x.Date <= toDate.Value)
            };

            var sourceEntities = this._donationsRepository.Get(condition);

            if (sourceEntities != null && sourceEntities.Count() > 0)
            {
                DateTime now = DateTime.Now;
                var financialSetting = this._settingsService.GetFinancialSetting();
                var systemCurrency = this._settingsService.GetSystemCurrency();
                var postingSetting = this._settingsService.GetPostingSetting();

                foreach (var source in sourceEntities)
                {
                    if (source.Date > toDate.Value) continue;

                    var currencyCondition = new ConditionFilter<Currency, long>
                    {
                        Query = (x => x.Id == source.CurrencyId)
                    };
                    var entityCurrency = _currencysRepository.Get(currencyCondition).FirstOrDefault();

                    LatestCurrencyRate latestCurrencyRate = this._currencyRatesService
                        .GetLatestCurrencyRate(source.Amount, entityCurrency, systemCurrency);


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



                    #region الطرف المدين
                    // الطرف المدين

                    var transactionD = new Transaction
                    {
                        IsCreditor = false,
                        Amount = source.Amount,
                        CreationDate = now,
                        DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForReceiptsMovement, Language.Arabic].Value,
                        DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForReceiptsMovement, Language.English].Value
                    };

                    if (source.SafeAccountChartId.HasValue)
                    {
                        //if (source.SafeAccountChartId == null) source.Safe = this._safesRepository.Get(source.SafeId.Value);

                        transactionD.AccountChartId = source.SafeAccountChartId;

                        #region Record The Owner Of This Transaction
                        transactionD.ObjectType = ObjectType.Safe;
                        transactionD.ObjectId = source.SafeId;
                        #endregion
                    }
                    else if (source.ChequeToBankId.HasValue)
                    {
                        // اعداد استخدام شيكات تحت التحصيل مفعل
                        if (financialSetting.UseChecksUnderCollection == false)
                        {
                            if (source.ChequeToBank == null) source.ChequeToBank = this._banksRepository.Get(source.ChequeToBankId.Value);

                            //-transactionD.AccountChartId = source.Bank.AccountChartId;
                            var acc = source.ChequeToBank.BankAccountCharts
                                .FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

                            if (acc != null)
                                transactionD.AccountChartId = acc.AccountChartId;
                            else
                            {
                                if (postingSetting.AllowPostingAccountCurrencyMisMatch)
                                {
                                    transactionD.AccountChartId = source.ChequeToBank.BankAccountCharts.FirstOrDefault().AccountChartId;
                                }
                                else
                                {
                                    throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                                }
                            }

                            #region Record The Owner Of This Transaction
                            transactionD.ObjectType = ObjectType.Bank;
                            transactionD.ObjectId = source.BankId;
                            #endregion
                        }
                        // اعداد استخدام شيكات تحت التحصيل غير مفعل
                        else
                        {
                            if (source.Exchangeable)
                            {
                                if (source.ChequeToBank == null) source.ChequeToBank = this._banksRepository.Get(source.ChequeToBankId.Value);

                                //-transactionD.AccountChartId = source.Bank.AccountChartId;
                                var acc = source.ChequeToBank.BankAccountCharts
                                    .FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

                                if (acc != null)
                                    transactionD.AccountChartId = acc.AccountChartId;
                                else
                                {
                                    if (postingSetting.AllowPostingAccountCurrencyMisMatch)
                                    {
                                        transactionD.AccountChartId = source.ChequeToBank.BankAccountCharts.FirstOrDefault().AccountChartId;
                                    }
                                    else
                                    {
                                        throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                                    }
                                }

                                #region Record The Owner Of This Transaction
                                transactionD.ObjectType = ObjectType.Bank;
                                transactionD.ObjectId = source.BankId;
                                #endregion
                            }
                            else
                            {
                                transactionD.AccountChartId = financialSetting.ChecksUnderCollectionAccount.Id;

                                #region Record The Owner Of This Transaction
                                transactionD.ObjectType = ObjectType.AccountChart;
                                transactionD.ObjectId = transactionD.AccountChartId;
                                #endregion
                            }
                        }
                    }
                    else if (source.BankId.HasValue)
                    {
                        if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

                        //if (source.Bank.BankAccountCharts.Count == 0)
                        //    throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                        //-transactionD.AccountChartId = source.Bank.AccountChartId;
                        var acc = source.Bank.BankAccountCharts.FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId); //source.Bank.BankAccountCharts
                                                                                                                                     //.FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

                        if (acc != null)
                            transactionD.AccountChartId = acc.AccountChartId;
                        else
                        {
                            if (postingSetting.AllowPostingAccountCurrencyMisMatch)
                            {
                                transactionD.AccountChartId = source.Bank.BankAccountCharts.FirstOrDefault().AccountChartId;
                            }
                            else
                            {
                                throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                            }
                        }

                        #region Record The Owner Of This Transaction
                        transactionD.ObjectType = ObjectType.Bank;
                        transactionD.ObjectId = source.BankId;
                        #endregion
                    }

                    journal.Transactions.Add(transactionD);
                    #endregion

                    #region الطرف الدائن
                    // الطرف الدائن

                    var TransactionCount = 0;
                    if (source.DonationVendors.Count > 0)
                        TransactionCount += source.DonationVendors.Count;
                    if (source.DonationAccountCharts.Count > 0)
                        TransactionCount += source.DonationAccountCharts.Count;
                    if (source.DonationDonators.Count > 0)
                        TransactionCount += source.DonationAccountCharts.Count;



                    decimal amount = source.Amount / TransactionCount;

                    if (source.DonationVendors.Count > 0)
                    {

                        foreach (var vendor in source.DonationVendors)
                        {
                            var transactionVendorC = new Transaction
                            {
                                IsCreditor = true,
                                Amount = amount,
                                CreationDate = now,
                                DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForReceiptsMovement, Language.Arabic].Value,
                                DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForReceiptsMovement, Language.English].Value
                            };

                            if (vendor.Vendor == null) vendor.Vendor = this._vendorsRepository.Get(vendor.VendorId);

                            transactionVendorC.AccountChartId = vendor.Vendor.AccountChartId;

                            #region Record The Owner Of This Transaction
                            transactionVendorC.ObjectType = ObjectType.Vendor;
                            transactionVendorC.ObjectId = vendor.VendorId;
                            #endregion
                            journal.Transactions.Add(transactionVendorC);
                        }

                    }

                    if (source.DonationAccountCharts.Count > 0)
                    {

                        foreach (var accountChart in source.DonationAccountCharts)
                        {
                            var transactionC = new Transaction
                            {
                                IsCreditor = true,
                                Amount = source.Amount / TransactionCount,
                                CreationDate = now,
                                DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForReceiptsMovement, Language.Arabic].Value,
                                DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForReceiptsMovement, Language.English].Value
                            };

                            transactionC.AccountChartId = accountChart.AccountChartId;

                            #region Record The Owner Of This Transaction
                            transactionC.ObjectType = ObjectType.AccountChart;
                            transactionC.ObjectId = accountChart.AccountChartId;
                            #endregion
                            journal.Transactions.Add(transactionC);
                        }

                    }

                    if (source.DonationDonators.Count > 0)
                    {

                        foreach (var donator in source.DonationDonators)
                        {
                            var transactionDonatorC = new Transaction
                            {
                                IsCreditor = true,
                                Amount = amount,
                                CreationDate = now,
                                DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForReceiptsMovement, Language.Arabic].Value,
                                DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForReceiptsMovement, Language.English].Value
                            };

                            transactionDonatorC.AccountChartId = financialSetting.DonationAccount.Id;

                            #region Record The Owner Of This Transaction
                            transactionDonatorC.ObjectType = ObjectType.Donator;
                            transactionDonatorC.ObjectId = donator.DonatorId;
                            #endregion

                            journal.Transactions.Add(transactionDonatorC);
                        }

                    }

                    #endregion

                    list.AddRange(journal.Transactions);
                }
            }

            return list;
        }

        public IList<Transaction> VirtualPostSalesInvoice(long vendorId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            return list;
        }

        public IList<Transaction> VirtualPostSalesRebate(long vendorId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            return list;
        }

        public IList<Transaction> VirtualPostStoreMovement(long vendorId, DateTime? toDate, Language lang, long? userId)
        {
            List<Transaction> list = new List<Transaction>();

            return list;
        }



        public IList<VendorAccountReportViewModel> GetVendorAccountReport(long vendorId, DateTime? DateFrom, DateTime? DateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            DateTo = DateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;

            List<Transaction> source = new List<Transaction>();
            source.AddRange(this.VirtualPostPaymentMovement(vendorId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostPurchaseInvoice(vendorId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostPurchaseRebate(vendorId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostReceiptsMovement(vendorId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostSalesInvoice(vendorId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostSalesRebate(vendorId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostStoreMovement(vendorId, DateTo, lang, userId));


            List<VendorAccountReportViewModel> AccountsReport = new List<VendorAccountReportViewModel>();
            AccountsReport = GetVendorAccountReportBeforeDate(vendorId, DateFrom.Value, source).ToList();

            var entityCollection = source.FindAll(x => x.Journal.Date >= DateFrom);

            foreach (var item in entityCollection)
            {
                if (item.Amount < 1)
                    continue;
                else
                    AccountsReport.Add(mapToReportModel(item, lang));
            }
            return AccountsReport;
        }

        public IList<VendorAccountReportViewModel> GetVendorBalanceReport(long vendorId, DateTime? DateFrom, DateTime? DateTo)
        {
            //DateFrom = DateFrom.SetTimeToNow();
            DateTo = DateTo.SetTimeToMax();
            var lang = this._languageService.CurrentLanguage;
            var userId = this._currentUserService.CurrentUserId;

            List<Transaction> source = new List<Transaction>();
            source.AddRange(this.VirtualPostPaymentMovement(vendorId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostPurchaseInvoice(vendorId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostPurchaseRebate(vendorId, DateTo, lang, userId));
            source.AddRange(this.VirtualPostReceiptsMovement(vendorId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostSalesInvoice(vendorId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostSalesRebate(vendorId, DateTo, lang, userId));
            //source.AddRange(this.VirtualPostStoreMovement(vendorId, DateTo, lang, userId));


            List<VendorAccountReportViewModel> AccountsReport = new List<VendorAccountReportViewModel>();
            AccountsReport = GetVendorAccountReportBeforeDate(vendorId, DateFrom.Value, source).ToList();

            var entityCollection = source.FindAll(x => x.Journal.Date >= DateFrom);
            if (entityCollection.Any())
            {
                VendorAccountReportViewModel accountCreditor = new VendorAccountReportViewModel();
                VendorAccountReportViewModel accountDebtor = new VendorAccountReportViewModel();
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


        public IList<VendorAccountReportViewModel> GetVendorAccountReportBeforeDate(long vendorId, DateTime DateFrom, List<Transaction> source)
        {
            var lang = this._languageService.CurrentLanguage;
            //DateFrom = DateFrom.SetTimeToNow();

            List<VendorAccountReportViewModel> AccountsReport = new List<VendorAccountReportViewModel>();
            var currentVendor = this._vendorsRepository.Get(vendorId);
            //var currentAccount = currentVendor.AccountChart;

            #region OpeningBalance
            VendorAccountReportViewModel account = new VendorAccountReportViewModel();
            account.Name = currentVendor.ChildTranslatedVendors.FirstOrDefault(x => x.Language == lang).Name;
            account.Code = currentVendor.Code; //currentAccount.Code;
            account.FullCode = currentVendor.Code; //currentAccount.FullCode;
            account.CreationDate = currentVendor.CreationDate;
            account.Description = "";
            account.MovementType = this._resourcesService[ResourceKeyEnum.OpeningBalance, lang].Value;
            account.DocumentCode = currentVendor.Code;
            if (currentVendor.IsDebt != null)
            {
                if (currentVendor.IsDebt == true)
                {
                    account.CreditorValue = currentVendor.OpeningCredit;
                    account.DebtorValue = 0;
                }
                else
                {
                    account.CreditorValue = 0;
                    account.DebtorValue = currentVendor.OpeningCredit;
                }
            }
            else
            {
                account.CreditorValue = 0;
                account.DebtorValue = 0;
            }
            account.VendorName = currentVendor.ChildTranslatedVendors.FirstOrDefault(x => x.Language == lang).Name;
            AccountsReport.Add(account);


            //VendorAccountReportViewModel account = new VendorAccountReportViewModel();
            //account.Name = currentAccount.ChildTranslatedAccountCharts.First().Name;
            //account.Code = currentVendor.Code; //currentAccount.Code;
            //account.FullCode = currentVendor.Code; //currentAccount.FullCode;
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
            //        account.DebtorValue = currentAccount.OpeningCredit;
            //    }
            //}
            //else
            //{
            //    account.CreditorValue = 0;
            //    account.DebtorValue = 0;
            //}
            //account.VendorName = currentVendor.ChildTranslatedVendors.FirstOrDefault(x => x.Language == lang).Name;
            //AccountsReport.Add(account);
            #endregion

            var entityCollection = source.FindAll(x => x.Journal.Date < DateFrom);
            if (entityCollection.Any())
            {
                VendorAccountReportViewModel accountCreditor = new VendorAccountReportViewModel();
                VendorAccountReportViewModel accountDebtor = new VendorAccountReportViewModel();
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

        public VendorAccountReportViewModel mapToReportModel(Transaction item, Language lang)
        {
            VendorAccountReportViewModel account = new VendorAccountReportViewModel();
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
