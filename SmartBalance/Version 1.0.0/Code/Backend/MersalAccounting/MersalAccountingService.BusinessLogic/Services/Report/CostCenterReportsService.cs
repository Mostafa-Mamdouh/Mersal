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
    public class CostCenterReportsService : ICostCenterReportsService
    {
		#region Data Members
		private readonly IResourcesService _resourcesService;
		private readonly IBankMovementsRepository _bankMovementsRepository;
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
		private readonly IBanksRepository _banksRepository;
		private readonly ICostCentersRepository _costCentersRepository;
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
		public CostCenterReportsService(
			IResourcesService resourcesService,
			IBankMovementsRepository bankMovementsRepository,
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
			IBanksRepository banksRepository,
			ICostCentersRepository costCentersRepository,
			ICurrencyRatesService currencyRatesService,

			ITransactionsRepository TransactionsRepository,
			IAccountChartsRepository AccountChartsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._resourcesService = resourcesService;
			this._bankMovementsRepository = bankMovementsRepository;
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
			this._banksRepository = banksRepository;
			this._costCentersRepository = costCentersRepository;
			this._currencyRatesService = currencyRatesService;

			this._TransactionsRepository = TransactionsRepository;
			this._AccountChartsRepository = AccountChartsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods

		public IList<Transaction> VirtualPostBankMovement(long costCenterId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			//ConditionFilter<BankMovement, long> condition = new ConditionFilter<BankMovement, long>
			//{
			//    Query = (x => x.BankId.HasValue && x.BankId.Value == bankId &&
			//                  x.ParentKeyBankMovementId.HasValue == false &&
			//                  x.Date <= toDate)
			//};
			//var sourceEntities = this._bankMovementsRepository.Get(condition);

			//if (sourceEntities != null && sourceEntities.Count() > 0)
			//{
			//    DateTime now = DateTime.Now;
			//    //var financialSetting = this._settingsService.GetFinancialSetting();

			//    foreach (var source in sourceEntities)
			//    {
			//        var journal = new Journal
			//        {
			//            Date = source.Date.Value,
			//            MovementType = MovementType.BankMovement,
			//            ObjectId = source.Id,
			//            CreationDate = now
			//        };
			//        var journalAr = new Journal
			//        {
			//            Description = source.ChildTranslatedBankMovements.FirstOrDefault(x => x.Language == Language.Arabic).Description,
			//            //Description = "مرحل من حركة بنوك رقم " + source.Id,
			//            Language = Language.Arabic,
			//            CreationDate = now,
			//            Date = source.Date.Value
			//        };
			//        var journalEn = new Journal
			//        {
			//            Description = source.ChildTranslatedBankMovements.FirstOrDefault(x => x.Language == Language.English).Description,
			//            //Description = "Relay from movement of bank No. " + source.Id,
			//            Language = Language.English,
			//            CreationDate = now,
			//            Date = source.Date.Value
			//        };

			//        journal.ChildTranslatedJournals.Add(journalAr);
			//        journal.ChildTranslatedJournals.Add(journalEn);


			//        #region الطرف الدائن
			//        // الطرف الدائن

			//        var transactionC = new Transaction
			//        {
			//            IsCreditor = true,
			//            Amount = source.Amount,
			//            CreationDate = now,
			//            DescriptionAR = journalAr.Description,
			//            DescriptionEN = journalEn.Description,
			//            //DescriptionAR = "معاملة طرف دائن لحركة بنوك",
			//            //DescriptionEN = "Transaction of a crediting party for the movement of bank",
			//            Journal = journal
			//        };

			//        if (source.JournalTypeId.Value == (byte)JournalTypeEnum.Withdrawal ||
			//            source.JournalTypeId.Value == (byte)JournalTypeEnum.BankingExpenses)
			//        {
			//            if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

			//            transactionC.AccountChartId = source.Bank.AccountChartId;

			//            #region Record The Owner Of This Transaction
			//            transactionC.ObjectType = ObjectType.Bank;
			//            transactionC.ObjectId = source.BankId;
			//            #endregion
			//        }
			//        else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.BankTransfers)
			//        {
			//            if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

			//            transactionC.AccountChartId = source.Bank.AccountChartId;

			//            #region Record The Owner Of This Transaction
			//            transactionC.ObjectType = ObjectType.Bank;
			//            transactionC.ObjectId = source.BankId;
			//            #endregion
			//        }

			//        journal.Transactions.Add(transactionC);
			//        #endregion

			//        #region الطرف المدين
			//        // الطرف المدين

			//        var transactionD = new Transaction
			//        {
			//            IsCreditor = false,
			//            Amount = source.Amount,
			//            CreationDate = now,
			//            DescriptionAR = journalAr.Description,
			//            DescriptionEN = journalEn.Description,
			//            //DescriptionAR = "معاملة طرف مدين لحركة بنوك",
			//            //DescriptionEN = "Treating the debtor of a bank transaction",
			//            Journal = journal
			//        };

			//        if (source.JournalTypeId.Value == (byte)JournalTypeEnum.Deposit)
			//        {
			//            if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

			//            transactionD.AccountChartId = source.Bank.AccountChartId;

			//            #region Record The Owner Of This Transaction
			//            transactionD.ObjectType = ObjectType.Bank;
			//            transactionD.ObjectId = source.BankId;
			//            #endregion
			//        }
			//        //else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.BankTransfers)
			//        //{
			//        //	if (source.ToBank == null) source.ToBank = this._banksRepository.Get(source.ToBankId.Value);

			//        //	transactionD.AccountChartId = source.ToBank.AccountChartId;

			//        //	#region Record The Owner Of This Transaction
			//        //	transactionD.ObjectType = ObjectType.Bank;
			//        //	transactionD.ObjectId = source.ToBankId;
			//        //	#endregion
			//        //}

			//        journal.Transactions.Add(transactionD);
			//        #endregion

			//        list.AddRange(journal.Transactions);
			//    }
			//}

			return list;
		}

		public IList<Transaction> VirtualPostPaymentMovement(long costCenterId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
			{
				//NavigationProperties = new List<string> { "PaymentMovmentCostCenters" },
				Query = (x => x.PaymentMovmentCostCenters.Any(c => c.CostCenterId == costCenterId) &&
							  x.ParentKeyPaymentMovmentId.HasValue == false &&
							  x.Date <= toDate)
			};
			var sourceEntities = this._paymentMovmentsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				//var financialSetting = this._settingsService.GetFinancialSetting();
				var systemCurrency = this._settingsService.GetSystemCurrency();

				foreach (var source in sourceEntities)
				{
					LatestCurrencyRate latestCurrencyRate = this._currencyRatesService
						.GetLatestCurrencyRate(source.PaymentMovmentCostCenters.FirstOrDefault(X => X.CostCenterId == costCenterId).Amount, source.Currency, systemCurrency);

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
						//Amount = source.PaymentMovmentCostCenters.FirstOrDefault(X => X.CostCenterId == costCenterId).Amount,
						CreationDate = now,
						DescriptionAR = journalAr.Description,
						DescriptionEN = journalEn.Description,
						//DescriptionAR = "معاملة طرف دائن لحركة مدفوعات",
						//DescriptionEN = "Transaction of a crediting party for the movement of payment",
						Journal = journal
					};

					//if (source.BankId.HasValue)
					//{
					//    if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

					//    transactionD.AccountChartId = source.Bank.AccountChartId;

					//    #region Record The Owner Of This Transaction
					//    transactionD.ObjectType = ObjectType.Bank;
					//    transactionD.ObjectId = source.BankId;
					//    #endregion
					//}

					journal.Transactions.Add(transactionD);
					#endregion

					list.AddRange(journal.Transactions);
				}
			}

			return list;
		}

		public IList<Transaction> VirtualPostPurchaseInvoice(long costCenterId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
			{
				//NavigationProperties= new List<string> { "PurchaseInvoiceCostCenters" },
				Query = (x => x.PurchaseInvoiceCostCenters.Count(c => c.CostCenterId == costCenterId) > 0 &&
							  //x.PurchaseInvoiceCostCenters.Any(c => c.CostCenterId == costCenterId) &&
							  x.Date <= toDate)
			};
			var sourceEntities = this._purchaseInvoicesRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var vendorSetting = this._settingsService.GetVendorSetting();

				foreach (var source in sourceEntities)
				{
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
						Date = source.Date
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


					#region الطرف المدين
					// الطرف المدين

					var transactionD = new Transaction
					{
						IsCreditor = false,
						Amount = source.PurchaseInvoiceCostCenters.FirstOrDefault(x => x.CostCenterId == costCenterId).Amount,
						CreationDate = now,
						DescriptionAR = journalAr.Description,
						DescriptionEN = journalEn.Description,
						//DescriptionAR = "معاملة طرف دائن لفاتورة مشتريات - صافى القيمة",
						//DescriptionEN = "Transaction of a crediting party for the purchase invoice - NetAmount",
						Journal = journal
					};

					//if (source.Vendor == null) source.Vendor = this._vendorsRepository.Get(source.VendorId.Value);

					//transactionD.AccountChartId = source.Vendor.AccountChartId;
					//transactionD.AccountChart = source.Vendor.AccountChart;

					//#region Record The Owner Of This Transaction
					//transactionD.ObjectType = ObjectType.Vendor;
					//transactionD.ObjectId = source.VendorId;
					//#endregion

					journal.Transactions.Add(transactionD);
					#endregion

					list.AddRange(journal.Transactions);
				}
			}

			return list;
		}

		public IList<Transaction> VirtualPostPurchaseRebate(long costCenterId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>
			{
				//NavigationProperties = new List<string> { "PurchaseRebateCostCenters" },
				Query = (x => x.PurchaseRebateCostCenters.Any(c => c.CostCenterId == costCenterId) &&
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


					#region الطرف الدائن
					// الطرف الدائن

					var transactionC = new Transaction
					{
						IsCreditor = true,
						Amount = source.PurchaseRebateCostCenters.FirstOrDefault(x => x.CostCenterId == costCenterId).Amount,
						CreationDate = now,
						DescriptionAR = journalAr.Description,
						DescriptionEN = journalEn.Description,
						//DescriptionAR = "معاملة طرف مدين لمرتد مشتريات - صافى القيمة",
						//DescriptionEN = "Treating the debtor of a purchase rebate transaction - NetAmount",
						Journal = journal
					};

					if (source.Vendor == null) source.Vendor = this._vendorsRepository.Get(source.VendorId.Value);

					//transactionD_1.AccountChartId = source.Vendor.AccountChartId;
					//transactionD_1.AccountChart = source.Vendor.AccountChart;

					//#region Record The Owner Of This Transaction
					//transactionD_1.ObjectType = ObjectType.Vendor;
					//transactionD_1.ObjectId = source.VendorId;
					//#endregion

					journal.Transactions.Add(transactionC);
					#endregion

					list.AddRange(journal.Transactions);
				}
			}

			return list;
		}

		public IList<Transaction> VirtualPostReceiptsMovement(long costCenterId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
			{
				//NavigationProperties = new List<string> { "DonationCostCenters" },
				Query = (x => x.DonationCostCenters.Any(c => c.CostCenterId == costCenterId) &&
							  x.ParentKeyDonationId.HasValue == false &&
							  x.Date <= toDate)
			};
			var sourceEntities = this._donationsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var financialSetting = this._settingsService.GetFinancialSetting();
				var systemCurrency = this._settingsService.GetSystemCurrency();

				foreach (var source in sourceEntities)
				{
					LatestCurrencyRate latestCurrencyRate = this._currencyRatesService
						.GetLatestCurrencyRate(source.DonationCostCenters.FirstOrDefault(x => x.CostCenterId == costCenterId).Amount, source.Currency, systemCurrency);

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


					#region الطرف الدائن
					// الطرف الدائن

					var transactionC = new Transaction
					{
						IsCreditor = true,
						Amount = latestCurrencyRate.NewAmount,
						//Amount = source.DonationCostCenters.FirstOrDefault(x => x.CostCenterId == costCenterId).Amount,
						CreationDate = now,
						DescriptionAR = journalAr.Description,
						DescriptionEN = journalEn.Description,
						//DescriptionAR = "معاملة طرف مدين لحركة مقبوضات",
						//DescriptionEN = "Treating the debtor of a receivable transaction",
						Journal = journal
					};

					//        if (source.BankId.HasValue)
					//        {
					//            // حالة اختيار طريقة الدفع شيك
					//            if (source.ChequeToBankId.HasValue)
					//            {
					//                // اعداد استخدام شيكات تحت التحصيل مفعل
					//                if (financialSetting.UseChecksUnderCollection == false)
					//                {
					//                    if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

					//                    transactionD.AccountChartId = source.Bank.AccountChartId;

					//                    #region Record The Owner Of This Transaction
					//                    transactionD.ObjectType = ObjectType.Bank;
					//                    transactionD.ObjectId = source.BankId;
					//                    #endregion
					//                }
					//                // اعداد استخدام شيكات تحت التحصيل غير مفعل
					//                else
					//                {
					//                    if (source.Exchangeable)
					//                    {
					//                        if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

					//                        transactionD.AccountChartId = source.Bank.AccountChartId;

					//                        #region Record The Owner Of This Transaction
					//                        transactionD.ObjectType = ObjectType.Bank;
					//                        transactionD.ObjectId = source.BankId;
					//                        #endregion
					//                    }
					//                }
					//            }
					//            else
					//            {
					//                if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

					//                transactionD.AccountChartId = source.Bank.AccountChartId;

					//                #region Record The Owner Of This Transaction
					//                transactionD.ObjectType = ObjectType.Bank;
					//                transactionD.ObjectId = source.BankId;
					//                #endregion
					//            }
					//        }

					journal.Transactions.Add(transactionC);
					#endregion

					list.AddRange(journal.Transactions);
				}
			}

			return list;
		}

		public IList<Transaction> VirtualPostSalesInvoice(long costCenterId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			return list;
		}

		public IList<Transaction> VirtualPostSalesRebate(long costCenterId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			return list;
		}

		public IList<Transaction> VirtualPostStoreMovement(long costCenterId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			return list;
		}




		public IList<CostCenterAccountReportViewModel> GetCostCenterAccountReport(long costCenterId, DateTime? DateFrom, DateTime? DateTo)
		{
			//DateFrom = DateFrom.SetTimeToNow();
			DateTo = DateTo.SetTimeToMax();
			var lang = this._languageService.CurrentLanguage;
			var userId = this._currentUserService.CurrentUserId;

			List<Transaction> source = new List<Transaction>();
			//source.AddRange(this.VirtualPostBankMovement(costCenterId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostPaymentMovement(costCenterId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostPurchaseInvoice(costCenterId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostPurchaseRebate(costCenterId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostReceiptsMovement(costCenterId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostSalesInvoice(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostSalesRebate(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostStoreMovement(bankId, DateTo, lang, userId));

			List<CostCenterAccountReportViewModel> AccountsReport = new List<CostCenterAccountReportViewModel>();
			AccountsReport = GetCostCenterAccountReportBeforeDate(costCenterId, DateFrom.Value, source).ToList();

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

		public IList<CostCenterAccountReportViewModel> GetCostCenterBalanceReport(long costCenterId, DateTime? DateFrom, DateTime? DateTo)
		{
			//DateFrom = DateFrom.SetTimeToNow();
			DateTo = DateTo.SetTimeToMax();
			var lang = this._languageService.CurrentLanguage;
			var userId = this._currentUserService.CurrentUserId;

			List<Transaction> source = new List<Transaction>();
			//source.AddRange(this.VirtualPostBankMovement(costCenterId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostPaymentMovement(costCenterId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostPurchaseInvoice(costCenterId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostPurchaseRebate(costCenterId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostReceiptsMovement(costCenterId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostSalesInvoice(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostSalesRebate(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostStoreMovement(bankId, DateTo, lang, userId));

			List<CostCenterAccountReportViewModel> AccountsReport = new List<CostCenterAccountReportViewModel>();
			AccountsReport = GetCostCenterAccountReportBeforeDate(costCenterId, DateFrom.Value, source).ToList();

			var entityCollection = source.FindAll(x => x.Journal.Date >= DateFrom);
			if (entityCollection.Any())
			{
				CostCenterAccountReportViewModel accountCreditor = new CostCenterAccountReportViewModel();
				CostCenterAccountReportViewModel accountDebtor = new CostCenterAccountReportViewModel();
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
			//foreach (var item in entityCollection)
			//{
			//    if (item.Amount < 1)
			//        continue;
			//    else
			//        AccountsReport.Add(mapToReportModel(item, lang));
			//}
			return AccountsReport;
		}



		public IList<CostCenterAccountReportViewModel> GetCostCenterAccountReportBeforeDate(long costCenterId, DateTime DateFrom, List<Transaction> source)
		{
			var lang = this._languageService.CurrentLanguage;
			//DateFrom = DateFrom.SetTimeToNow();

			List<CostCenterAccountReportViewModel> AccountsReport = new List<CostCenterAccountReportViewModel>();
			var currentCostCenter = this._costCentersRepository.Get(costCenterId);
			//var currentAccount = currentBank.AccountChart;

			#region OpeningBalance
			CostCenterAccountReportViewModel account = new CostCenterAccountReportViewModel();
			account.Name = currentCostCenter.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == lang).Name;
			account.Code = currentCostCenter.Code;
			account.FullCode = currentCostCenter.Code;
			account.CreationDate = currentCostCenter.CreationDate;
			account.Description = "";
			account.MovementType = this._resourcesService[ResourceKeyEnum.OpeningBalance, lang].Value;
			account.DocumentCode = currentCostCenter.Code;
			if (currentCostCenter.IsDebt != null)
			{
				if (currentCostCenter.IsDebt == true)
				{
					account.CreditorValue = currentCostCenter.OpeningCredit;
					account.DebtorValue = 0;
				}
				else
				{
					account.CreditorValue = 0;
					account.DebtorValue = currentCostCenter.OpeningCredit;
				}
			}
			else
			{
				account.CreditorValue = 0;
				account.DebtorValue = 0;
			}
			account.CostCenterName = currentCostCenter.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == lang).Name;
			AccountsReport.Add(account);


			//BankAccountReportViewModel account = new BankAccountReportViewModel();
			//account.Name = currentAccount.ChildTranslatedAccountCharts.First().Name;
			//account.Code = currentBank.Code; //currentAccount.Code;
			//account.FullCode = currentBank.Code; //currentAccount.FullCode;
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
			//account.BankName = currentBank.ChildTranslatedBanks.FirstOrDefault(x => x.Language == lang).Name;
			//AccountsReport.Add(account);
			#endregion


			//ConditionFilter<Transaction, long> condition = new ConditionFilter<Transaction, long>();
			//condition.Query = x => x.CreationDate < DateFrom && x.AccountChartId == bankId;

			var entityCollection = source.FindAll(x => x.Journal.Date < DateFrom);
			if (entityCollection.Any())
			{
				CostCenterAccountReportViewModel accountCreditor = new CostCenterAccountReportViewModel();
				CostCenterAccountReportViewModel accountDebtor = new CostCenterAccountReportViewModel();
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

		public CostCenterAccountReportViewModel mapToReportModel(Transaction item, Language lang)
		{
			CostCenterAccountReportViewModel account = new CostCenterAccountReportViewModel();
			if (item.AccountChart != null)
			{
				account.Name = item.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name;
				account.Code = item.AccountChart.Code;
				account.FullCode = item.AccountChart.FullCode;
			}

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
