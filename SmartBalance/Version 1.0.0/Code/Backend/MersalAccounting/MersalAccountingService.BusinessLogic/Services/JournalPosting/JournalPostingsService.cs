#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	/// <summary>
	/// Provides JournalPosting service for 
	/// business functionality.
	/// </summary>
	public class JournalPostingsService : IJournalPostingsService
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
		private readonly IJournalsRepository _JournalsRepository;
		private readonly IVendorsRepository _vendorsRepository;
		private readonly ISafesRepository _safesRepository;
		private readonly IBanksRepository _banksRepository;
		private readonly ICurrencyRatesRepository _currencyRatesRepository;
		private readonly ICurrencysRepository _currencysRepository;
		private readonly ICurrencyRatesService _currencyRatesService;
		private readonly IInventorysRepository _inventorysRepository;
		private readonly IAccountChartsRepository _accountChartsRepository;
		private readonly IBrandsRepository _brandsRepository;
		private readonly IAssetsRepository _assetsRepository;
		private readonly IBankAccountChartRepository bankAccountChartRepository;
		private readonly ITestamentRepository _testamentRepository;
		private readonly ILiquidationRepository _liquidationRepository;

		private readonly IJournalPostingsRepository _JournalPostingsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type JournalPostingsService.
		/// </summary>
		/// <param name="bankMovementsRepository"></param>
		/// <param name="paymentMovmentsRepository"></param>
		/// <param name="purchaseInvoicesRepository"></param>
		/// <param name="purchaseRebatesRepository"></param>
		/// <param name="donationsRepository"></param>
		/// <param name="salesBillRepository"></param>
		/// <param name="salesRebatesRepository"></param>
		/// <param name="currentUserService"></param>
		/// <param name="inventoryMovementsRepository"></param>
		/// <param name="settingsService"></param>
		/// <param name="JournalsRepository"></param>
		/// <param name="JournalPostingsRepository"></param>
		/// <param name="languageService"></param>
		/// <param name="unitOfWork"></param>
		public JournalPostingsService(
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
			ISafesRepository safesRepository,
			IBanksRepository banksRepository,
			ICurrencyRatesRepository currencyRatesRepository,
			ICurrencysRepository currencysRepository,
			ICurrencyRatesService currencyRatesService,
			IInventorysRepository inventorysRepository,
			IAccountChartsRepository accountChartsRepository,
			IBrandsRepository brandsRepository,
			IAssetsRepository assetsRepository,
			IBankAccountChartRepository bankAccountChartRepository,
			ITestamentRepository testamentRepository,
			ILiquidationRepository liquidationRepository,

			IJournalPostingsRepository JournalPostingsRepository,
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
			this._JournalsRepository = JournalsRepository;
			this._vendorsRepository = vendorsRepository;
			this._safesRepository = safesRepository;
			this._banksRepository = banksRepository;
			this._currencyRatesRepository = currencyRatesRepository;
			this._currencysRepository = currencysRepository;
			this._currencyRatesService = currencyRatesService;
			this._inventorysRepository = inventorysRepository;
			this._accountChartsRepository = accountChartsRepository;
			this._brandsRepository = brandsRepository;
			this._assetsRepository = assetsRepository;
			this._testamentRepository = testamentRepository;
			this._liquidationRepository = liquidationRepository;

			this._JournalPostingsRepository = JournalPostingsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public JournalPostingViewModel PostJournal(JournalPostingViewModel model, long? id = 0)
		{
			var entity = model.ToEntity();
			entity.CreatedByUserId = this._currentUserService.CurrentUserId;

			List<Journal> data = new List<Journal>();

			if (entity.PostBankMovement)
			{
				var posted = this.PostBankMovement(model.ToDate.Value, model.IsAutomaticPosting, model.IsBulkPosting, id);
				entity.PostedBankMovementCount = posted.Count;
				data.AddRange(posted);
			}
			if (entity.PostPaymentMovement)
			{
				var posted = this.PostPaymentMovement(model.ToDate.Value, model.IsAutomaticPosting, model.IsBulkPosting, id);
				entity.PostedPaymentMovementCount = posted.Count;
				data.AddRange(posted);
			}
			if (entity.PostPurchaseInvoice)
			{
				var posted = this.PostPurchaseInvoice(model.ToDate.Value, model.IsAutomaticPosting, model.IsBulkPosting, id);
				entity.PostedPurchaseInvoiceCount = posted.Count;
				data.AddRange(posted);
			}
			if (entity.PostPurchaseRebate)
			{
				var posted = this.PostPurchaseRebate(model.ToDate.Value, model.IsAutomaticPosting, model.IsBulkPosting, id);
				entity.PostedPurchaseRebateCount = posted.Count;
				data.AddRange(posted);
			}
			if (entity.PostReceiptsMovement)
			{
				var posted = this.PostReceiptsMovement(model.ToDate.Value, model.IsAutomaticPosting, model.IsBulkPosting, id);
				entity.PostedReceiptsMovementCount = posted.Count;
				data.AddRange(posted);
			}
			if (entity.PostSalesInvoice)
			{
				var posted = this.PostSalesInvoice(model.ToDate.Value, model.IsAutomaticPosting, model.IsBulkPosting, id);
				entity.PostedSalesInvoiceCount = posted.Count;
				data.AddRange(posted);
			}
			if (entity.PostSalesRebate)
			{
				var posted = this.PostSalesRebate(model.ToDate.Value, model.IsAutomaticPosting, model.IsBulkPosting, id);
				entity.PostedSalesRebateCount = posted.Count;
				data.AddRange(posted);
			}
			if (entity.PostStoreMovement)
			{
				var posted = this.PostStoreMovement(model.ToDate.Value, model.IsAutomaticPosting, model.IsBulkPosting, id);
				entity.PostedStoreMovementCount = posted.Count;
				data.AddRange(posted);
			}

			entity = this._JournalPostingsRepository.Add(entity);
			this._unitOfWork.Commit();

			string latestCode = null;
			foreach (var item in data)
			{
				#region Generate New Code
				if (latestCode == null)
				{
					try
					{
						ConditionFilter<Journal, long> condition = new ConditionFilter<Journal, long>
						{
							Query = x =>
								x.ParentKeyJournalId == null &&
								string.IsNullOrEmpty(x.Code) == false &&
								x.Id < item.Id
								,
							Order = Order.Descending
						};

						var z = this._JournalsRepository.Get(condition);
						var lastEntity = z.FirstOrDefault();
						long newCode = 1;

						if (lastEntity != null)
						{
							try
							{
								newCode = long.Parse(lastEntity.Code) + 1;
							}
							catch
							{
								newCode = item.Id;
							}
						}
						item.Code = newCode.ToString();
					}
					catch
					{
						item.Code = item.Id.ToString();
					}
				}
				else
				{
					long newGeneratedCode = long.Parse(latestCode) + 1;
					//latestCode = newGeneratedCode.ToString();
					item.Code = latestCode = newGeneratedCode.ToString();
				}
				this._JournalsRepository.Update(item);


				latestCode = item.Code;

				//this._unitOfWork.Commit();
				#endregion
			}

			if (data.Count > 0)
			{
				this._unitOfWork.Commit();
			}

			var result = entity.ToModel();

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="toDate"></param>
		/// <param name="IsAutomaticPosting"></param>
		/// <param name="IsBulkPosting"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList<Journal> PostBankMovement(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<BankMovement, long> condition = new ConditionFilter<BankMovement, long>
			{
				Query = (x => x.IsPosted == false &&
							  x.ParentKeyBankMovementId.HasValue == false &&
							  x.Date <= toDate)
			};
			if (id.HasValue && id > 0)
			{
				condition = new ConditionFilter<BankMovement, long>
				{
					Query = (x => x.IsPosted == false &&
								  x.ParentKeyBankMovementId.HasValue == false &&
								  x.Id == id.Value)
				};
			}
			var sourceEntities = this._bankMovementsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var systemCurrency = this._settingsService.GetSystemCurrency();
				var postingSetting = this._settingsService.GetPostingSetting();
				//var financialSetting = this._settingsService.GetFinancialSetting();

				foreach (var source in sourceEntities)
				{
					if (postInMemory == false)
					{
						source.IsPosted = true;
						source.PostingDate = now;
						source.PostedByUserId = userId;

						this._bankMovementsRepository.Update(source);
					}

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
						Date = now,
						MovementType = MovementType.BankMovement,
						ObjectId = source.Id,
						CreationDate = now,
						IsAutomaticPosting = IsAutomaticPosting,
						IsBulkPosting = IsBulkPosting
					};
					var journalAr = new Journal
					{
						Description = journalDescriptionAr,
						Language = Language.Arabic,
						CreationDate = now,
						Date = now
					};
					var journalEn = new Journal
					{
						Description = journalDescriptionEn,
						Language = Language.English,
						CreationDate = now,
						Date = now
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
						var accountchartid = _settingsService.GetFinancialSetting().BankingPaymentsAccountNumber;
						if (accountchartid != null)
						{
							transactionD.AccountChartId = long.Parse(accountchartid);
						}
						else
						{
							throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);
						}

						#region Record The Owner Of This Transaction
						transactionD.ObjectType = ObjectType.AccountChart;
						transactionD.ObjectId = long.Parse(_settingsService.GetFinancialSetting().BankingPaymentsAccountNumber);
						#endregion
					}
					else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.BankTransfers)
					{
						if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

						if (source.BankAccountChartId == null)
							throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);
						else
							transactionD.AccountChartId = source.BankAccountChartId;

						//-transactionD.AccountChartId = source.ToBank.AccountChartId;




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

						var accountchartid = _settingsService.GetFinancialSetting().TemporaryCovenantAccountNumber;
						if (accountchartid != null)
						{
							transactionC.AccountChartId = long.Parse(accountchartid);
						}
						else
						{
							throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);
						}
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
						var accountchartid = _settingsService.GetFinancialSetting().ChecksUnderReceiptPapersAccountNumber;
						if (accountchartid != null)
						{
							transactionC.AccountChartId = long.Parse(accountchartid);
						}
						else
						{
							throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);
						}
						#region Record The Owner Of This Transaction
						transactionC.ObjectType = ObjectType.AccountChart;
						transactionC.ObjectId = long.Parse(_settingsService.GetFinancialSetting().ChecksUnderReceiptPapersAccountNumber);
						#endregion
					}
					else if (source.JournalTypeId.Value == (byte)JournalTypeEnum.DirectDonations)
					{

						var accountchartid = _settingsService.GetFinancialSetting().GeneralDonationsAccountNumber;
						if (accountchartid != null)
						{
							transactionC.AccountChartId = long.Parse(accountchartid);
						}
						else
						{
							throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);
						}
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

					list.Add(journal);
					if (postInMemory == false)
					{
						this._JournalsRepository.Add(journal);
					}
				}
			}

			return list;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="toDate"></param>
		/// <param name="IsAutomaticPosting"></param>
		/// <param name="IsBulkPosting"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList<Journal> PostPaymentMovement(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
			{
				Query = (x => x.IsPosted == false &&
							  x.ParentKeyPaymentMovmentId.HasValue == false &&
							  x.Date <= toDate)
			};
			if (id.HasValue && id > 0)
			{
				condition = new ConditionFilter<PaymentMovment, long>
				{
					Query = (x => x.IsPosted == false &&
								  x.ParentKeyPaymentMovmentId.HasValue == false &&
								  x.Id == id.Value)
				};
			}
			var sourceEntities = this._paymentMovmentsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var systemCurrency = this._settingsService.GetSystemCurrency();
				var postingSetting = this._settingsService.GetPostingSetting();
				var financialSetting = this._settingsService.GetFinancialSetting();

				foreach (var source in sourceEntities)
				{
					if (postInMemory == false)
					{
						source.IsPosted = true;
						source.PostingDate = now;
						source.PostedByUserId = userId;

						this._paymentMovmentsRepository.Update(source);
					}
					var currencyCondition = new ConditionFilter<Currency, long>
					{
						Query = (x => x.Id == source.CurrencyId)
					};
					var entityCurrency = _currencysRepository.Get(currencyCondition).FirstOrDefault();

					LatestCurrencyRate latestCurrencyRate = this._currencyRatesService.GetLatestCurrencyRate(source.Amount, entityCurrency, systemCurrency);

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
						Date = now,
						MovementType = MovementType.PaymentMovement,
						ObjectId = source.Id,
						CreationDate = now,
						IsAutomaticPosting = IsAutomaticPosting,
						IsBulkPosting = IsBulkPosting
					};
					var journalAr = new Journal
					{
						Description = journalDescriptionAr,
						Language = Language.Arabic,
						CreationDate = now,
						Date = now
					};
					var journalEn = new Journal
					{
						Description = journalDescriptionEn,
						Language = Language.English,
						CreationDate = now,
						Date = now
					};

					journal.ChildTranslatedJournals.Add(journalAr);
					journal.ChildTranslatedJournals.Add(journalEn);

					if (string.IsNullOrEmpty(source.LiquidationNumber))
					{
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
					}

					#region الطرف المدين
					// الطرف المدين

                    //if (source.InvoiceAmount.HasValue)
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


					list.Add(journal);
					if (postInMemory == false)
					{
						this._JournalsRepository.Add(journal);
					}
				}
			}

			return list;
		}

		public IList<Journal> PostTestament(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<Testament, long> condition = new ConditionFilter<Testament, long>
			{
				Query = (x => x.IsPosted == false &&
							  x.Date <= toDate)
			};
			if (id.HasValue && id > 0)
			{
				condition = new ConditionFilter<Testament, long>
				{
					Query = (x => x.IsPosted == false &&
								  x.Id == id.Value)
				};
			}
			var sourceEntities = this._testamentRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var systemCurrency = this._settingsService.GetSystemCurrency();
				var postingSetting = this._settingsService.GetPostingSetting();
				var financialSetting = this._settingsService.GetFinancialSetting();
				var testamentAndAdvancesSetting = this._settingsService.GetTestamentAndAdvancesSetting();

				foreach (var source in sourceEntities)
				{
					if (postInMemory == false)
					{
						source.IsPosted = true;
						source.PostingDate = now;
						source.PostedByUserId = userId;

						this._testamentRepository.Update(source);
					}

					//LatestCurrencyRate latestCurrencyRate = this._currencyRatesService.GetLatestCurrencyRate(source.TotalValue.Value, systemCurrency.Currency, systemCurrency);

					#region Set Journal Description
					var ar = source.ChildTranslatedCustodies.FirstOrDefault(x => x.Language == Language.Arabic);
					var en = source.ChildTranslatedCustodies.FirstOrDefault(x => x.Language == Language.English);

					string journalDescriptionAr = ar.Description;// = this._resourcesService[ResourceKeyEnum.RelayFromPaymentMovementNo, Language.Arabic].Value/* + latestCurrencyRate.AppendedDescriptionAr*/;
					string journalDescriptionEn = en.Description;// = this._resourcesService[ResourceKeyEnum.RelayFromPaymentMovementNo, Language.English].Value /*+ latestCurrencyRate.AppendedDescriptionEn*/;

					if (ar?.Description != null) journalDescriptionAr = ar.Description;
					if (en?.Description != null) journalDescriptionEn = en.Description;
					#endregion

					var journal = new Journal
					{
						Date = now,
						MovementType = MovementType.Testament,
						ObjectId = source.Id,
						CreationDate = now,
						IsAutomaticPosting = IsAutomaticPosting,
						IsBulkPosting = IsBulkPosting
					};
					var journalAr = new Journal
					{
						Description = journalDescriptionAr,
						Language = Language.Arabic,
						CreationDate = now,
						Date = now
					};
					var journalEn = new Journal
					{
						Description = journalDescriptionEn,
						Language = Language.English,
						CreationDate = now,
						Date = now
					};

					journal.ChildTranslatedJournals.Add(journalAr);
					journal.ChildTranslatedJournals.Add(journalEn);

					#region الطرف المدين
					// الطرف المدين

					var transactionD = new Transaction
					{
						IsCreditor = false,
						Amount = source.TotalValue.Value,
						CreationDate = now,
						DescriptionAR = ar?.Description,
						DescriptionEN = en?.Description
					};
					#region Record The Owner Of This Transaction
					transactionD.ObjectType = ObjectType.Translated;
					transactionD.ObjectId = source.Id;
					#endregion

					transactionD.AccountChartId = long.Parse(testamentAndAdvancesSetting.TestamentAccountNumber);

					#region Record The Owner Of This Transaction
					//transactionD.ObjectType = ObjectType.Donator;
					//transactionD.ObjectId = source.DonatorId;
					#endregion

					//if (source.VendorId.HasValue)
					//{
					//    if (source.Vendor == null) source.Vendor = this._vendorsRepository.Get(source.VendorId.Value);

					//    transactionD.AccountChartId = source.AccountChartId;

					//    #region Record The Owner Of This Transaction
					//    transactionD.ObjectType = ObjectType.Vendor;
					//    transactionD.ObjectId = source.VendorId;
					//    #endregion
					//}
					//else if (source.AccountChartId.HasValue)
					//{
					//    transactionD.AccountChartId = source.AccountChartId;

					//    #region Record The Owner Of This Transaction
					//    transactionD.ObjectType = ObjectType.AccountChart;
					//    transactionD.ObjectId = source.AccountChartId;
					//    #endregion
					//}
					//else if (source.DonatorId.HasValue)
					//{
					//    transactionD.AccountChartId = financialSetting.DonationAccount.Id;

					//    #region Record The Owner Of This Transaction
					//    transactionC.ObjectType = ObjectType.AccountChart;
					//    transactionC.ObjectId = transactionC.AccountChartId;
					//    #endregion
					//}


					#endregion

					journal.Transactions.Add(transactionD);

					#region الطرف الدائن
					// الطرف الدائن

					foreach (var advance in source.Advances)
					{
						var transactionC = new Transaction
						{
							IsCreditor = true,
							Amount = advance.Amount.Value,
							CreationDate = now,
							AccountChartId = advance.AccountChartId,
							DescriptionAR = advance.ChildTranslatedAdvances.FirstOrDefault(x => x.Language == Language.Arabic).Description,
							DescriptionEN = advance.ChildTranslatedAdvances.FirstOrDefault(x => x.Language == Language.English).Description
						};
						#region Record The Owner Of This Transaction
						transactionC.ObjectType = ObjectType.Translated;
						transactionC.ObjectId = source.Id;
						#endregion
						journal.Transactions.Add(transactionC);
					}


					#endregion



					list.Add(journal);
					if (postInMemory == false)
					{
						this._JournalsRepository.Add(journal);
					}
				}
			}

			return list;
		}

		public IList<Journal> PostLiquidation(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<Liquidation, long> condition = new ConditionFilter<Liquidation, long>
			{
				Query = (x => x.IsPosted == false &&
							  x.CreationDate <= toDate)
			};
			if (id.HasValue && id > 0)
			{
				condition = new ConditionFilter<Liquidation, long>
				{
					Query = (x => x.IsPosted == false &&
								  x.Id == id.Value)
				};
			}
			var sourceEntities = this._liquidationRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var systemCurrency = this._settingsService.GetSystemCurrency();
				var postingSetting = this._settingsService.GetPostingSetting();
				var financialSetting = this._settingsService.GetFinancialSetting();
				var testamentAndAdvancesSetting = this._settingsService.GetTestamentAndAdvancesSetting();

				foreach (var source in sourceEntities)
				{
					if (postInMemory == false)
					{
						source.IsPosted = true;
						source.PostingDate = now;
						source.PostedByUserId = userId;

						this._liquidationRepository.Update(source);
					}

					//LatestCurrencyRate latestCurrencyRate = this._currencyRatesService.GetLatestCurrencyRate(source.TotalValue.Value, systemCurrency.Currency, systemCurrency);

					#region Set Journal Description
					//var ar = source.ChildTranslatedCustodies.FirstOrDefault(x => x.Language == Language.Arabic);
					//var en = source.ChildTranslatedCustodies.FirstOrDefault(x => x.Language == Language.English);

					//string journalDescriptionAr = ar.Description;// = this._resourcesService[ResourceKeyEnum.RelayFromPaymentMovementNo, Language.Arabic].Value/* + latestCurrencyRate.AppendedDescriptionAr*/;
					//string journalDescriptionEn = en.Description;// = this._resourcesService[ResourceKeyEnum.RelayFromPaymentMovementNo, Language.English].Value /*+ latestCurrencyRate.AppendedDescriptionEn*/;

					//if (ar?.Description != null) journalDescriptionAr = ar.Description;
					//if (en?.Description != null) journalDescriptionEn = en.Description;
					#endregion

					var journal = new Journal
					{
						Date = now,
						MovementType = MovementType.Liquidation,
						ObjectId = source.Id,
						CreationDate = now,
						IsAutomaticPosting = IsAutomaticPosting,
						IsBulkPosting = IsBulkPosting
					};
					var journalAr = new Journal
					{
						//Description = journalDescriptionAr,
						Language = Language.Arabic,
						CreationDate = now,
						Date = now
					};
					var journalEn = new Journal
					{
						//Description = journalDescriptionEn,
						Language = Language.English,
						CreationDate = now,
						Date = now
					};

					journal.ChildTranslatedJournals.Add(journalAr);
					journal.ChildTranslatedJournals.Add(journalEn);

					#region الطرف المدين
					// الطرف المدين

                    var transactionC = new Transaction
                    {
                        IsCreditor = true,
                        Amount = source.TotalAmount,
                        CreationDate = now,
                       // DescriptionAR = ar?.Description,
                       // DescriptionEN = en?.Description
                    };
                    #region Record The Owner Of This Transaction
                    transactionC.ObjectType = ObjectType.Liquidation;
                    transactionC.ObjectId = source.Id;
                    #endregion
                    if(source.LiquidationType == LiquidationTypeEnum.Testament)
                        transactionC.AccountChartId = long.Parse(testamentAndAdvancesSetting.TestamentAccountNumber);
                    else if(source.LiquidationType == LiquidationTypeEnum.Advance)
                        transactionC.AccountChartId = long.Parse(testamentAndAdvancesSetting.AdvancesAccountNumber);

                    #region Record The Owner Of This Transaction
                    //transactionD.ObjectType = ObjectType.Donator;
                    //transactionD.ObjectId = source.DonatorId;
                    #endregion
                    journal.Transactions.Add(transactionC);


                    var transactionTaxC = new Transaction
                    {
                        IsCreditor = true,
                        Amount = source.TotalAmount * Convert.ToDecimal(this._settingsService.GetVAT()),
                        CreationDate = now,
                        // DescriptionAR = ar?.Description,
                        // DescriptionEN = en?.Description
                    };
                    #region Record The Owner Of This Transaction
                    transactionTaxC.ObjectType = ObjectType.Liquidation;
                    transactionTaxC.ObjectId = source.Id;
                    #endregion
                    transactionTaxC.AccountChartId = financialSetting.VATAccount.Value;


					#endregion

                    journal.Transactions.Add(transactionTaxC);

					//#region الطرف الدائن
					//// الطرف الدائن

					//foreach (var detail in source.LiquidationDetails)
					//{
					//    var transactionC = new Transaction
					//    {
					//        IsCreditor = true,
					//        Amount = detail.Amount.Value - ((detail.TaxDiscount.HasValue)? detail.TaxDiscount.Value : 0) - ((detail.MedicineDiscount.HasValue)? detail.MedicineDiscount.Value : 0),
					//        CreationDate = now,
					//        //AccountChartId = advance.AccountChartId,
					//        //DescriptionAR = advance.ChildTranslated.FirstOrDefault(x => x.Language == Language.Arabic).Description,
					//        //DescriptionEN = advance.ChildTranslatedAdvances.FirstOrDefault(x => x.Language == Language.English).Description
					//    };
					//    if (source.LiquidationType == LiquidationTypeEnum.Testament)
					//        transactionC.AccountChartId = long.Parse(testamentAndAdvancesSetting.TestamentAccountNumber);
					//    else if (source.LiquidationType == LiquidationTypeEnum.Advance)
					//        transactionC.AccountChartId = long.Parse(testamentAndAdvancesSetting.AdvancesAccountNumber);
					//    #region Record The Owner Of This Transaction
					//    transactionC.ObjectType = ObjectType.Liquidation;
					//    transactionC.ObjectId = source.Id;
					//    #endregion
					//    journal.Transactions.Add(transactionC);

					//    if (detail.TaxDiscount.HasValue)
					//    {
					//        var transactionTaxC = new Transaction
					//        {
					//            IsCreditor = true,
					//            Amount = detail.TaxDiscount.Value,
					//            CreationDate = now,
					//            //AccountChartId = advance.AccountChartId,
					//            //DescriptionAR = advance.ChildTranslated.FirstOrDefault(x => x.Language == Language.Arabic).Description,
					//            //DescriptionEN = advance.ChildTranslatedAdvances.FirstOrDefault(x => x.Language == Language.English).Description
					//        };
					//        transactionTaxC.AccountChartId = financialSetting.VATAccount.Value;
					//        #region Record The Owner Of This Transaction
					//        transactionC.ObjectType = ObjectType.Liquidation;
					//        transactionC.ObjectId = source.Id;
					//        #endregion
					//        journal.Transactions.Add(transactionTaxC); 
					//    }

					//    if (detail.MedicineDiscount.HasValue)
					//    {
					//        var transactionTaxC = new Transaction
					//        {
					//            IsCreditor = true,
					//            Amount = detail.MedicineDiscount.Value,
					//            CreationDate = now,
					//            //AccountChartId = advance.AccountChartId,
					//            //DescriptionAR = advance.ChildTranslated.FirstOrDefault(x => x.Language == Language.Arabic).Description,
					//            //DescriptionEN = advance.ChildTranslatedAdvances.FirstOrDefault(x => x.Language == Language.English).Description
					//        };
					//        transactionTaxC.AccountChartId = financialSetting.VATAccount.Value;
					//        #region Record The Owner Of This Transaction
					//        transactionC.ObjectType = ObjectType.Liquidation;
					//        transactionC.ObjectId = source.Id;
					//        #endregion
					//        journal.Transactions.Add(transactionTaxC);
					//    }
					//}


					//#endregion



					list.Add(journal);
					if (postInMemory == false)
					{
						this._JournalsRepository.Add(journal);
					}
				}
			}

			return list;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="toDate"></param>
		/// <param name="IsAutomaticPosting"></param>
		/// <param name="IsBulkPosting"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList<Journal> PostPurchaseInvoice(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
			{
				Query = (x => x.IsPosted == false &&
							  x.Date <= toDate)
			};
			if (id.HasValue && id > 0)
			{
				condition = new ConditionFilter<PurchaseInvoice, long>
				{
					Query = (x => x.IsPosted == false &&
								  x.Id == id.Value)
				};
			}
			var sourceEntities = this._purchaseInvoicesRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var vendorSetting = this._settingsService.GetVendorSetting();

				foreach (var source in sourceEntities)
				{
					if (postInMemory == false)
					{
						source.IsPosted = true;
						source.PostingDate = now;
						source.PostedByUserId = userId;

						this._purchaseInvoicesRepository.Update(source);
					}

					var journal = new Journal
					{
						Date = now,
						MovementType = MovementType.PurchaseInvoice,
						ObjectId = source.Id,
						CreationDate = now,
						IsAutomaticPosting = IsAutomaticPosting,
						IsBulkPosting = IsBulkPosting
					};
					var journalAr = new Journal
					{
						Description = this._resourcesService[ResourceKeyEnum.RelayFromPurchaseInvoiceNo, Language.Arabic].Value + source.Id,
						Language = Language.Arabic,
						CreationDate = now,
						Date = now
					};
					var journalEn = new Journal
					{
						Description = this._resourcesService[ResourceKeyEnum.RelayFromPurchaseInvoiceNo, Language.English].Value + source.Id,
						Language = Language.English,
						CreationDate = now,
						Date = now
					};

					journal.ChildTranslatedJournals.Add(journalAr);
					journal.ChildTranslatedJournals.Add(journalEn);

					#region الطرف المدين - إجمالى المصروفات
					// الطرف المدين

					var transactionD_1 = new Transaction
					{
						IsCreditor = false,
						Amount = source.TotalExpenses,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTotalExpenses, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTotalExpenses, Language.English].Value
					};

					transactionD_1.AccountChartId = vendorSetting.PurchaseExpensesAccount.Id;

					#region Record The Owner Of This Transaction
					transactionD_1.ObjectType = ObjectType.AccountChart;
					transactionD_1.ObjectId = transactionD_1.AccountChartId;
					#endregion

					journal.Transactions.Add(transactionD_1);
					#endregion

					#region الطرف المدين - قيمة الضريبة
					// الطرف المدين

					var transactionD_2 = new Transaction
					{
						IsCreditor = false,
						Amount = source.TaxAmount,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTaxAmount, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTaxAmount, Language.English].Value
					};

					transactionD_2.AccountChartId = vendorSetting.PurchaseTaxAccount.Id;

					#region Record The Owner Of This Transaction
					transactionD_2.ObjectType = ObjectType.AccountChart;
					transactionD_2.ObjectId = transactionD_2.AccountChartId;
					#endregion

					journal.Transactions.Add(transactionD_2);
					#endregion

					#region الطرف المدين - إجمالى الفاتورة
					// الطرف المدين

					var transactionD_3 = new Transaction
					{
						IsCreditor = false,
						Amount = source.TotalAmountBeforeTax,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTotalAmount, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTotalAmount, Language.English].Value
					};

					if (source.PurchaseInvoiceTypeId.Value == (byte)PurchaseInvoiceTypeEnum.Cash)
					{
						transactionD_3.AccountChartId = vendorSetting.CashPurchaseAccount.Id;

						#region Record The Owner Of This Transaction
						transactionD_3.ObjectType = ObjectType.AccountChart;
						transactionD_3.ObjectId = transactionD_3.AccountChartId;
						#endregion
					}
					else if (source.PurchaseInvoiceTypeId.Value == (byte)PurchaseInvoiceTypeEnum.Postpone)
					{
						transactionD_3.AccountChartId = vendorSetting.FuturePurchaseAccount.Id;

						#region Record The Owner Of This Transaction
						transactionD_3.ObjectType = ObjectType.AccountChart;
						transactionD_3.ObjectId = transactionD_3.AccountChartId;
						#endregion
					}
					else if (source.PurchaseInvoiceTypeId.Value == (byte)PurchaseInvoiceTypeEnum.Check)
					{
						transactionD_3.AccountChartId = vendorSetting.FuturePurchaseAccount.Id;

						#region Record The Owner Of This Transaction
						transactionD_3.ObjectType = ObjectType.AccountChart;
						transactionD_3.ObjectId = transactionD_3.AccountChartId;
						#endregion
					}

					journal.Transactions.Add(transactionD_3);
					#endregion

					#region الطرف الدائن  - صافى القيمة
					// الطرف الدائن

					var transactionC_1 = new Transaction
					{
						IsCreditor = true,
						Amount = source.NetAmount,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseInvoiceNetAmount, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseInvoiceNetAmount, Language.English].Value
					};

					if (source.Vendor == null) source.Vendor = this._vendorsRepository.Get(source.VendorId.Value);

					transactionC_1.AccountChartId = source.Vendor.AccountChartId;

					#region Record The Owner Of This Transaction
					transactionC_1.ObjectType = ObjectType.Vendor;
					transactionC_1.ObjectId = source.VendorId;
					#endregion

					journal.Transactions.Add(transactionC_1);
					#endregion

					#region الطرف الدائن  - إجمالى الخصم
					// الطرف الدائن

					var transactionC_2 = new Transaction
					{
						IsCreditor = true,
						Amount = source.TotalDiscount,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseInvoiceTotalDiscount, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseInvoiceTotalDiscount, Language.English].Value
					};

					transactionC_2.AccountChartId = vendorSetting.PurchaseDiscountAccount.Id;

					#region Record The Owner Of This Transaction
					transactionC_2.ObjectType = ObjectType.AccountChart;
					transactionC_2.ObjectId = transactionC_2.AccountChartId;
					#endregion

					journal.Transactions.Add(transactionC_2);
					#endregion


					list.Add(journal);

					if (postInMemory == false)
					{
						this._JournalsRepository.Add(journal);
					}
				}
			}

			return list;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="toDate"></param>
		/// <param name="IsAutomaticPosting"></param>
		/// <param name="IsBulkPosting"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList<Journal> PostPurchaseRebate(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>
			{
				Query = (x => x.IsPosted == false &&
							  x.Date <= toDate)
			};
			if (id.HasValue && id > 0)
			{
				condition = new ConditionFilter<PurchaseRebate, long>
				{
					Query = (x => x.IsPosted == false &&
								  x.Id == id.Value)
				};
			}
			var sourceEntities = this._purchaseRebatesRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var vendorSetting = this._settingsService.GetVendorSetting();

				foreach (var source in sourceEntities)
				{
					if (postInMemory == false)
					{
						source.IsPosted = true;
						source.PostingDate = now;
						source.PostedByUserId = userId;

						this._purchaseRebatesRepository.Update(source);
					}

					var journal = new Journal
					{
						Date = now,
						MovementType = MovementType.PurchaseRebate,
						ObjectId = source.Id,
						CreationDate = now,
						IsAutomaticPosting = IsAutomaticPosting,
						IsBulkPosting = IsBulkPosting
					};
					var journalAr = new Journal
					{
						Description = this._resourcesService[ResourceKeyEnum.RelayFromPurchaseRebateNo, Language.Arabic].Value + source.Id,
						Language = Language.Arabic,
						CreationDate = now,
						Date = now
					};
					var journalEn = new Journal
					{
						Description = this._resourcesService[ResourceKeyEnum.RelayFromPurchaseRebateNo, Language.English].Value + source.Id,
						Language = Language.English,
						CreationDate = now,
						Date = now
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
						DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseRebateNetAmount, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseRebateNetAmount, Language.English].Value
					};

					if (source.Vendor == null) source.Vendor = this._vendorsRepository.Get(source.VendorId.Value);

					transactionD_1.AccountChartId = source.Vendor.AccountChartId;

					#region Record The Owner Of This Transaction
					transactionD_1.ObjectType = ObjectType.Vendor;
					transactionD_1.ObjectId = source.VendorId;
					#endregion

					journal.Transactions.Add(transactionD_1);
					#endregion

					#region الطرف المدين - إجمالى الخصم
					// الطرف المدين

					var transactionD_2 = new Transaction
					{
						IsCreditor = false,
						Amount = source.TotalDiscount,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseRebateTotalDiscount, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.DebitTransactionForPurchaseRebateTotalDiscount, Language.English].Value
					};

					transactionD_2.AccountChartId = vendorSetting.PurchaseRebateDiscountAccount.Id;

					#region Record The Owner Of This Transaction
					transactionD_2.ObjectType = ObjectType.AccountChart;
					transactionD_2.ObjectId = transactionD_2.AccountChartId;
					#endregion

					journal.Transactions.Add(transactionD_2);
					#endregion

					#region الطرف الدائن  - إجمالى المصروفات
					// الطرف الدائن

					var transactionC_1 = new Transaction
					{
						IsCreditor = true,
						Amount = source.TotalExpenses,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseRebateTotalExpenses, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseRebateTotalExpenses, Language.English].Value
					};

					transactionC_1.AccountChartId = vendorSetting.PurchaseRebateExpensesAccount.Id;

					#region Record The Owner Of This Transaction
					transactionC_1.ObjectType = ObjectType.AccountChart;
					transactionC_1.ObjectId = transactionC_1.AccountChartId;
					#endregion

					journal.Transactions.Add(transactionC_1);
					#endregion

					#region الطرف الدائن  - قيمة الضريبة
					// الطرف الدائن

					var transactionC_2 = new Transaction
					{
						IsCreditor = true,
						Amount = source.TaxAmount,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseRebateTaxAmount, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseRebateTaxAmount, Language.English].Value
					};

					transactionC_2.AccountChartId = vendorSetting.PurchaseRebateTaxAccount.Id;

					#region Record The Owner Of This Transaction
					transactionC_2.ObjectType = ObjectType.AccountChart;
					transactionC_2.ObjectId = transactionC_2.AccountChartId;
					#endregion

					journal.Transactions.Add(transactionC_2);
					#endregion

					#region الطرف الدائن  - إجمالى الفاتورة
					// الطرف الدائن

					var transactionC_3 = new Transaction
					{
						IsCreditor = true,
						Amount = source.TotalAmount,
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseRebateTotalAmount, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForPurchaseRebateTotalAmount, Language.English].Value
					};

					if (source.PurchaseInvoiceTypeId.Value == (byte)PurchaseInvoiceTypeEnum.Cash)
					{
						transactionC_3.AccountChartId = vendorSetting.CashPurchasesRebateAccount.Id;

						#region Record The Owner Of This Transaction
						transactionC_3.ObjectType = ObjectType.AccountChart;
						transactionC_3.ObjectId = transactionC_3.AccountChartId;
						#endregion
					}
					else if (source.PurchaseInvoiceTypeId.Value == (byte)PurchaseInvoiceTypeEnum.Cash)
					{
						transactionC_3.AccountChartId = vendorSetting.FuturePurchaseRebateAccount.Id;

						#region Record The Owner Of This Transaction
						transactionC_3.ObjectType = ObjectType.AccountChart;
						transactionC_3.ObjectId = transactionC_3.AccountChartId;
						#endregion
					}
					else if (source.PurchaseInvoiceTypeId.Value == (byte)PurchaseInvoiceTypeEnum.Postpone)
					{
						transactionC_3.AccountChartId = vendorSetting.FuturePurchaseAccount.Id;

						#region Record The Owner Of This Transaction
						transactionC_3.ObjectType = ObjectType.AccountChart;
						transactionC_3.ObjectId = transactionC_3.AccountChartId;
						#endregion
					}
					journal.Transactions.Add(transactionC_3);
					#endregion


					list.Add(journal);
					if (postInMemory == false)
					{
						this._JournalsRepository.Add(journal);
					}
				}
			}

			return list;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="toDate"></param>
		/// <param name="IsAutomaticPosting"></param>
		/// <param name="IsBulkPosting"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList<Journal> PostReceiptsMovement(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
			{
				Query = (x => x.IsPosted == false &&
							  x.ParentKeyDonationId.HasValue == false &&
							  x.Date <= toDate)
			};
			if (id.HasValue && id > 0)
			{
				condition = new ConditionFilter<Donation, long>
				{
					Query = (x => x.IsPosted == false &&
							 x.ParentKeyDonationId.HasValue == false &&
							 x.Id == id.Value)
				};
			}
			var sourceEntities = this._donationsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var financialSetting = this._settingsService.GetFinancialSetting();
				var systemCurrency = this._settingsService.GetSystemCurrency();
				var postingSetting = this._settingsService.GetPostingSetting();

				foreach (var source in sourceEntities)
				{
					if (postInMemory == false)
					{
						source.IsPosted = true;
						source.PostingDate = now;
						source.PostedByUserId = userId;

						this._donationsRepository.Update(source);
					}

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
						Date = now,
						MovementType = MovementType.ReceiptsMovement,
						ObjectId = source.Id,
						CreationDate = now,
						IsAutomaticPosting = IsAutomaticPosting,
						IsBulkPosting = IsBulkPosting
					};
					var journalAr = new Journal
					{
						Description = journalDescriptionAr,
						Language = Language.Arabic,
						CreationDate = now,
						Date = now
					};
					var journalEn = new Journal
					{
						Description = journalDescriptionEn,
						Language = Language.English,
						CreationDate = now,
						Date = now
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
						TransactionCount += source.DonationDonators.Count;

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


					list.Add(journal);
					if (postInMemory == false)
					{
						this._JournalsRepository.Add(journal);
					}
				}
			}

			return list;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="toDate"></param>
		/// <param name="IsAutomaticPosting"></param>
		/// <param name="IsBulkPosting"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList<Journal> PostSalesInvoice(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0)
		{
			List<Journal> list = new List<Journal>();

			return list;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="toDate"></param>
		/// <param name="IsAutomaticPosting"></param>
		/// <param name="IsBulkPosting"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList<Journal> PostSalesRebate(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0)
		{
			List<Journal> list = new List<Journal>();

			return list;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="toDate"></param>
		/// <param name="IsAutomaticPosting"></param>
		/// <param name="IsBulkPosting"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList<Journal> PostStoreMovement(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<InventoryMovement, long> condition = new ConditionFilter<InventoryMovement, long>
			{
				Query = (x => x.IsPosted == false &&
							  x.Date <= toDate)
			};
			if (id.HasValue && id > 0)
			{
				condition = new ConditionFilter<InventoryMovement, long>
				{
					Query = (x => x.IsPosted == false &&
								  x.Id == id.Value)
				};
			}
			var sourceEntities = this._inventoryMovementsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var vendorSetting = this._settingsService.GetVendorSetting();
				var postingSetting = this._settingsService.GetPostingSetting();
				var systemCurrency = this._settingsService.GetSystemCurrency();

				foreach (var source in sourceEntities)
				{
					if (postInMemory == false)
					{
						source.IsPosted = true;
						source.PostingDate = now;
						source.PostedByUserId = userId;

						this._inventoryMovementsRepository.Update(source);
					}

					var journal = new Journal
					{
						Date = now,
						MovementType = MovementType.PurchaseRebate,
						ObjectId = source.Id,
						CreationDate = now,
						IsAutomaticPosting = IsAutomaticPosting,
						IsBulkPosting = IsBulkPosting
					};
					var journalAr = new Journal
					{
						Description = this._resourcesService[ResourceKeyEnum.StoreMovement, Language.Arabic].Value + source.Id,
						Language = Language.Arabic,
						CreationDate = now,
						Date = now
					};
					var journalEn = new Journal
					{
						Description = this._resourcesService[ResourceKeyEnum.StoreMovement, Language.English].Value + source.Id,
						Language = Language.English,
						CreationDate = now,
						Date = now
					};

					journal.ChildTranslatedJournals.Add(journalAr);
					journal.ChildTranslatedJournals.Add(journalEn);

					#region الطرف المدين
					// الطرف المدين

					var transactionD = new Transaction
					{
						IsCreditor = false,

						Amount = source.InventoryProductHistorys.Sum(x => (x.Price * Convert.ToDecimal(x.Quantity))),
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.StoreMovement, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.StoreMovement, Language.English].Value
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
					if (source.Inventory == null) source.Inventory = this._inventorysRepository.Get(source.InventoryId.Value);

					//-transactionD.AccountChartId = source.Bank.AccountChartId;
					var accD = source.Inventory.AccountChart; //source.CapturePapersBank.BankAccountCharts
															  //.FirstOrDefault(x => x.AccountChart.CurrencyId == systemCurrency.CurrencyId);

					if (accD != null)
					{
						//transactionD.AccountChartId = accD.Id;
					}
					else
					{
						//if (postingSetting.AllowPostingAccountCurrencyMisMatch)
						//{
						//    transactionD.AccountChartId = source.CapturePapersBank.BankAccountCharts.FirstOrDefault().AccountChartId;
						//}
						//else
						//{
						//    throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
						//}
					}


					journal.Transactions.Add(transactionD);
					#endregion

					#region الطرف الدائن
					// الطرف الدائن

					var transactionC = new Transaction
					{
						IsCreditor = true,
						Amount = source.InventoryProductHistorys.Sum(x => (x.Price * Convert.ToDecimal(x.Quantity))),
						CreationDate = now,
						DescriptionAR = this._resourcesService[ResourceKeyEnum.StoreMovement, Language.Arabic].Value,
						DescriptionEN = this._resourcesService[ResourceKeyEnum.StoreMovement, Language.English].Value
					};

					//Brand brand = source.InventoryProductHistorys.FirstOrDefault().Brand;
					//    if (source.InventoryProductHistorys.FirstOrDefault().Brand == null) brand = this._brandsRepository.Get(source.InventoryProductHistorys.FirstOrDefault().BrandId.Value);

					//Asset asset = this._assetsRepository.Get().FirstOrDefault(x => x.BrandId == brand.Id);



					//-transactionC.AccountChartId = source.Bank.AccountChartId;
					string accC = null;
					if (this._settingsService.GetFixedAssetAccount().Count > 0)
					{
						accC = this._settingsService.GetFixedAssetAccount()
							.FirstOrDefault(x => x.AccountChartViewModel.CurrencyId == systemCurrency.CurrencyId).Value;
					}
					else
					{
						throw new GeneralException((int)ErrorCodeEnum.NoFixedAssetAccountChartExist);
					}


					if (accC != null)
						transactionC.AccountChartId = long.Parse(accC);
					else
					{
						if (postingSetting.AllowPostingAccountCurrencyMisMatch)
						{
							transactionC.AccountChartId = long.Parse(this._settingsService.GetFixedAssetAccount().FirstOrDefault().Value);
							//transactionC.AccountChartId = source.Bank.BankAccountCharts.FirstOrDefault().AccountChartId;
						}
						else
						{
							throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
						}
					}


					journal.Transactions.Add(transactionC);
					#endregion


					list.Add(journal);
					if (postInMemory == false)
					{
						this._JournalsRepository.Add(journal);
					}
				}
			}

			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="idCollection"></param>
		/// <returns></returns>
		public IList<Journal> PostChecksUnderCollectionOfReceiptsMovement(IList<long> idCollection)
		{
			List<Journal> list = new List<Journal>();

			ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
			{
				Query = (x => x.IsPosted &&
							  x.ParentKeyDonationId.HasValue == false &&
							  idCollection.Any(item => item == x.Id))
			};

			var sourceEntities = this._donationsRepository.Get(condition);

			if (sourceEntities != null && sourceEntities.Count() > 0)
			{
				DateTime now = DateTime.Now;
				var userId = this._currentUserService.CurrentUserId;
				var financialSetting = this._settingsService.GetFinancialSetting();
				var systemCurrency = this._settingsService.GetSystemCurrency();
				var postingSetting = this._settingsService.GetPostingSetting();

				bool createPosting = false;
				foreach (var source in sourceEntities)
				{
					if (source.IsPosted == true)
					{
						createPosting = true;

						source.PostingDate = now;
						source.PostedByUserId = userId;
						source.FirstModifiedByUserId = userId;

						this._donationsRepository.Update(source);

						#region Set Journal Description
						var ar = source.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.Arabic);
						var en = source.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.English);

						string journalDescriptionAr = this._resourcesService[ResourceKeyEnum.RelayFromReceiptsMovementNo, Language.Arabic].Value + source.Code;
						string journalDescriptionEn = this._resourcesService[ResourceKeyEnum.RelayFromReceiptsMovementNo, Language.English].Value + source.Code;

						if (ar?.Description != null) journalDescriptionAr = ar.Description + " - " + journalDescriptionAr;
						if (en?.Description != null) journalDescriptionEn = en.Description + " - " + journalDescriptionEn;
						#endregion

						var journal = new Journal
						{
							Date = now,
							MovementType = MovementType.ReceiptsMovement,
							ObjectId = source.Id,
							CreationDate = now,
							IsAutomaticPosting = true,
							IsBulkPosting = false
						};
						var journalAr = new Journal
						{
							Description = journalDescriptionAr,
							Language = Language.Arabic,
							CreationDate = now,
							Date = now
						};
						var journalEn = new Journal
						{
							Description = journalDescriptionEn,
							Language = Language.English,
							CreationDate = now,
							Date = now
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
							DescriptionAR = this._resourcesService[ResourceKeyEnum.CreditTransactionForReceiptsMovement, Language.Arabic].Value,
							DescriptionEN = this._resourcesService[ResourceKeyEnum.CreditTransactionForReceiptsMovement, Language.English].Value
						};

						transactionC.AccountChartId = financialSetting.ChecksUnderCollectionAccount.Id;

						#region Record The Owner Of This Transaction
						transactionC.ObjectType = ObjectType.AccountChart;
						transactionC.ObjectId = transactionC.AccountChartId;
						#endregion

						journal.Transactions.Add(transactionC);
						#endregion

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

						if (source.Bank == null) source.Bank = this._banksRepository.Get(source.BankId.Value);

						if (source.Bank.BankAccountCharts.Count == 0)
							throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

						//-transactionD.AccountChartId = source.Bank.AccountChartId;
						var acc = source.Bank.BankAccountCharts
						   .FirstOrDefault(x => x.AccountChart.CurrencyId == source.CurrencyId);

						if (acc != null)
							transactionC.AccountChartId = acc.AccountChartId;
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

						journal.Transactions.Add(transactionD);
						#endregion

						list.Add(journal);

						this._JournalsRepository.Add(journal);
					}
				}

				if (createPosting)
				{
					JournalPosting journalPosting = new JournalPosting
					{
						IsAutomaticPosting = true,
						CreatedByUserId = userId,
						PostedReceiptsMovementCount = list.Count,
						PostReceiptsMovement = true,
						ToDate = now
					};

					this._JournalPostingsRepository.Add(journalPosting);
				}
			}

			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="movementType"></param>
		/// <returns></returns>
		public JournalPostingViewModel TryPostAutomatic(long id, MovementType movementType)
		{
			JournalPostingViewModel result = null;
			var postSetting = this._settingsService.GetPostingSetting();

			if (postSetting.IsPostingAutomatic)
			{
				result = new JournalPostingViewModel
				{
					IsAutomaticPosting = postSetting.IsPostingAutomatic,
					ToDate = DateTime.Now
				};

				switch (movementType)
				{
					case MovementType.General:
						break;
					case MovementType.ReceiptsMovement:
						result.PostReceiptsMovement = true;
						break;
					case MovementType.PaymentMovement:
						result.PostPaymentMovement = true;
						break;
					case MovementType.BankMovement:
						result.PostBankMovement = true;
						break;
					case MovementType.PurchaseInvoice:
						result.PostPurchaseInvoice = true;
						break;
					case MovementType.PurchaseRebate:
						result.PostPurchaseRebate = true;
						break;
					case MovementType.StoreMovement:
						result.PostStoreMovement = true;
						break;
					case MovementType.SalesInvoice:
						result.PostSalesInvoice = true;
						break;
					case MovementType.SalesRebate:
						result.PostSalesRebate = true;
						break;
					default:
						break;
				}

				result = this.PostJournal(result, id);
			}

			return result;
		}

		public AddJournalEntriesViewModel Post(long id, MovementType movementType)
		{
			AddJournalEntriesViewModel result = null;
			var postSetting = this._settingsService.GetPostingSetting();

			//result = new JournalPostingViewModel
			//{
			//    IsAutomaticPosting = postSetting.IsPostingAutomatic,
			//    ToDate = DateTime.Now
			//};

			switch (movementType)
			{
				case MovementType.General:
					break;
				case MovementType.ReceiptsMovement:
					result = this.PostReceiptsMovement(DateTime.Now, false, false, id, true).FirstOrDefault().ToAddModel();
					break;
				case MovementType.PaymentMovement:
					result = this.PostPaymentMovement(DateTime.Now, false, false, id, true).FirstOrDefault().ToAddModel();
					break;
				case MovementType.BankMovement:
					result = this.PostBankMovement(DateTime.Now, false, false, id, true).FirstOrDefault().ToAddModel();
					break;
				case MovementType.PurchaseInvoice:
					result = this.PostPurchaseInvoice(DateTime.Now, false, false, id, true).FirstOrDefault().ToAddModel();
					break;
				case MovementType.PurchaseRebate:
					result = this.PostPurchaseRebate(DateTime.Now, false, false, id, true).FirstOrDefault().ToAddModel();
					break;
				case MovementType.StoreMovement:
					result = this.PostStoreMovement(DateTime.Now, false, false, id, true).FirstOrDefault().ToAddModel();
					break;
				case MovementType.SalesInvoice:
					//result.PostSalesInvoice = true;
					break;
				case MovementType.SalesRebate:
					///result.PostSalesRebate = true;
					break;
				case MovementType.Testament:
					result = PostTestament(DateTime.Now, false, false, id, true).FirstOrDefault().ToAddModel();
					break;
				case MovementType.Liquidation:
					result = PostLiquidation(DateTime.Now, false, false, id, true).FirstOrDefault().ToAddModel();
					break;
				default:
					break;
			}

			//result = this.PostJournal(result, id);


			return result;
		}





		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">JournalPosting view model</param>
		public void ThrowExceptionIfExist(JournalPostingViewModel model)
		{
			//ConditionFilter<JournalPosting, long> condition = new ConditionFilter<JournalPosting, long>
			//{
			//    Query = (entity =>
			//        entity.Name == model.Name &&
			//        entity.Id != model.Id)
			//};
			//var existEntity = this._JournalPostingsRepository.Get(condition).FirstOrDefault();

			//if (existEntity != null)
			//    throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalPostingViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalPostingViewModel> Get(ConditionFilter<JournalPosting, long> condition)
		{
			var entityCollection = this._JournalPostingsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<JournalPostingViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalPostingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalPostingViewModel> Get(int? pageIndex, int? pageSize)
		{
			//var lang = this._languageService.CurrentLanguage;
			ConditionFilter<JournalPosting, long> condition = new ConditionFilter<JournalPosting, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//    item.Language == lang)
			};
			var entityCollection = this._JournalPostingsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<JournalPostingViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalPostingViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalPostingLightViewModel> GetLightModel(ConditionFilter<JournalPosting, long> condition)
		{
			var entityCollection = this._JournalPostingsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<JournalPostingLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalPostingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<JournalPostingLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			//var lang = this._languageService.CurrentLanguage;
			ConditionFilter<JournalPosting, long> condition = new ConditionFilter<JournalPosting, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//    item.Language == lang)
			};
			var entityCollection = this._JournalPostingsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<JournalPostingLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a JournalPostingViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public JournalPostingViewModel Get(long id)
		{
			var entity = this._JournalPostingsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		public GenericCollectionViewModel<ListJournalPostingLightViewModel> GetByFilter(JournalPostingFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<JournalPosting, long> condition = new ConditionFilter<JournalPosting, long>()
			{
				Order = Order.Descending
			};

			if (model.Sort?.Count > 0)
			{
				if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
			}

			//if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
			if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

			IQueryable<JournalPosting> queryableData = this._JournalPostingsRepository.Get(condition);

			if (string.IsNullOrEmpty(model.Id) == false)
				queryableData = queryableData.Where(x => x.Id.ToString().Contains(model.Id));

			if (model.IsAutomaticPosting != null)
				queryableData = queryableData.Where(x => x.IsAutomaticPosting == model.IsAutomaticPosting);

			if (model.IsBulkPosting != null)
				queryableData = queryableData.Where(x => x.IsBulkPosting == model.IsBulkPosting);

			//if(model.MovementType != null)
			//    queryableData = queryableData.Where(x => x.mo)

			if (model.DateFrom.HasValue)
				queryableData = queryableData.Where(x => x.ToDate >= model.DateFrom);

			if (model.DateTo.HasValue)
				queryableData = queryableData.Where(x => x.ToDate <= model.DateTo);


			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();


			var total = dtoCollection.Count();
			dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
			var result = new GenericCollectionViewModel<ListJournalPostingLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}



		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<JournalPostingViewModel> Add(IEnumerable<JournalPostingViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._JournalPostingsRepository.Add(entityCollection).ToList();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}
		/// <summary>
		/// Add an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public JournalPostingViewModel Add(JournalPostingViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._JournalPostingsRepository.Add(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<JournalPostingViewModel> Update(IEnumerable<JournalPostingViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._JournalPostingsRepository.Update(entityCollection).ToList();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}
		/// <summary>
		/// Update an entity.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public JournalPostingViewModel Update(JournalPostingViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._JournalPostingsRepository.Update(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		/// <summary>
		/// Delete entities.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<JournalPostingViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._JournalPostingsRepository.Delete(entityCollection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete entities by its id collection.
		/// </summary>
		/// <param name="collection"></param>
		public void Delete(IEnumerable<long> collection)
		{
			this._JournalPostingsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(JournalPostingViewModel model)
		{
			var entity = model.ToEntity();
			this._JournalPostingsRepository.Delete(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity by id.
		/// </summary>
		/// <param name="id"></param>
		public void Delete(long id)
		{
			var result = this._JournalPostingsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
