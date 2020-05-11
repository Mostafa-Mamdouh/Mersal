#region Using ...
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides Setting service for 
    /// business functionality.
    /// </summary>
    public class SettingsService : ISettingsService
    {
        #region Data Members
        private readonly ISettingsRepository _SettingsRepository;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly ICurrencysRepository _currencysRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        private const string FixedAssetAccount = "FixedAssetAccount";
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type SettingsService.
        /// </summary>
        /// <param name="SettingsRepository"></param>
        /// <param name="accountChartsRepository"></param>
        /// <param name="currencysRepository"></param>
        /// <param name="unitOfWork"></param>
        public SettingsService(
            ISettingsRepository SettingsRepository,
            IAccountChartsRepository accountChartsRepository,
            ICurrencysRepository currencysRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._SettingsRepository = SettingsRepository;
            this._accountChartsRepository = accountChartsRepository;
            this._currencysRepository = currencysRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        /// <summary>
        /// ضريبة القيمة المضافة
        /// </summary>
        /// <returns></returns>
        public double GetVAT()
        {
            ConditionFilter<Setting, long> condition = new ConditionFilter<Setting, long>
            {
                Query = (x => x.Key == "VAT")
            };
            var result = this._SettingsRepository.Get(condition).ToList().FirstOrDefault();

            return double.Parse(result.Value);
        }

        public VATSettingViewModel UpdateVAT(VATSettingViewModel model)
        {
            ConditionFilter<Setting, long> condition = new ConditionFilter<Setting, long>
            {
                Query = (x => x.Key == "VAT")
            };
            var entity = this._SettingsRepository.Get(condition).ToList().FirstOrDefault();

            entity.Value = model.VAT.ToString();
            entity = this._SettingsRepository.Update(entity);
            this._unitOfWork.Commit();

            return model;
        }


        /// <summary>
        /// إعدادات نظام الموردين
        /// </summary>
        /// <returns></returns>
        public VendorSettingViewModel GetVendorSetting()
        {
            var keys = this._SettingsRepository.Get().ToList();
            var result = new VendorSettingViewModel
            {
                CashPurchaseAccountNumber = keys.FirstOrDefault(k => k.Key == "CashPurchaseAccountNumber").Value,
                FuturePurchaseAccountNumber = keys.FirstOrDefault(k => k.Key == "FuturePurchaseAccountNumber").Value,
                PurchaseDiscountAccountNumber = keys.FirstOrDefault(k => k.Key == "PurchaseDiscountAccountNumber").Value,
                PurchaseExpensesAccountNumber = keys.FirstOrDefault(k => k.Key == "PurchaseExpensesAccountNumber").Value,
                PurchaseTaxAccountNumber = keys.FirstOrDefault(k => k.Key == "PurchaseTaxAccountNumber").Value,
                CashPurchasesRebateAccountNumber = keys.FirstOrDefault(k => k.Key == "CashPurchasesRebateAccountNumber").Value,
                FuturePurchaseRebateAccountNumber = keys.FirstOrDefault(k => k.Key == "FuturePurchaseRebateAccountNumber").Value,
                PurchaseRebateDiscountAccountNumber = keys.FirstOrDefault(k => k.Key == "PurchaseRebateDiscountAccountNumber").Value,
                PurchaseRebateExpensesAccountNumber = keys.FirstOrDefault(k => k.Key == "PurchaseRebateExpensesAccountNumber").Value,
                PurchaseRebateTaxAccountNumber = keys.FirstOrDefault(k => k.Key == "PurchaseRebateTaxAccountNumber").Value,
            };

            ConditionFilter<AccountChart, long> AccountChartCondition = new ConditionFilter<AccountChart, long>
            {
                Query = (x =>
                    x.Id.ToString() == result.CashPurchaseAccountNumber ||
                    x.Id.ToString() == result.FuturePurchaseAccountNumber ||
                    x.Id.ToString() == result.PurchaseDiscountAccountNumber ||
                    x.Id.ToString() == result.PurchaseExpensesAccountNumber ||
                    x.Id.ToString() == result.PurchaseTaxAccountNumber ||
                    x.Id.ToString() == result.CashPurchasesRebateAccountNumber ||
                    x.Id.ToString() == result.FuturePurchaseRebateAccountNumber ||
                    x.Id.ToString() == result.PurchaseRebateDiscountAccountNumber ||
                    x.Id.ToString() == result.PurchaseRebateExpensesAccountNumber ||
                    x.Id.ToString() == result.PurchaseRebateTaxAccountNumber)
            };
            var acoountCharts = this._accountChartsRepository.Get(AccountChartCondition).ToList();

            result.CashPurchaseAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.CashPurchaseAccountNumber).ToLightModel();
            result.FuturePurchaseAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.FuturePurchaseAccountNumber).ToLightModel();
            result.PurchaseDiscountAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.PurchaseDiscountAccountNumber).ToLightModel();
            result.PurchaseExpensesAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.PurchaseExpensesAccountNumber).ToLightModel();
            result.PurchaseTaxAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.PurchaseTaxAccountNumber).ToLightModel();
            result.CashPurchasesRebateAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.CashPurchasesRebateAccountNumber).ToLightModel();
            result.FuturePurchaseRebateAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.FuturePurchaseRebateAccountNumber).ToLightModel();
            result.PurchaseRebateDiscountAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.PurchaseRebateDiscountAccountNumber).ToLightModel();
            result.PurchaseRebateExpensesAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.PurchaseRebateExpensesAccountNumber).ToLightModel();
            result.PurchaseRebateTaxAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.PurchaseRebateTaxAccountNumber).ToLightModel();

            return result;
        }

        public VendorSettingViewModel UpdateVendorSetting(VendorSettingViewModel model)
        {
            var keys = this._SettingsRepository.Get();

            keys.FirstOrDefault(k => k.Key == "CashPurchaseAccountNumber").Value = model.CashPurchaseAccountNumber;
            keys.FirstOrDefault(k => k.Key == "FuturePurchaseAccountNumber").Value = model.FuturePurchaseAccountNumber;
            keys.FirstOrDefault(k => k.Key == "PurchaseDiscountAccountNumber").Value = model.PurchaseDiscountAccountNumber;
            keys.FirstOrDefault(k => k.Key == "PurchaseExpensesAccountNumber").Value = model.PurchaseExpensesAccountNumber;
            keys.FirstOrDefault(k => k.Key == "PurchaseTaxAccountNumber").Value = model.PurchaseTaxAccountNumber;
            keys.FirstOrDefault(k => k.Key == "CashPurchasesRebateAccountNumber").Value = model.CashPurchasesRebateAccountNumber;
            keys.FirstOrDefault(k => k.Key == "FuturePurchaseRebateAccountNumber").Value = model.FuturePurchaseRebateAccountNumber;
            keys.FirstOrDefault(k => k.Key == "PurchaseRebateDiscountAccountNumber").Value = model.PurchaseRebateDiscountAccountNumber;
            keys.FirstOrDefault(k => k.Key == "PurchaseRebateExpensesAccountNumber").Value = model.PurchaseRebateExpensesAccountNumber;
            keys.FirstOrDefault(k => k.Key == "PurchaseRebateTaxAccountNumber").Value = model.PurchaseRebateTaxAccountNumber;

            this._SettingsRepository.Update(keys);
            this._unitOfWork.Commit();

            var result = this.GetVendorSetting();
            return result;
        }


        /// <summary>
        /// إعدادات الحركة المالية
        /// </summary>
        /// <returns></returns>
        public FinancialSettingViewModel GetFinancialSetting()
        {
            var keys = this._SettingsRepository.Get().ToList();
            var result = new FinancialSettingViewModel
            {
                ShowCasesThatMetRequiredAmount = bool.Parse(keys.FirstOrDefault(k => k.Key == "ShowCasesThatMetRequiredAmount").Value),
				VATAccountNumber = keys.FirstOrDefault(k => k.Key == "VATAccountNumber").Value,
				ChecksUnderCollectionAccountNumber = keys.FirstOrDefault(k => k.Key == "ChecksUnderCollectionAccountNumber").Value,
                DonationAccountNumber = keys.FirstOrDefault(k => k.Key == "DonationAccountNumber").Value,
                DonationReturnAccountNumber = keys.FirstOrDefault(k => k.Key == "DonationReturnAccountNumber").Value,
                UseChecksUnderCollection = bool.Parse(keys.FirstOrDefault(k => k.Key == "UseChecksUnderCollection").Value),
                TemporaryCovenantAccountNumber = keys.FirstOrDefault(k => k.Key == "TemporaryCovenantAccountNumber").Value,
                BankingPaymentsAccountNumber = keys.FirstOrDefault(k => k.Key == "BankingPaymentsAccountNumber").Value,
                ReceiptPapersAccountNumber = keys.FirstOrDefault(k => k.Key == "ReceiptPapersAccountNumber").Value,
                ChecksUnderReceiptPapersAccountNumber = keys.FirstOrDefault(k => k.Key == "ChecksUnderReceiptPapersAccountNumber").Value,
                GeneralDonationsAccountNumber = keys.FirstOrDefault(k => k.Key == "GeneralDonationsAccountNumber").Value,

            };

            ConditionFilter<AccountChart, long> AccountChartCondition = new ConditionFilter<AccountChart, long>
            {
                Query = (x =>
					x.Id.ToString() == result.VATAccountNumber ||
					x.Id.ToString() == result.ChecksUnderCollectionAccountNumber ||
                    x.Id.ToString() == result.DonationAccountNumber ||
                    x.Id.ToString() == result.DonationReturnAccountNumber ||
					x.Id.ToString() == result.TemporaryCovenantAccountNumber ||
					x.Id.ToString() == result.BankingPaymentsAccountNumber ||
					x.Id.ToString() == result.ReceiptPapersAccountNumber ||
					x.Id.ToString() == result.ChecksUnderReceiptPapersAccountNumber ||
					x.Id.ToString() == result.GeneralDonationsAccountNumber					
					)
            };
            var acoountCharts = this._accountChartsRepository.Get(AccountChartCondition).ToList();

			result.VATAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.VATAccountNumber).ToLightModel();
			result.ChecksUnderCollectionAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.ChecksUnderCollectionAccountNumber).ToLightModel();
            result.DonationAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.DonationAccountNumber).ToLightModel();
            result.DonationReturnAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.DonationReturnAccountNumber).ToLightModel();

			result.BankingPaymentsAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.BankingPaymentsAccountNumber).ToLightModel();
			result.ChecksUnderReceiptPapers = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.ChecksUnderReceiptPapersAccountNumber).ToLightModel();
			result.TemporaryCovenantAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.TemporaryCovenantAccountNumber).ToLightModel();
			result.ReceiptPapersAccount = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.ReceiptPapersAccountNumber).ToLightModel();
			result.GeneralDonations = acoountCharts.FirstOrDefault(x => x.Id.ToString() == result.GeneralDonationsAccountNumber).ToLightModel();

			return result;
        }

        /// <summary>
        /// إعدادات العهد و السلفيات
        /// </summary>
        /// <returns></returns>
        public TestamentAndAdvancesSettingViewModel GetTestamentAndAdvancesSetting()
        {
            var keys = this._SettingsRepository.Get().ToList();
            var result = new TestamentAndAdvancesSettingViewModel
            {
                TestamentAccountNumber = keys.FirstOrDefault(k => k.Key == "TestamentAccountNumber").Value,
                AdvancesAccountNumber = keys.FirstOrDefault(k => k.Key == "AdvancesAccountNumber").Value,

            };

            return result;
        }

        public FinancialSettingViewModel UpdateFinancialSetting(FinancialSettingViewModel model)
        {
            var keys = this._SettingsRepository.Get();

            keys.FirstOrDefault(k => k.Key == "ShowCasesThatMetRequiredAmount").Value = model.ShowCasesThatMetRequiredAmount.ToString();
            keys.FirstOrDefault(k => k.Key == "UseChecksUnderCollection").Value = model.UseChecksUnderCollection.ToString();
			keys.FirstOrDefault(k => k.Key == "VATAccountNumber").Value = model.VATAccountNumber;
			keys.FirstOrDefault(k => k.Key == "ChecksUnderCollectionAccountNumber").Value = model.ChecksUnderCollectionAccountNumber;
            keys.FirstOrDefault(k => k.Key == "DonationAccountNumber").Value = model.DonationAccountNumber;
            keys.FirstOrDefault(k => k.Key == "DonationReturnAccountNumber").Value = model.DonationReturnAccountNumber;
            keys.FirstOrDefault(k => k.Key == "TemporaryCovenantAccountNumber").Value = model.TemporaryCovenantAccountNumber;
            keys.FirstOrDefault(k => k.Key == "BankingPaymentsAccountNumber").Value = model.BankingPaymentsAccountNumber;
            keys.FirstOrDefault(k => k.Key == "ReceiptPapersAccountNumber").Value = model.ReceiptPapersAccountNumber;
            keys.FirstOrDefault(k => k.Key == "ChecksUnderReceiptPapersAccountNumber").Value = model.ChecksUnderReceiptPapersAccountNumber;
            keys.FirstOrDefault(k => k.Key == "GeneralDonationsAccountNumber").Value = model.GeneralDonationsAccountNumber;



            this._SettingsRepository.Update(keys);
            this._unitOfWork.Commit();

            var result = this.GetFinancialSetting();
            return result;
        }

        public TestamentAndAdvancesSettingViewModel UpdateTestamentAndAdvancesSetting(TestamentAndAdvancesSettingViewModel model)
        {
            var keys = this._SettingsRepository.Get();

            keys.FirstOrDefault(k => k.Key == "TestamentAccountNumber").Value = model.TestamentAccountNumber.ToString();
            keys.FirstOrDefault(k => k.Key == "AdvancesAccountNumber").Value = model.AdvancesAccountNumber.ToString();
          

            this._SettingsRepository.Update(keys);
            this._unitOfWork.Commit();

            var result = this.GetTestamentAndAdvancesSetting();
            return result;
        }




        /// <summary>
        /// إعدادات ترحيل قيود اليومية
        /// </summary>
        /// <returns></returns>
        public PostingSettingSettingViewModel GetPostingSetting()
        {
            var keys = this._SettingsRepository.Get().ToList();
            var result = new PostingSettingSettingViewModel
            {
                IsBulkPosting = bool.Parse(keys.FirstOrDefault(k => k.Key == "IsBulkPosting").Value),
                IsPostingAutomatic = bool.Parse(keys.FirstOrDefault(k => k.Key == "IsPostingAutomatic").Value),
                AllowPostingAccountCurrencyMisMatch = bool.Parse(keys.FirstOrDefault(k => k.Key == "AllowPostingAccountCurrencyMisMatch").Value),
            };

            return result;
        }

        public PostingSettingSettingViewModel UpdatePostingSetting(PostingSettingSettingViewModel model)
        {
            var keys = this._SettingsRepository.Get();

            keys.FirstOrDefault(k => k.Key == "IsBulkPosting").Value = model.IsBulkPosting.ToString();
            keys.FirstOrDefault(k => k.Key == "IsPostingAutomatic").Value = model.IsPostingAutomatic.ToString();
            keys.FirstOrDefault(k => k.Key == "AllowPostingAccountCurrencyMisMatch").Value = model.AllowPostingAccountCurrencyMisMatch.ToString();

            this._SettingsRepository.Update(keys);
            this._unitOfWork.Commit();

            var result = this.GetPostingSetting();
            return result;
        }


        public GeneralSettingViewModel GetGeneralSetting()
        {
            var keys = this._SettingsRepository.Get().ToList();
            var result = new GeneralSettingViewModel
            {
                FiscalYearEndDay = keys.FirstOrDefault(k => k.Key == "FiscalYearEndDay").Value,
                FiscalYearEndMonth = keys.FirstOrDefault(k => k.Key == "FiscalYearEndMonth").Value,
                FiscalYearStartDay = keys.FirstOrDefault(k => k.Key == "FiscalYearStartDay").Value,
                FiscalYearStartMonth = keys.FirstOrDefault(k => k.Key == "FiscalYearStartMonth").Value,
                IsInventoryRequiredSetting = keys.FirstOrDefault(k => k.Key == "IsInventoryRequiredSetting").Value
            };

            if (string.IsNullOrEmpty(result.IsInventoryRequiredSetting) == false)
            {
                result.IsInventoryRequired = bool.Parse(result.IsInventoryRequiredSetting);
            }

            return result;
        }
        public GeneralSettingViewModel UpdateGeneralSetting(GeneralSettingViewModel model)
        {
            var keys = this._SettingsRepository.Get();

            keys.FirstOrDefault(k => k.Key == "FiscalYearEndDay").Value = model.FiscalYearEndDay;
            keys.FirstOrDefault(k => k.Key == "FiscalYearEndMonth").Value = model.FiscalYearEndMonth;
            keys.FirstOrDefault(k => k.Key == "FiscalYearStartDay").Value = model.FiscalYearStartDay;
            keys.FirstOrDefault(k => k.Key == "FiscalYearStartMonth").Value = model.FiscalYearStartMonth;
            keys.FirstOrDefault(k => k.Key == "IsInventoryRequiredSetting").Value = model.IsInventoryRequired.ToString();

            this._SettingsRepository.Update(keys);
            this._unitOfWork.Commit();

            var result = this.GetGeneralSetting();
            return result;
        }


        /// <summary>
        /// عملة النظام
        /// </summary>
        /// <returns></returns>
        public SystemCurrencySettingViewModel GetSystemCurrency()
        {
            var keys = this._SettingsRepository.Get().ToList();
            var result = new SystemCurrencySettingViewModel
            {
                SystemCurrency = keys.FirstOrDefault(k => k.Key == "SystemCurrency").Value,
            };

            if (string.IsNullOrEmpty(result.SystemCurrency) == false)
            {
                try
                {
                    result.CurrencyId = long.Parse(result.SystemCurrency);
                }
                catch (Exception ex)
                {

                }
            }

            if (result.CurrencyId.HasValue)
            {
                ConditionFilter<Currency, long> condition = new ConditionFilter<Currency, long>
                {
                    Query = (x =>
                        x.Id == result.CurrencyId)
                };
                var currency = this._currencysRepository.Get(condition).FirstOrDefault();

                if (currency != null)
                {
                    result.Currency = currency.ToLightModel();
                }
            }

            return result;
        }

        public SystemCurrencySettingViewModel UpdateSystemCurrency(SystemCurrencySettingViewModel model)
        {
            ConditionFilter<Setting, long> condition = new ConditionFilter<Setting, long>
            {
                Query = (x => x.Key == "SystemCurrency")
            };
            var entity = this._SettingsRepository.Get(condition).ToList().FirstOrDefault();

            entity.Value = model.SystemCurrency = model.CurrencyId.ToString();
            entity = this._SettingsRepository.Update(entity);
            this._unitOfWork.Commit();


            ConditionFilter<Currency, long> currencyCondition = new ConditionFilter<Currency, long>
            {
                Query = (x =>
                    x.Id == model.CurrencyId)
            };
            var currency = this._currencysRepository.Get(currencyCondition).FirstOrDefault();

            if (currency != null)
            {
                model.Currency = currency.ToLightModel();
            }

            return model;
        }



        public List<FixedAssetAccountChartSettingViewModel> GetFixedAssetAccount()
        {
            var lang = this._languageService.CurrentLanguage;
            var keys = this._SettingsRepository.Get().Where(x => x.Key == "FixedAssetAccount");
            List<FixedAssetAccountChartSettingViewModel> result = new List<FixedAssetAccountChartSettingViewModel>();
            if(keys.Count() > 0)
            {
                foreach(var model in keys)
                {
                    FixedAssetAccountChartSettingViewModel viewModel = new FixedAssetAccountChartSettingViewModel();
                    viewModel.Id = long.Parse(model.Value);
                    viewModel.Value = model.Value;
                    //viewModel.AccountChartViewModel = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == viewModel.Id).ToModel();
                    var accountChart = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == viewModel.Id);
                    viewModel.AccountChartViewModel = accountChart.ToLightModel();
                    viewModel.AccountChartViewModel.DisplyedName = $"{viewModel.AccountChartViewModel.FullCode} - {accountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name}"; //Manual map
                    result.Add(viewModel);
                }
            }
            

            return result;
        }

        public List<FixedAssetAccountChartSettingViewModel> UpdateFixedAssetAccount(ICollection<FixedAssetAccountChartSettingViewModel> models)
        {

            IEnumerable<FixedAssetAccountChartSettingViewModel> fixedAssetAccountsDelete = models.Where(x => x.ModelStatus == MersalAccountingService.Common.Enums.ModelStatus.Delete);
            if (fixedAssetAccountsDelete != null && fixedAssetAccountsDelete.Count() > 0)
            {
                foreach (var AssetAccountDelete in fixedAssetAccountsDelete)
                {
                    var assetAccount = this._SettingsRepository.Get().FirstOrDefault(x => x.Key == FixedAssetAccount && x.Value == AssetAccountDelete.Id.ToString());
                    if (assetAccount != null)
                        this._SettingsRepository.Delete(assetAccount);
                }
            }
            IEnumerable<FixedAssetAccountChartSettingViewModel> accountDocumentsAdd = models.Where(x => x.ModelStatus == MersalAccountingService.Common.Enums.ModelStatus.Add);
            if (accountDocumentsAdd != null && accountDocumentsAdd.Count() > 0)
            {
                foreach (var accountDocumentAdd in accountDocumentsAdd)
                {
                    try
                    {
                        //ThrowExceptionIfExist(accountDocumentAdd);
                        Setting fixedAssetAccountSetting =  this._SettingsRepository.Get().FirstOrDefault(x => x.Key == FixedAssetAccount && x.Value == accountDocumentAdd.Id.ToString());
                        if (fixedAssetAccountSetting != null)
                            throw new ItemAlreadyExistException();
                        Setting setting = new Setting()
                        {
                            Key = "FixedAssetAccount",
                            Value = accountDocumentAdd.Id.ToString()
                        };
                        this._SettingsRepository.Add(setting);

                    }
                    catch (ItemAlreadyExistException)
                    {
                        continue;
                    }
                }
            }

            this._unitOfWork.Commit();

            return models.Union(fixedAssetAccountsDelete).ToList();
        }




        /// <summary>
        /// Gets a GenericCollectionViewModel of SettingViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<SettingViewModel> Get(ConditionFilter<Setting, long> condition)
        {
            var entityCollection = this._SettingsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<SettingViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of SettingViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<SettingViewModel> Get(int? pageIndex, int? pageSize)
        {
            ConditionFilter<Setting, long> condition = new ConditionFilter<Setting, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._SettingsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<SettingViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of SettingViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<SettingLightViewModel> GetLightModel(ConditionFilter<Setting, long> condition)
        {
            var entityCollection = this._SettingsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<SettingLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of SettingViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<SettingLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            ConditionFilter<Setting, long> condition = new ConditionFilter<Setting, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var entityCollection = this._SettingsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<SettingLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a SettingViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SettingViewModel Get(long id)
        {
            var entity = this._SettingsRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<SettingViewModel> Add(IEnumerable<SettingViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._SettingsRepository.Add(entityCollection).ToList();

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
        public SettingViewModel Add(SettingViewModel model)
        {
            var entity = model.ToEntity();
            entity = this._SettingsRepository.Add(entity);

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
        public IList<SettingViewModel> Update(IEnumerable<SettingViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._SettingsRepository.Update(entityCollection).ToList();

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
        public SettingViewModel Update(SettingViewModel model)
        {
            var entity = model.ToEntity();
            entity = this._SettingsRepository.Update(entity);

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
        public void Delete(IEnumerable<SettingViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._SettingsRepository.Delete(entityCollection);

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
            this._SettingsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(SettingViewModel model)
        {
            var entity = model.ToEntity();
            this._SettingsRepository.Delete(entity);

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
            var result = this._SettingsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        
        #endregion
    }
}
