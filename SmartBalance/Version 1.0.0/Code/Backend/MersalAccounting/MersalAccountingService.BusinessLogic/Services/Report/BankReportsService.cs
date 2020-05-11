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
    public class BankReportsService : IBankReportsService
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
		public BankReportsService(
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
			this._currencyRatesService = currencyRatesService;

			this._TransactionsRepository = TransactionsRepository;
			this._AccountChartsRepository = AccountChartsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods

		public IList<Transaction> VirtualPostBankMovement(long bankId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			ConditionFilter<BankMovement, long> condition = new ConditionFilter<BankMovement, long>
			{
				Query = (x => x.BankId.HasValue && x.BankId.Value == bankId &&
							  x.ParentKeyBankMovementId.HasValue == false &&
							  x.Date <= toDate)
			};
			var sourceEntities = this._bankMovementsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var systemCurrency = this._settingsService.GetSystemCurrency();
				var postingSetting = this._settingsService.GetPostingSetting();
				//var financialSetting = this._settingsService.GetFinancialSetting();

				foreach (var source in sourceEntities)
				{
					#region Set Journal Description
					var ar = source.ChildTranslatedBankMovements.FirstOrDefault(x => x.Language == Language.Arabic);
					var en = source.ChildTranslatedBankMovements.FirstOrDefault(x => x.Language == Language.English);

					string journalDescriptionAr = this._resourcesService[ResourceKeyEnum.RelayFromMovementOfBankNo, Language.Arabic].Value + source.Id;
					string journalDescriptionEn = this._resourcesService[ResourceKeyEnum.RelayFromMovementOfBankNo, Language.English].Value + source.Id;

					if (ar?.Description != null) journalDescriptionAr = ar.Description + " - " + journalDescriptionAr;
					if (en?.Description != null) journalDescriptionEn = en.Description + " - " + journalDescriptionEn;
					#endregion

					var journal = new Journal
					{
						Date = source.Date.Value,
						MovementType = MovementType.BankMovement,
						ObjectId = source.Id,
						CreationDate = now
					};
					var journalAr = new Journal
					{
						Description = journalDescriptionAr,
						Language = Language.Arabic,
						CreationDate = now,
						Date = source.Date.Value
					};
					var journalEn = new Journal
					{
						Description = journalDescriptionEn,
						Language = Language.English,
						CreationDate = now,
						Date = source.Date.Value
					};

					journal.ChildTranslatedJournals.Add(journalAr);
					journal.ChildTranslatedJournals.Add(journalEn);


                    #region الطرف الدائن
                    // الطرف الدائن

                    var transactionC = new Transaction
                    {
                        IsCreditor = true,
                        Amount = source.Amount,
                        CreationDate = now,
                        DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForBankMovement, Language.Arabic].Value,
                        DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForBankMovement, Language.English].Value
                    };

                    if (//source.JournalTypeId.Value == (byte)JournalTypeEnum.Withdrawal ||
                        source.JournalTypeId.Value == (byte)JournalTypeEnum.BankingExpenses)
                    {
                        if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

                        if (source.BankAccountChartId == null)
                            throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                        var acc = source.Bank.BankAccountCharts
                            .FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

                        if (acc != null)
                            transactionC.AccountChartId = acc.AccountChartId;
                        else
                        {
                            if (postingSetting.AllowPostingAccountCurrencyMisMatch)
                            {
                                transactionC.AccountChartId = source.BankAccountChartId;
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
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.Deposit)
                    {
                        transactionC.AccountChartId = long.Parse(_settingsService.GetFinancialSetting().TemporaryCovenantAccountNumber);
                        #region Record The Owner Of This Transaction
                        transactionC.ObjectType = ObjectType.AccountChart;
                        transactionC.CostCenterId = source.CostCenterId;
                        transactionC.ObjectId = long.Parse(_settingsService.GetFinancialSetting().TemporaryCovenantAccountNumber);
                        #endregion
                    }
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.BankTransfers)
                    {
                        if (source.ToBank == null) source.ToBank = this._banksRepository.Get(source.ToBankId.Value);

                        if (source.ToBankAccountChartId == null)
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
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.CapturePapers)
                    {
                        transactionC.AccountChartId = long.Parse(_settingsService.GetFinancialSetting().ChecksUnderReceiptPapersAccountNumber);
                        #region Record The Owner Of This Transaction
                        transactionC.ObjectType = ObjectType.AccountChart;
                        transactionC.ObjectId = long.Parse(_settingsService.GetFinancialSetting().ChecksUnderReceiptPapersAccountNumber);
                        #endregion
                    }
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.DirectDonations)
                    {
                        transactionC.AccountChartId = long.Parse(_settingsService.GetFinancialSetting().GeneralDonationsAccountNumber);
                        #region Record The Owner Of This Transaction
                        transactionC.ObjectType = ObjectType.AccountChart;
                        transactionC.ObjectId = long.Parse(_settingsService.GetFinancialSetting().GeneralDonationsAccountNumber);
                        #endregion
                    }
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.PaymentPapers)
                    {
                        if (source.BankAccountChartId != null)
                            transactionC.AccountChartId = source.BankAccountChartId;
                        else
                        {
                            throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                        }
                    }
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.RepatedPaymentPapers)
                    {
                        if (source.AccountChartId != null)
                            transactionC.AccountChartId = source.AccountChartId;
                        else
                        {
                            throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                        }
                    }

                    journal.Transactions.Add(transactionC);
                    #endregion

                    #region الطرف المدين
                    // الطرف المدين

                    var transactionD = new Transaction
                    {
                        IsCreditor = false,
                        Amount = source.Amount,
                        CreationDate = now,
                        DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForBankMovement, Language.Arabic].Value,
                        DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForBankMovement, Language.English].Value
                    };

                    //if (source.JournalTypeId.Value == (byte)JournalTypeEnum.Withdrawal)
                    //{
                    //    if (source.Safe == null) source.Safe = this._safesRepository.Get(source.SafeId.Value);

                    //    transactionD.AccountChartId = source.Safe.AccountChartId;

                    //    #region Record The Owner Of This Transaction
                    //    transactionD.ObjectType = ObjectType.Safe;
                    //    transactionD.ObjectId = source.SafeId;
                    //    #endregion
                    //}
                    //else 
                    if (source.JournalTypeId.Value == (byte)JournalTypeEnum.Deposit)
                    {
                        if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

                        if (source.BankAccountChartId == null)
                            throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                        //-transactionD.AccountChartId = source.Bank.AccountChartId;
                        var acc = source.Bank.BankAccountCharts
                            .FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

                        if (acc != null)
                            transactionD.AccountChartId = acc.AccountChartId;
                        else
                        {
                            if (postingSetting.AllowPostingAccountCurrencyMisMatch)
                            {
                                transactionD.AccountChartId = source.AccountChartId;
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
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.BankingExpenses)
                    {
                        transactionD.AccountChartId = long.Parse(_settingsService.GetFinancialSetting().BankingPaymentsAccountNumber);

                        #region Record The Owner Of This Transaction
                        transactionD.ObjectType = ObjectType.AccountChart;
                        transactionD.ObjectId = long.Parse(_settingsService.GetFinancialSetting().BankingPaymentsAccountNumber);
                        #endregion
                    }
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.BankTransfers)
                    {
                        if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

                        if (source.AccountChartId == null)
                            throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                        //-transactionD.AccountChartId = source.ToBank.AccountChartId;
                        var acc = source.Bank.BankAccountCharts
                            .FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

                        if (acc != null)
                            transactionD.AccountChartId = acc.AccountChartId;
                        else
                        {
                            if (postingSetting.AllowPostingAccountCurrencyMisMatch)
                            {
                                transactionD.AccountChartId = source.AccountChartId;
                            }
                            else
                            {
                                throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                            }
                        }

                        #region Record The Owner Of This Transaction
                        transactionD.ObjectType = ObjectType.Bank;
                        transactionD.ObjectId = source.ToBankId;
                        #endregion
                    }
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.CapturePapers)
                    {
                        if (source.BankAccountChartId == null)
                            throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                        transactionD.AccountChartId = source.BankAccountChartId;

                    }
                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.DirectDonations)
                    {
                        if (source.AccountChartId == null)
                            throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                        transactionD.AccountChartId = source.AccountChartId;
                    }

                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.PaymentPapers)
                    {
                        if (source.AccountChartId != null)
                            transactionD.AccountChartId = source.AccountChartId;
                        else
                        {
                            throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                        }
                    }

                    else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.RepatedPaymentPapers)
                    {
                        if (source.BankAccountChartId != null)
                            transactionD.AccountChartId = source.BankAccountChartId;
                        else
                        {
                            throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                        }
                    }

                    journal.Transactions.Add(transactionD);
                    #endregion

                    list.AddRange(journal.Transactions);
				}
			}

			return list;
		}

		public IList<Transaction> VirtualPostPaymentMovement(long bankId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
			{
				Query = (x => x.BankId.HasValue && x.BankId.Value == bankId &&
							  x.ParentKeyPaymentMovmentId.HasValue == false &&
							  x.Date <= toDate)
			};
			var sourceEntities = this._paymentMovmentsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var systemCurrency = this._settingsService.GetSystemCurrency();
				var postingSetting = this._settingsService.GetPostingSetting();
				//var financialSetting = this._settingsService.GetFinancialSetting();

				foreach (var source in sourceEntities)
				{
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


					#region الطرف الدائن
					// الطرف الدائن

					var transactionC = new Transaction
					{
						IsCreditor = true,
						Amount = latestCurrencyRate.NewAmount,
						CreationDate = now,
						DescriptionAR = journalAr.Description,
						DescriptionEN = journalEn.Description,
						//DescriptionAR = "معاملة طرف دائن لحركة مدفوعات",
						//DescriptionEN = "Transaction of a crediting party for the movement of payment",
						Journal = journal
					};

					if (source.BankId.HasValue)
					{
						if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

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

					journal.Transactions.Add(transactionC);
					#endregion

					list.AddRange(journal.Transactions);
				}
			}

			return list;
		}

		//public IList<Transaction> VirtualPostPurchaseInvoice(long bankId, DateTime? toDate, Language lang, long? userId)
		//{
		//	List<Transaction> list = new List<Transaction>();

		//	ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
		//	{
		//		Query = (x => x.VisaBankId.HasValue && x.VisaBankId.Value == bankId &&
		//					  x.Date <= toDate)
		//	};
		//	var sourceEntities = this._purchaseInvoicesRepository.Get(condition);

		//	if (sourceEntities != null && sourceEntities.Count() > 0)
		//	{
		//		DateTime now = DateTime.Now;
		//		var vendorSetting = this._settingsService.GetVendorSetting();

		//		foreach (var source in sourceEntities)
		//		{
		//			var journal = new Journal
		//			{
		//				Date = source.Date,
		//				MovementType = MovementType.PurchaseInvoice,
		//				ObjectId = source.Id,
		//				CreationDate = now,
		//			};
		//			var journalAr = new Journal
		//			{
		//				Description = "مرحل من فاتورة مشتريات رقم " + source.Id,
		//				Language = Language.Arabic,
		//				CreationDate = now,
		//				Date = source.Date
		//			};
		//			var journalEn = new Journal
		//			{
		//				Description = "Relay from purchase invoice No. " + source.Id,
		//				Language = Language.English,
		//				CreationDate = now,
		//				Date = source.Date
		//			};

		//			journal.ChildTranslatedJournals.Add(journalAr);
		//			journal.ChildTranslatedJournals.Add(journalEn);


		//			list.AddRange(journal.Transactions);
		//		}
		//	}

		//	return list;
		//}

		public IList<Transaction> VirtualPostReceiptsMovement(long bankId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
			{
				Query = (x => x.BankId.HasValue && x.BankId.Value == bankId &&
							  x.ParentKeyDonationId.HasValue == false &&
							  x.Date <= toDate)
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
						//DescriptionAR = "معاملة طرف مدين لحركة مقبوضات",
						//DescriptionEN = "Treating the debtor of a receivable transaction",
						Journal = journal
					};

					if (source.BankId.HasValue)
					{
						// حالة اختيار طريقة الدفع شيك
						if (source.ChequeToBankId.HasValue)
						{
							// اعداد استخدام شيكات تحت التحصيل مفعل
							if (financialSetting.UseChecksUnderCollection == false)
							{
								if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

								//-transactionD.AccountChartId = source.Bank.AccountChartId;
								var acc = source.Bank.BankAccountCharts
									.FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

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
							// اعداد استخدام شيكات تحت التحصيل غير مفعل
							else
							{
								if (source.Exchangeable)
								{
									if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

									//-transactionD.AccountChartId = source.Bank.AccountChartId;
									var acc = source.Bank.BankAccountCharts
										.FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

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
							}
						}
						else
						{
							if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

							//-transactionD.AccountChartId = source.Bank.AccountChartId;
							var acc = source.Bank.BankAccountCharts
								.FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

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
					}

					journal.Transactions.Add(transactionD);
					#endregion

					list.AddRange(journal.Transactions);
				}
			}

			return list;
		}

		public IList<Transaction> VirtualPostSalesInvoice(long bankId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			return list;
		}

		public IList<Transaction> VirtualPostSalesRebate(long bankId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			return list;
		}

		public IList<Transaction> VirtualPostStoreMovement(long bankId, DateTime? toDate, Language lang, long? userId)
		{
			List<Transaction> list = new List<Transaction>();

			return list;
		}




		public IList<BankAccountReportViewModel> GetBankAccountReport(long bankId, DateTime? DateFrom, DateTime? DateTo)
		{
			//DateFrom = DateFrom.SetTimeToNow();
			DateTo = DateTo.SetTimeToMax();
			var lang = this._languageService.CurrentLanguage;
			var userId = this._currentUserService.CurrentUserId;

			List<Transaction> source = new List<Transaction>();
			source.AddRange(this.VirtualPostBankMovement(bankId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostPaymentMovement(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostPurchaseInvoice(bankId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostReceiptsMovement(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostSalesInvoice(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostSalesRebate(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostStoreMovement(bankId, DateTo, lang, userId));

			List<BankAccountReportViewModel> AccountsReport = new List<BankAccountReportViewModel>();
			AccountsReport = GetBankAccountReportBeforeDate(bankId, DateFrom.Value, source).ToList();

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

		public IList<BankAccountReportViewModel> GetBankBalanceReport(long bankId, DateTime? DateFrom, DateTime? DateTo)
		{
			//DateFrom = DateFrom.SetTimeToNow();
			DateTo = DateTo.SetTimeToMax();
			var lang = this._languageService.CurrentLanguage;
			var userId = this._currentUserService.CurrentUserId;

			List<Transaction> source = new List<Transaction>();
			source.AddRange(this.VirtualPostBankMovement(bankId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostPaymentMovement(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostPurchaseInvoice(bankId, DateTo, lang, userId));
			source.AddRange(this.VirtualPostReceiptsMovement(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostSalesInvoice(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostSalesRebate(bankId, DateTo, lang, userId));
			//source.AddRange(this.VirtualPostStoreMovement(bankId, DateTo, lang, userId));

			List<BankAccountReportViewModel> AccountsReport = new List<BankAccountReportViewModel>();
			AccountsReport = GetBankAccountReportBeforeDate(bankId, DateFrom.Value, source).ToList();

			var entityCollection = source.FindAll(x => x.Journal.Date >= DateFrom);
			if (entityCollection.Any())
			{
				BankAccountReportViewModel accountCreditor = new BankAccountReportViewModel();
				BankAccountReportViewModel accountDebtor = new BankAccountReportViewModel();
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



		public IList<BankAccountReportViewModel> GetBankAccountReportBeforeDate(long bankId, DateTime DateFrom, List<Transaction> source)
		{
			var lang = this._languageService.CurrentLanguage;
			//DateFrom = DateFrom.SetTimeToNow();

			List<BankAccountReportViewModel> AccountsReport = new List<BankAccountReportViewModel>();
			var currentBank = this._banksRepository.Get(bankId);
			//var currentAccount = currentBank.AccountChart;

			#region OpeningBalance
			BankAccountReportViewModel account = new BankAccountReportViewModel();
			account.Name = currentBank.ChildTranslatedBanks.FirstOrDefault(x => x.Language == lang).Name;
			account.Code = currentBank.Code;
			account.FullCode = currentBank.Code;
			account.CreationDate = currentBank.CreationDate;
			account.Description = "";
			account.MovementType = this._resourcesService[ResourceKeyEnum.OpeningBalance, lang].Value;
			account.DocumentCode = currentBank.Code;
			if (currentBank.IsDebt != null)
			{
				if (currentBank.IsDebt == true)
				{
					account.CreditorValue = currentBank.OpeningCredit;
					account.DebtorValue = 0;
				}
				else
				{
					account.CreditorValue = 0;
					account.DebtorValue = currentBank.OpeningCredit;
				}
			}
			else
			{
				account.CreditorValue = 0;
				account.DebtorValue = 0;
			}
			account.BankName = currentBank.ChildTranslatedBanks.FirstOrDefault(x => x.Language == lang).Name;
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
				BankAccountReportViewModel accountCreditor = new BankAccountReportViewModel();
				BankAccountReportViewModel accountDebtor = new BankAccountReportViewModel();
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

		public BankAccountReportViewModel mapToReportModel(Transaction item, Language lang)
		{
			BankAccountReportViewModel account = new BankAccountReportViewModel();
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
