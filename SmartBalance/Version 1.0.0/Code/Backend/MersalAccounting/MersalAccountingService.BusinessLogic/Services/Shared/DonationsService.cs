#define Commented


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
using MersalAccountingService.Core.Models.ViewModels.Donation;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides Donation service for 
    /// business functionality.
    /// </summary>
    public class DonationsService : IDonationsService
    {
        #region Data Members
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IJournalsRepository _journalsRepository;
        private readonly ICurrentUserService _currentUserService;
        private static readonly HttpClient client = new HttpClient();
        private readonly IDonationsRepository _DonationsRepository;
        private readonly IBranchsRepository _BranchsRepository;
        private readonly IReceivingMehtodsRepository _ReceivingMehtodsRepository;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountChartsRepository _AccountChartsRepository;
        private readonly ICostCentersRepository _CostCentersRepository;
        private readonly IProductsRepository _ProductsRepository;
        private readonly IInventorysRepository _InventorysRepository;
        private readonly IVendorsRepository _vendorsRepository;
        private readonly ICasesRepository _CasesRepository;
        private readonly IGeneralAccountsRepository _GeneralAccountRepository;
        private readonly IMobilesRepository _MobileRepositoryRepository;
        private readonly IMailsRepository _MailRepositoryRepository;
        private readonly IAddresssRepository _AddressRepositoryRepository;
        private readonly IJournalPostingsService _journalPostingsService;
        private readonly ICurrencyRatesRepository _currencyRatesRepository;
        private readonly ICurrencysRepository _currencysRepository;
        private readonly ISettingsService _settingsService;
        private readonly ISafesRepository _safesRepository;
        private readonly IBanksRepository _banksRepository;
        private readonly IClosedMonthsService _closedMonthsService;
        private readonly IClosedReceiptService _closedReceiptService;
        private readonly IBankAccountChartRepository _bankAccountChartRepository;
        private readonly IDonationTypesRepository _donationTypesRepository;
        private readonly IJournalsService _journalsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type DonationsService.
        /// </summary>
        /// <param name="currentUserService"></param>
        /// <param name="CostCentersRepository"></param>
        /// <param name="DonationsRepository"></param>
        /// <param name="branchsRepository"></param>
        /// <param name="languageService"></param>
        /// <param name="TransactionsRepository"></param>
        /// <param name="ReceivingMehtodsRepository"></param>
        /// <param name="AccountChartsRepository"></param>
        /// <param name="ProductsRepository"></param>
        /// <param name="vendorsRepository"></param>
        /// <param name="InventorysRepository"></param>
        /// <param name="casesRepository"></param>
        /// <param name="generalAccountsRepository"></param>
        /// <param name="MobileRepository"></param>
        /// <param name="MailRepositoryRepository"></param>
        /// <param name="AddressRepositoryRepository"></param>
        /// <param name="journalPostingsService"></param>
        /// <param name="unitOfWork"></param>
        public DonationsService(
            ITransactionsRepository transactionsRepository,
            IJournalsRepository journalsRepository,
            ICurrentUserService currentUserService,
            ICostCentersRepository CostCentersRepository,
            IDonationsRepository DonationsRepository,
            IBranchsRepository branchsRepository,
            ILanguageService languageService,
            IReceivingMehtodsRepository ReceivingMehtodsRepository,
            IAccountChartsRepository AccountChartsRepository,
            IProductsRepository ProductsRepository,
            IVendorsRepository vendorsRepository,
            IInventorysRepository InventorysRepository,
            ICasesRepository casesRepository,
            IGeneralAccountsRepository generalAccountsRepository,
            IMobilesRepository MobileRepository,
            IMailsRepository MailRepositoryRepository,
            IAddresssRepository AddressRepositoryRepository,
            IJournalPostingsService journalPostingsService,
            ICurrencyRatesRepository currencyRatesRepository,
            ICurrencysRepository currencysRepository,
            ISettingsService settingsService,
            ISafesRepository safesRepository,
            IBanksRepository banksRepository,
            IClosedMonthsService closedMonthsService,
            IClosedReceiptService closedReceiptService,
            IBankAccountChartRepository bankAccountChartRepository,
            IDonationTypesRepository donationTypesRepository,
            IJournalsService journalsService,
            IUnitOfWork unitOfWork
            )
        {
            this._transactionsRepository = transactionsRepository;
            this._journalsRepository = journalsRepository;
            this._currentUserService = currentUserService;
            this._DonationsRepository = DonationsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
            this._BranchsRepository = branchsRepository;
            this._ReceivingMehtodsRepository = ReceivingMehtodsRepository;
            this._AccountChartsRepository = AccountChartsRepository;
            this._CostCentersRepository = CostCentersRepository;
            this._ProductsRepository = ProductsRepository;
            this._vendorsRepository = vendorsRepository;
            this._InventorysRepository = InventorysRepository;
            this._GeneralAccountRepository = generalAccountsRepository;
            this._CasesRepository = casesRepository;
            this._MobileRepositoryRepository = MobileRepository;
            this._MailRepositoryRepository = MailRepositoryRepository;
            this._AddressRepositoryRepository = AddressRepositoryRepository;
            this._journalPostingsService = journalPostingsService;
            this._currencyRatesRepository = currencyRatesRepository;
            this._currencysRepository = currencysRepository;
            this._settingsService = settingsService;
            this._safesRepository = safesRepository;
            this._banksRepository = banksRepository;
            this._closedMonthsService = closedMonthsService;
            this._closedReceiptService = closedReceiptService;
            this._bankAccountChartRepository = bankAccountChartRepository;
            this._donationTypesRepository = donationTypesRepository;
            this._journalsService = journalsService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">Donation view model</param>
        public void ThrowExceptionIfExist(DonationViewModel model)
        {
            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                Query = (entity =>

                    entity.Id != model.Id)
            };
            var existEntity = this._DonationsRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)statusCodes.ItemAlreadyExsist);
        }


        #region Validations
        //public SourceType ValidateSource(AddDonationViewModel model)
        //{
        //    bool ISValidSource = false;
        //    SourceType Type = 0;
        //    if (model.SourceType==SourceType.vendor && model.VendorId != null)
        //    {
        //        ISValidSource = ISValidSource == false ? true : false;
        //        Type = SourceType.vendor;

        //    }
        //     if (model.SourceType == SourceType.Donator && (model.Donator != null||model.DonatorId!=null))
        //    {
        //        if (model.Donator != null && model.DonatorId != null)
        //        {
        //            ISValidSource = false;
        //            Type = SourceType.Donator;
        //        }
        //        ISValidSource = ISValidSource == false ? true : false;

        //    }

        //    if (model.SourceType == SourceType.AccountChart && model.AccountChartId != null)
        //    {
        //        ISValidSource = ISValidSource == false ? true : false;
        //        Type = SourceType.AccountChart;
        //    }

        //    if (!ISValidSource)
        //    {
        //        //throw new Exception("Worng Source Detected");
        //        throw new SourceException();
        //    }
        //    return Type;
        //}

        public void ValidateAddViewModel(AddDonationViewModel model)
        {
            #region validatePayment
            bool Valid = false;
            ConditionFilter<ReceivingMethod, int> Rcondition = new ConditionFilter<ReceivingMethod, int>();
            Rcondition.Query = x => x.Id == model.ReceivingMethodId;
            var PaymenCode = _ReceivingMehtodsRepository.Get(Rcondition).FirstOrDefault().Code;
            if (PaymenCode == Convert.ToString(1))
            {
                //cash
                if (model.SafeAccountChartId != null)
                {
                    Valid = true;
                }
                else
                {
                    Valid = false;
                }
            }
            //Cheque
            else if (PaymenCode == Convert.ToString(2))
            {
                if (/*model.FromBankId != null &&*/
                    model.ToBankId != null &&
                    !string.IsNullOrEmpty(model.ChequeNumber) &&
                    model.Duedate != null)
                {
                    Valid = true;
                }
                else
                {
                    Valid = false;
                }
            }
            //visa
            else if (PaymenCode == Convert.ToString(3))
            {

                if (model.VisaBankId != null && model.ToBankAccountChartId.HasValue)
                    Valid = true;
                else
                    Valid = false;
            }
            else if (PaymenCode == Convert.ToString(4))
            {

                if (model.ToBankId != null && model.ToBankAccountChartId.HasValue)
                    Valid = true;
                else
                    Valid = false;
            }
            if (!Valid)
                throw new PaymentException((int)statusCodes.InvalidPayment);
            #endregion

            #region Description
            if (string.IsNullOrEmpty(model.DescriptionAR) || string.IsNullOrWhiteSpace(model.DescriptionAR))
            {
                throw new DescriptionException((int)statusCodes.InvalidDescription);
            }
            #endregion

            #region Validate branch 
            if (model.BranchId == 0)
            {
                throw new BranchException((int)statusCodes.InvalidBranch);
            }
            ConditionFilter<Branch, int> condition = new ConditionFilter<Branch, int>
            {
                Query = (entity =>

                    entity.Id != model.BranchId)
            };
            var existEntity = this._BranchsRepository.Get(condition).FirstOrDefault();

            if (existEntity == null)
                throw new BranchException((int)statusCodes.InvalidBranch);
            #endregion

            #region Validate Date
            if (model.Date == null)
            {
                throw new DateException((int)statusCodes.InvalidDate);
            }
            #endregion

         
        }

        public long ValidateIfCaseExsist(string CaseId)
        {
            ConditionFilter<Case, long> condition = new ConditionFilter<Case, long>
            {
                Query = x => x.ExternalId == CaseId
            };
            Case Case = _CasesRepository.Get(condition).FirstOrDefault();
            if (Case != null)
            {
                // fixed by ahmed shaikoun
                return Case.Id;// int.Parse(CaseId);
            }
            else
            {
                return 0;
            }
        }

        //public bool ValidateDestination(AddDonationViewModel model,SourceType source)
        //{
        //    if (source==SourceType.Donator)
        //    {
        //        if (
        //            (model.Cases.Count != 0 || model. || model.Products.Count != 0)
        //            && (model.Inventorys.Count == 0) &&(model.CostCenters.Count==0)
        //            )
        //        {
        //            return true;
        //        }
        //        else if (source == SourceType.vendor)
        //        {
        //            if ((model.Inventorys.Count != 0 || model.ForGeneralAccount || model.CostCenters.Count != 0)
        //            && (model.Cases.Count == 0) && (model.Products.Count == 0)
        //            )
        //            {
        //                return true;
        //            }
        //        }
        //        else if (source == SourceType.AccountChart)
        //        {
        //            if (
        //               (model.Cases.Count == 0)||
        //               (model.Products.Count == 0)||
        //               (model.Inventorys.Count != 0 || 
        //               model.ForGeneralAccount || 
        //               model.CostCenters.Count != 0)
        //            )
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}


        //public void ValidateVendor(long Id)
        //{
        //    if (Id == 0)
        //    {
        //        throw new ItemNotFoundException("Branch Cannot be Null");
        //    }
        //    ConditionFilter<Branch, long> condition = new ConditionFilter<Branch, long>
        //    {
        //        Query = (entity =>

        //            entity.Id != Id)
        //    };
        //    var existEntity = this._BranchsRepository.Get(condition).FirstOrDefault();

        //    if (existEntity == null)
        //        throw new ItemNotFoundException("Branch Not Found");
        //}
        #endregion

        #region ChecksUnderCollection

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetByFilter(ChecksUnderCollectionFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

            // The IQueryable data to query.  
            IQueryable<Donation> queryableData = this._DonationsRepository.Get(condition);

            queryableData = queryableData.Where(x =>
                    x.ParentKeyDonationId.HasValue == false &&
                    //x.IsPosted == true &&
                    x.ReceivingMethodId.Value == (byte)ReceivingMethodEnum.Cheque &&
                    x.Exchangeable == false);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

            //if (model.Amount.HasValue)
            //    queryableData = queryableData.Where(x => x.OpeningCredit >= model.OpeningCreditFrom);

            if (model.Amount.HasValue)
                queryableData = queryableData.Where(x => x.Amount <= model.Amount);

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.Date <= model.DateTo);

            if (model.Bank.HasValue)
                queryableData = queryableData.Where(x => x.BankId == model.Bank.Value);


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToChecksUnderCollectionModel()).ToList();

            foreach (var item in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == item.Id);
                //ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
                if (item.Bank != null)
                {
                    ViewModel.Bank = item.Bank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
                }
            }
            //if (model.Filters != null)
            //{
            //    foreach (var item in model.Filters)
            //    {
            //        switch (item.Field)
            //        {
            //            case "source":
            //                dtoCollection = dtoCollection.Where(x => x.Source.Contains(item.Value)).ToList();
            //                break;
            //            case "amount":
            //                dtoCollection = dtoCollection.Where(x => x.Amount.Equals(Convert.ToDecimal(item.Value))).ToList();
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ChecksUnderCollectionViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetChecksByBank(long bankId, bool exchangeable = false)
        {
            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                Query = (entity =>
                    entity.ParentKeyDonationId.HasValue == false &&
                    entity.ReceivingMethodId.Value == (byte)ReceivingMethodEnum.Cheque &&
                    entity.Exchangeable == exchangeable &&
                    entity.BankId == bankId)
            };
            var entityCollection = this._DonationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToChecksUnderCollectionModel()).ToList();
            var result = new GenericCollectionViewModel<ChecksUnderCollectionViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count
            };
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ChecksUnderCollectionViewModel> GetChecksUnderCollection(int? pageIndex, int? pageSize)
        {
            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (entity =>
                    entity.ParentKeyDonationId.HasValue == false &&
                    entity.ReceivingMethodId.Value == (byte)ReceivingMethodEnum.Cheque &&
                    entity.Exchangeable == false)
            };
            var entityCollection = this._DonationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToChecksUnderCollectionModel()).ToList();
            var result = new GenericCollectionViewModel<ChecksUnderCollectionViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<ChecksUnderCollectionViewModel> UpdateCollectionOfCheckUnderCollection(IList<ChecksUnderCollectionLightViewModel> model)
        {
            IList<long> list = new List<long>();

            foreach (var item in model)
            {
                var entity = this._DonationsRepository.Get(item.Id);

                //if (entity.IsPosted)
                //{
                entity.Exchangeable = item.Exchangeable;
                list.Add(entity.Id);
                //}



                entity = this._DonationsRepository.Update(entity);
            }

            this._journalPostingsService.PostChecksUnderCollectionOfReceiptsMovement(list);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var result = this.GetChecksUnderCollection(null, null);
            return result.Collection;
        }

        #endregion



        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DonationViewModel> Get(ConditionFilter<Donation, long> condition)
        {
            var entityCollection = this._DonationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<DonationViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DonationViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,

            };
            var entityCollection = this._DonationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<DonationViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<DonationLightViewModel> GetLightModel(ConditionFilter<Donation, long> condition)
        {
            var entityCollection = this._DonationsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<DonationLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ListDonationLightViewModel> GetLightModel(int? pageIndex, int? pageSize,
            int? branchId, DateTime? dateFrom, DateTime? dateTo, decimal? amountFrom, decimal? amountTo)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,

            };
            condition.Order = Order.Descending;
            if (branchId != null && dateFrom != null && dateTo != null && amountFrom != null && amountTo != null)
            {
                condition.Query = x => x.ParentKeyDonationId == null
                && x.Date >= dateFrom && x.Date <= dateTo && x.BranchId == branchId
                && x.Amount >= amountFrom && x.Amount <= amountTo
                ;
            }
            else if (branchId == null && amountFrom == null && amountTo == null)
            {
                condition.Query = x => x.ParentKeyDonationId == null
                && x.Date >= dateFrom && x.Date <= dateTo;

            }
            else if (amountFrom != null && amountTo != null && branchId == null)
            {
                condition.Query = x => x.ParentKeyDonationId == null
               && x.Date >= dateFrom && x.Date <= dateTo
               && x.Amount >= amountFrom && x.Amount <= amountTo;
            }
            else if (amountFrom == null && amountTo == null && branchId != null)
            {
                condition.Query = x => x.ParentKeyDonationId == null
               && x.Date >= dateFrom && x.Date <= dateTo
               && x.BranchId == branchId;
            }
            else
            {
                condition.Query = x => x.ParentKeyDonationId == null;
            }

            var entityCollection = this._DonationsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();


            foreach (var donation in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == donation.Id);
                //if (donation.Vendor != null)
                //{
                //    ViewModel.SourceType = SourceType.vendor;
                //    ViewModel.Source = donation.Vendor.ChildTranslatedVendors.First(x => x.Language == lang).Name;

                //}
                //if (donation.AccountChart != null)
                //{
                //    ViewModel.SourceType = SourceType.AccountChart;
                //    ViewModel.Source = donation.AccountChart.Code;
                //}
                if (donation.DonationDonators.Count > 0)
                {
                    ViewModel.SourceType = SourceType.Donator;
                    //dtoCollection.Find(x => x.Id == donation.Id).Source = donation.Donator.Name;
                }

                ViewModel.PaymentMethod = donation.ReceivingMethod.ChildTranslatedReceivingMethods.First(x => x.Language == lang).Name;
            }
            var result = new GenericCollectionViewModel<ListDonationLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = _DonationsRepository.GetCount(condition.Query),
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }



        public DonationInvoiceViewModel DonationInvoice(int Id)
        {
            var lang = this._languageService.CurrentLanguage;
            var systemCurrency = this._settingsService.GetSystemCurrency();
            var invoice = _DonationsRepository.Get(Id);

            DonationInvoiceViewModel model = new DonationInvoiceViewModel();
            model.Id = invoice.Id;
            model.Amount = invoice.Amount;
            model.Currency = invoice.Currency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang).Name;
            model.Date = invoice.Date;
            model.CreationDate = invoice.CreationDate;
            model.Branch = invoice.Branch.ChildTranslatedBranchs.FirstOrDefault(x => x.Language == lang).Name;

            if (systemCurrency != null &&
                systemCurrency.CurrencyId.HasValue &&
                systemCurrency.CurrencyId.Value != invoice.CurrencyId.Value)
            {
                var last = this._currencyRatesRepository.Get(null).OrderByDescending(y => y.Date).Where(x =>
                    x.CurrencyId == invoice.CurrencyId &&
                    x.ExchangeCurrencyId == systemCurrency.CurrencyId).FirstOrDefault();

                if (last != null)
                {
                    var sysCurrency = this._currencysRepository.Get(systemCurrency.CurrencyId.Value);
                    var sysCurrencyName = sysCurrency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang).Name;
                    model.LastCurrencyExchange = $"- ( {invoice.Amount * last.Price} {sysCurrencyName} )";
                    model.LastCurrencyExchange += $" - [ 1 {model.Currency} = {last.Price} {sysCurrencyName} ]";
                }
            }

            //if (invoice.Donator != null)
            //{
            //    model.DonatorName = invoice.Donator.Name;
            //}

            if (invoice.DonationType != null)
            {
                model.DonationTypeName = invoice.DonationType.Name;
            }

            //model.VendorId = invoice.VendorId;
            //model.AccountChartId = invoice.AccountChartId;
            //model.DonatorId = invoice.DonatorId;

            StringBuilder stringBuilder = new StringBuilder();

            if (invoice.DonationVendors.Count > 0)
            {
                foreach (var vendor in invoice.DonationVendors)
                {
                    stringBuilder.Append(vendor.Vendor.ChildTranslatedVendors.First(x => x.Language == lang).Name);
                    stringBuilder.Append(", ");
                }
            }
            if (invoice.DonationAccountCharts.Count > 0)
            {
                foreach (var accountChart in invoice.DonationAccountCharts)
                {
                    stringBuilder.Append($"{accountChart.AccountChart.FullCode}-{accountChart.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang).Name}");
                    stringBuilder.Append(", ");
                }
            }
            if (invoice.DonationDonators.Count > 0)
            {
                foreach (var donator in invoice.DonationDonators)
                {
                    stringBuilder.Append(donator.Donator.Name);
                    stringBuilder.Append(", ");
                }
            }

            model.Source = stringBuilder.ToString();

            model.PaymentMethod = invoice.ReceivingMethod.ChildTranslatedReceivingMethods.First(x => x.Language == lang).Name;

            if (invoice.Bank != null)
            {
                model.PaymentMethod += " - " + invoice.Bank.ChildTranslatedBanks.FirstOrDefault(x => x.Language == lang).Name;
            }

            if (invoice.DelegateMan != null && invoice.DelegateManReciptNumber != null)
            {
                model.DelegateMan = invoice.DelegateMan.ChildTranslatedDelegateMans.FirstOrDefault(x => x.Language == lang).Name;
                model.ReciptNumber = invoice.DelegateManReciptNumber;
            }
            return model;
        }

        public DonationViewModel GetById(long id)
        {
            var entity = this._DonationsRepository.Get(id);
            var model = entity.ToModel();
            if (entity.DonationDonators.Count > 0)
            {
                model.SourceType = SourceType.Donator;
                if (entity.DonationTypeId.HasValue)
                {
                    model.DonatoinTypesLevel = new List<long>();
                    model.DonatoinTypesLevel.Add(entity.DonationTypeId.Value);
                }
                if (entity.DonationType != null)
                {
                    var d = entity.DonationType;
                    while (d.ParentId.HasValue)
                    {
                        var e = this._donationTypesRepository.Get().FirstOrDefault(x => x.Id == d.ParentId);
                        model.DonatoinTypesLevel.Add(e.Id);
                        d = e;
                    } 
                }
            }

            return model;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by pagination.
        /// </summary>
        /// <returns></returns>
        public GenericCollectionViewModel<ListDonationLightViewModel> GetReceiptModel(FinancialViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

            IQueryable<Donation> queryableData = this._DonationsRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang &&
                                                     x.ParentKeyDonationId != null);
            //queryableData = queryableData.Where(x => x.ParentKeyDonationId.HasValue == false);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.ParentKeyDonation.Code.Contains(model.Code));
            //queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyDonation.Date >= model.DateFrom);
            //queryableData = queryableData.Where(x => x.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyDonation.Date <= model.DateTo);
            //queryableData = queryableData.Where(x => x.Date <= model.DateTo);

            if (string.IsNullOrEmpty(model.DelegateManReciptNumber) == false)
            {
                queryableData = queryableData.Where(x =>
                    x.ParentKeyDonation.DelegateManReciptNumber.Contains(model.DelegateManReciptNumber));

                //queryableData = queryableData.Where(x =>
                //	x.DelegateManReciptNumber.Contains(model.DelegateManReciptNumber));
            }

            if (model.AmountFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyDonation.Amount >= model.AmountFrom.Value);
            //queryableData = queryableData.Where(x => x.Amount >= model.AmountFrom.Value);

            if (model.AmountTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyDonation.Amount <= model.AmountTo.Value);
            //queryableData = queryableData.Where(x => x.Amount <= model.AmountTo.Value);

            if (model.Payment.HasValue)
            {
                queryableData = queryableData.Where(x =>
                    x.ParentKeyDonation.ReceivingMethodId.HasValue &&
                    x.ParentKeyDonation.ReceivingMethodId == model.Payment);

                //queryableData = queryableData.Where(x =>
                //	x.ReceivingMethodId.HasValue && x.ReceivingMethodId == model.Payment);
            }

            if (model.Branch.HasValue)
            {
                queryableData = queryableData.Where(x =>
                    x.ParentKeyDonation.BranchId.HasValue &&
                    x.ParentKeyDonation.BranchId == model.Branch);

                //queryableData = queryableData.Where(x =>
                //	x.BranchId.HasValue && 
                //  x.BranchId == model.Branch);
            }


            //var entityCollection = this._DonationsRepository.Get(condition).ToList();
            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            foreach (var donation in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == donation.ParentKeyDonationId);
                //var ViewModel = dtoCollection.Find(x => x.Id == donation.Id);

                ViewModel.Amount = donation.ParentKeyDonation.Amount.ToString() + " " + donation.ParentKeyDonation.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
                //ViewModel.Amount = donation.Amount.ToString() + " " + donation.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;

                //var branch = donation.Branch.ChildTranslatedBranchs.FirstOrDefault(x => x.Language == lang);
                //if (branch != null)
                //{
                //	ViewModel.Branch = branch.Name;
                //}

                //if (donation.ParentKeyDonation.Vendor != null)
                ////if (donation.Vendor != null)
                //{
                //    ViewModel.SourceType = SourceType.vendor;
                //    ViewModel.Source = donation.ParentKeyDonation.Vendor.ChildTranslatedVendors.First(x => x.Language == lang).Name;
                //    //ViewModel.Source = donation.Vendor.ChildTranslatedVendors.First(x => x.Language == lang).Name;
                //}

                //if (donation.ParentKeyDonation.AccountChart != null)
                ////if (donation.AccountChart != null)
                //{
                //    ViewModel.SourceType = SourceType.AccountChart;
                //    string fullCode = donation.ParentKeyDonation.AccountChart.FullCode;
                //    AccountChart translatedAccount = donation.ParentKeyDonation.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang);
                //    if (translatedAccount != null)
                //    {
                //        fullCode = fullCode + "-" + translatedAccount.Name;
                //    }
                //    ViewModel.Source = $"{fullCode}";
                //    //ViewModel.Source = donation.AccountChart.Code;
                //}

                //if (donation.ParentKeyDonation.Donator != null)
                ////if (donation.Donator != null)
                //{
                //    ViewModel.SourceType = SourceType.Donator;
                //    dtoCollection.Find(x => x.Id == donation.ParentKeyDonationId).Source = donation.ParentKeyDonation.Donator.Name;
                //    //dtoCollection.Find(x => x.Id == donation.Id).Source = donation.Donator.Name;
                //}

                ViewModel.PaymentMethod = donation.ParentKeyDonation.ReceivingMethod.ChildTranslatedReceivingMethods.First(x => x.Language == lang).Name;
                //ViewModel.PaymentMethod = donation.ReceivingMethod.ChildTranslatedReceivingMethods.First(x => x.Language == lang).Name;
            }

            if (model.Filters != null)
            {
                foreach (var item in model.Filters)
                {
                    switch (item.Field)
                    {
                        case "source":
                            dtoCollection = dtoCollection.Where(x => x.Source.Contains(item.Value)).ToList();
                            break;
                        //case "amount":
                        //    //dtoCollection = dtoCollection.Where(x => x.Amount.Equals(Convert.ToDecimal(item.Value))).ToList();
                        //    break;
                        default:
                            break;
                    }
                }
            }
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListDonationLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a DonationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DetailsDonationViewModel Get(long id)
        {
            Language lang = this._languageService.CurrentLanguage;
            var entity = this._DonationsRepository.Get(id);
            if (entity == null)
            {
                throw new ItemNotFoundException((int)statusCodes.notFound);
            }
            var model = entity.ToDetailsModel();
            if (entity.Bank != null)
            {

                model.BankName = entity.Bank.ChildTranslatedBanks.FirstOrDefault(x => x.Language == lang).Name;
                model.BankCode = entity.Bank.Code;
            }
            model.DescriptionAR = entity.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.Arabic).Description;
            model.DescriptionEN = entity.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.English).Description;

            #region Determine Source Type
            if (entity.DonationAccountCharts.Count > 0)
            {
                model.SourceType = SourceType.AccountChart;
            }
            else if (entity.DonationVendors.Count > 0)
            {
                model.SourceType = SourceType.vendor;
            }

            else if (entity.DonationDonators.Count > 0)
            {
                model.SourceType = SourceType.Donator;
            }

            //if (entity.Vendor != null)
            //{
            //    model.VendorName = entity.Vendor.ChildTranslatedVendors.FirstOrDefault(x => x.Language == lang).Name;
            //    model.VenderAccountNumber = entity.Vendor.AccountChart.Code;
            //}
            #endregion

            #region collections
            if (entity.DonationCostCenters != null && entity.DonationCostCenters.Count != 0)
            {
                List<DetailsDonationCostCenterViewModel> CostCenterList = new List<DetailsDonationCostCenterViewModel>();
                foreach (var CostCenter in entity.DonationCostCenters)
                {
                    DetailsDonationCostCenterViewModel cs = new DetailsDonationCostCenterViewModel();
                    cs.Name = CostCenter.CostCenter.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == lang).Name;
                    cs.Amount = CostCenter.Amount;
                    cs.Id = CostCenter.CostCenter.Id;
                    CostCenterList.Add(cs);
                }
                model.CostCenters = CostCenterList;
            }

            if (entity.DonationInventorys != null && entity.DonationInventorys.Count != 0)
            {
                List<DetailsDonationInventoryViewModel> InventoriesList = new List<DetailsDonationInventoryViewModel>();

                foreach (var Inventory in entity.DonationInventorys)
                {
                    DetailsDonationInventoryViewModel inv = new DetailsDonationInventoryViewModel();
                    inv.Name = Inventory.Inventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == lang).Name;
                    inv.Amount = Inventory.Amount;
                    inv.Id = Inventory.Inventory.Id;
                    InventoriesList.Add(inv);
                }
                model.Inventorys = InventoriesList;
            }

            if (entity.DonationProducts != null && entity.DonationProducts.Count != 0)
            {
                List<DetailsDonationProductViewModel> ProductsList = new List<DetailsDonationProductViewModel>();

                foreach (var Product in entity.DonationProducts)
                {
                    DetailsDonationProductViewModel pro = new DetailsDonationProductViewModel();
                    //pro.Name = Product.Product.ChildTranslatedProducts.FirstOrDefault(x => x.Language == lang).Name;
                    pro.Amount = Product.Amount;
                    pro.Id = Product.Product.Id;
                    pro.MeasurementUnit = Product.Product.MeasurementUnit.ChildTranslatedMeasurementUnits.FirstOrDefault(x => x.Language == lang).Name;
                    ProductsList.Add(pro);
                }
                model.Products = ProductsList;
            }
            #endregion



            return model;
        }

        //get details by id
        public AddDonationViewModel GetDetailsById(long id)
        {
            Language lang = this._languageService.CurrentLanguage;
            var entity = this._DonationsRepository.Get(id);
            if (entity == null)
            {
                throw new ItemNotFoundException((int)statusCodes.notFound);
            }
            var model = entity.ToDetailsAddModel();

            model.DescriptionAR = entity.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.Arabic).Description;
            model.DescriptionEN = entity.ChildTranslatedDonations.FirstOrDefault(x => x.Language == Language.English).Description;

            #region Determine Source Type
            if (entity.DonationAccountCharts.Count > 0)
            {
                model.SourceType = SourceType.AccountChart;
            }
            else if (entity.DonationVendors.Count > 0)
            {
                model.SourceType = SourceType.vendor;
            }

            //else if (entity.Donator != null)
            //{
            //    model.SourceType = SourceType.Donator;
            //    model.DonatoinTypesLevel.Add(entity.DonatorId.Value);
            //    var d = entity.DonationType;
            //    while (d.ParentId.HasValue)
            //    {
            //        var e = this._donationTypesRepository.Get().FirstOrDefault(x => x.Id == d.ParentId);
            //        model.DonatoinTypesLevel.Add(e.Id);
            //        d = e;
            //    }
            //}

            #endregion

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<DonationViewModel> Add(IEnumerable<DonationViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._DonationsRepository.Add(entityCollection).ToList();

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
        public AddDonationViewModel Add(AddDonationViewModel model)
        {
            if (model.Journal == null)
            {
                Donator donator = null;
                this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);
                if (model.DelegateManId.HasValue && model.DocumentId.HasValue && string.IsNullOrEmpty(model.DelegateManReciptNumber) == false)
                {
                    ClosedReceiptViewModel closedReceipt = new ClosedReceiptViewModel
                    {
                        DocumentId = model.DocumentId.Value,
                        ReceiptNumber = int.Parse(model.DelegateManReciptNumber)
                    };
                    this._closedReceiptService.Add(closedReceipt);
                }

                decimal CalculatedAmount = 0;
                DateTime CurrentDate = DateTime.Now;
                //call method to validate model
                ValidateAddViewModel(model);

                var userId = this._currentUserService.CurrentUserId;
                var entity = model.ToEntity();
                entity.CreationDate = CurrentDate;
                entity.Date = model.Date;
                entity.CreatedByUserId = userId;

                if (model.VendorId != null)
                {
                    foreach (var vendor in model.VendorId)
                    {
                        entity.DonationVendors.Add(new DonationVendor { CreationDate = DateTime.Now, VendorId = vendor, Donation = entity });
                    } 
                }


                if(model.AccountChartId != null)
                {
                    foreach(var accountChart in model.AccountChartId)
                    {
                        entity.DonationAccountCharts.Add(new DonationAccountChart { CreationDate = DateTime.Now, AccountChartId = accountChart, Donation = entity });
                    }
                }

                if(model.DonatorId != null)
                {
                    foreach (var donatorId in model.DonatorId)
                    {
                        entity.DonationDonators.Add(new DonationDonator { CreationDate = DateTime.Now, DonatorId = donatorId, Donation = entity });
                    }
                }

                //#region Generate Code
                //long DonationCount = _DonationsRepository.Get().Count();
                //entity.code =""
                //   +(DonationCount + 1).ToString();
                //#endregion

                FinancialSettingViewModel financialSetting = this._settingsService.GetFinancialSetting();
                if (financialSetting.UseChecksUnderCollection == false)
                {
                    entity.Exchangeable = true;
                }

                //check if new Donator 
                if (model.Donator != null)
                {
                    if (model.Donator != null && model.DonatorId == null)
                    {
                        //in case of new Donator 
                        donator = new Donator
                        {
                            Name = model.Donator.Name,
                            //	AccountChartId = model.Donator.accountChartId,
                            //Phone = model.Donator.phone,
                            CreationDate = CurrentDate
                        };
                        if (model.Donator.AccountChartId == 0)
                        {
                            donator.AccountChartId = null;
                        }
                        else
                        {
                            donator.AccountChartId = model.Donator.AccountChartId;
                        }
                        //ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
                        //{
                        //    Query = x => x.Code == "DonatorAccount"
                        //};
                        //Donator.AccountChartId = _AccountChartsRepository.Get(condition).FirstOrDefault().Id;
                        entity.DonationDonators.Add(new DonationDonator { CreationDate = DateTime.Now, Donation = entity, Donator = donator });

                        

                    }
                }

                #region Payments Props

                if (model.FromBankId != null)
                {
                    entity.BankId = model.FromBankId;
                }
                if (model.ToBankId != null)
                {
                    entity.ChequeToBankId = model.ToBankId;
                }
                if (model.VisaBankId != null)
                {
                    entity.BankId = model.VisaBankId;
                }
                #endregion



                PostingSettingSettingViewModel postingSettingSetting = this._settingsService.GetPostingSetting();
                if (postingSettingSetting.AllowPostingAccountCurrencyMisMatch == false)
                {
                    AccountChart accountChart = null;

                    #region الطرف الدائن
                    //if (entity.VendorId.HasValue)
                    //{
                    //    var vendor = this._vendorsRepository.Get(entity.VendorId.Value);

                    //    if (vendor.AccountChart == null)
                    //        accountChart = this._AccountChartsRepository.Get(vendor.AccountChartId.Value);
                    //    else
                    //        accountChart = vendor.AccountChart;


                    //    if (accountChart != null &&
                    //        entity.CurrencyId != accountChart.CurrencyId)
                    //    {
                    //        throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                    //    }


                    //}

                    //if (entity.AccountChartId.HasValue)
                    //{
                    //    accountChart = this._AccountChartsRepository.Get(entity.AccountChartId.Value);



                    //    if (accountChart != null &&
                    //        entity.CurrencyId != accountChart.CurrencyId)
                    //    {
                    //        throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                    //    }
                    //}

                    if (entity.DonationDonators.Count > 0)
                    {
                        accountChart = this._AccountChartsRepository.Get(long.Parse(financialSetting.DonationAccountNumber));



                        if (accountChart != null &&
                            entity.CurrencyId != accountChart.CurrencyId)
                        {
                            throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                        }
                    }

                    #endregion

                    #region الطرف المدين
                    //if (entity.SafeAccountChartId.HasValue)
                    //{
                    //    if (entity.AccountChart != null)
                    //        accountChart = entity.AccountChart;
                    //    else
                    //        accountChart = this._AccountChartsRepository.Get(entity.SafeAccountChartId.Value);
                    //}
                    else if (entity.BankId.HasValue)
                    {
                        // حالة اختيار طريقة الدفع شيك
                        if (entity.ChequeToBankId.HasValue)
                        {
                            // اعداد استخدام شيكات تحت التحصيل مفعل
                            if (financialSetting.UseChecksUnderCollection == false)
                            {
                                var bank = this._banksRepository.Get(entity.ChequeToBankId.Value);

                                if (bank.BankAccountCharts.Count == 0)
                                    throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                                //if (bank.AccountChart != null)
                                //    accountChart = bank.AccountChart;
                                //else
                                //    accountChart = this._AccountChartsRepository.Get(bank.AccountChartId.Value);

                                var acc = this._bankAccountChartRepository.Get().Where(x => x.BankId == bank.Id).FirstOrDefault(x => x.AccountChart.CurrencyId == entity.CurrencyId);//.FirstOrDefault(x => x.AccountChart.CurrencyId == entity.CurrencyId); //bank.BankAccountCharts
                                                                                                                                                                                     //.FirstOrDefault(x => x.AccountChart.CurrencyId == entity.CurrencyId);

                                if (acc != null)
                                    accountChart = acc.AccountChart;//.AccountChart;
                                else
                                {
                                    throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                                }

                            }
                            // اعداد استخدام شيكات تحت التحصيل غير مفعل
                            else
                            {
                                if (entity.Exchangeable)
                                {
                                    var bank = this._banksRepository.Get(entity.ChequeToBankId.Value);

                                    if (bank.BankAccountCharts.Count == 0)
                                        throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                                    //if (bank.AccountChart != null)
                                    //    accountChart = bank.AccountChart;
                                    //else
                                    //    accountChart = this._AccountChartsRepository.Get(bank.AccountChartId.Value);
                                    var acc = this._bankAccountChartRepository.Get().Where(x => x.BankId == bank.Id).FirstOrDefault(x => x.AccountChart.CurrencyId == entity.CurrencyId);

                                    if (acc != null)
                                        accountChart = acc.AccountChart;
                                    else
                                    {
                                        throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                                    }

                                }
                                else
                                {
                                    accountChart = this._AccountChartsRepository.Get(long.Parse(financialSetting.ChecksUnderCollectionAccountNumber));
                                }
                            }
                        }
                        else
                        {
                            var bank = this._banksRepository.Get(entity.BankId.Value);

                            if (bank.BankAccountCharts.Count == 0)
                                throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                            //if (bank.AccountChart != null)
                            //    accountChart = bank.AccountChart;
                            //else
                            //    accountChart = this._AccountChartsRepository.Get(bank.AccountChartId.Value);
                            var acc = this._bankAccountChartRepository.Get().Where(x => x.BankId == bank.Id).FirstOrDefault(x => x.AccountChart.CurrencyId == entity.CurrencyId);

                            if (acc != null)
                                accountChart = acc.AccountChart;
                            else
                            {
                                throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                            }
                        }
                    }


                    if (accountChart != null &&
                        entity.CurrencyId != accountChart.CurrencyId)
                    {
                        throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                    }
                    #endregion
                }


                #region Destination
                //Case Of Donation Case
                if (model.Cases != null && model.Cases.Count != 0)
                {
                    foreach (var Case in model.Cases)
                    {
                        CalculatedAmount += Case.Amount;
                        long CheckCase = ValidateIfCaseExsist(Case.CaseId);
                        if (CheckCase != 0)
                        {
                            DonationCase DonationCase = new DonationCase();
                            DonationCase.CaseId = CheckCase;
                            DonationCase.Amount = Case.Amount;
                            DonationCase.CreationDate = CurrentDate;
                            entity.DonationCases.Add(DonationCase);
                        }
                        else
                        {
                            Case NewCase = new Case();
                            NewCase.Name = Case.Name;
                            NewCase.ExternalId = Case.CaseId;
                            NewCase.CreationDate = CurrentDate;
                            DonationCase DonationCase = new DonationCase();
                            DonationCase.CreationDate = CurrentDate;
                            DonationCase.Case = NewCase;
                            DonationCase.Amount = Case.Amount;
                            entity.DonationCases.Add(DonationCase);
                        }

                    }
                }

                //Case Of Donation CostCenter
                if (entity.DonationCostCenters != null && entity.DonationCostCenters.Count != 0)
                {
                    foreach (DonationCostCenter CostCenter in entity.DonationCostCenters)
                    {
                        //  CalculatedAmount += CostCenter.Amount;

                    }
                }

                //Case Of Donation donationProduct
                if (entity.DonationProducts != null && entity.DonationProducts.Count != 0)
                {
                    foreach (DonationProduct donationProduct in entity.DonationProducts)
                    {
                        CalculatedAmount += donationProduct.Amount;

                    }
                }

                //Case Of DonationInventory
                if (entity.DonationInventorys != null && entity.DonationInventorys.Count != 0)
                {
                    foreach (DonationInventory DonationInventory in entity.DonationInventorys)
                    {
                        CalculatedAmount += DonationInventory.Amount;

                    }
                }
                decimal GeneralAccountShareOfDonation = entity.Amount - CalculatedAmount;
                if (GeneralAccountShareOfDonation < 0)
                {
                    throw new PaymentAmountException((int)statusCodes.InvalidAmount);
                }
                else if (GeneralAccountShareOfDonation > 0)
                {
                    GeneralAccount GeneralAccount = new GeneralAccount();
                    GeneralAccount.Name = "GeneralAccount";
                    GeneralAccount.Amount = GeneralAccountShareOfDonation;
                    GeneralAccount.CreationDate = CurrentDate;
                    entity.GeneralAccount = GeneralAccount;

                }
                #endregion

                #region translation
                entity.Description = "";
                entity.Language = null;

                Donation donationAr = new Donation();
                donationAr.Description = model.DescriptionAR;
                donationAr.Language = Language.Arabic;
                donationAr.CreationDate = CurrentDate;
                donationAr.Date = CurrentDate;

                Donation donationEn = new Donation();
                donationEn.Description = model.DescriptionEN;
                donationEn.Language = Language.English;
                donationEn.CreationDate = CurrentDate;
                donationEn.Date = CurrentDate;

                entity.ChildTranslatedDonations.Add(donationAr);
                entity.ChildTranslatedDonations.Add(donationEn);
                #endregion



                entity = this._DonationsRepository.Add(entity);

                #region Commit Changes
                this._unitOfWork.Commit();
                #endregion

                #region Save Donator Info If New Donator Region
                if (model.Donator != null && model.DonatorId == null)
                {
                    if(donator != null)
                        SaveNewDonatorData(model.Donator, donator.Id);
                }
                #endregion

                #region Generate New Code
                try
                {
                    ConditionFilter<Donation, long> condition = new ConditionFilter<Donation, long>
                    {
                        Query = x =>
                            x.ParentKeyDonationId == null &&
                            string.IsNullOrEmpty(x.Code) == false
                            ,
                        Order = Order.Descending
                    };

                    var z = this._DonationsRepository.Get(condition);
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
                            newCode = entity.Id;
                        }
                    }
                    entity.Code = newCode.ToString();
                }
                catch
                {
                    entity.Code = entity.Id.ToString();
                }

                entity = this._DonationsRepository.Update(entity);

                this._unitOfWork.Commit();
                #endregion

                model.Id = entity.Id;
                model.Code = entity.Code;

                //this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.ReceiptsMovement);
                //MakeAddTransactions(entity);

                model.Journal = this._journalPostingsService.Post(entity.Id, MovementType.ReceiptsMovement);
                model.Journal.Date = model.Date;

                foreach (var Journal in model.Journal.journalDetails)
                {
                    Journal.AccountFullCode = this._AccountChartsRepository.Get().FirstOrDefault(x => x.Id == Journal.AccountId).FullCode;
                }
                //model.DescriptionAr = model.DescriptionAR;
                //model.DescriptionEN = model.DescriptionEN;


            }
            else if (model.Journal.PostingStatus == PostingStatus.Approved)
            {
                this._journalsService.AddJournal(model.Journal, PostingStatus.NeedAprove);

                var entity = this._DonationsRepository.Get(model.Id);
                entity.IsPosted = false;
                entity.PostingDate = DateTime.Now;
                entity.PostedByUserId = this._currentUserService.CurrentUserId;
                entity = this._DonationsRepository.Update(entity);

                this._unitOfWork.Commit();

                

                #region Calling External Donation Api To Save Donations
                if (entity.DonationCases != null && entity.DonationCases.Count != 0)
                {
                    foreach (var DonationCase in entity.DonationCases)
                    {
                        MakeHttpCallToExtrenalCaseDonationApi(int.Parse(DonationCase.Case.ExternalId), (int)DonationCase.Amount);
                    }
                }
                #endregion
            }
            else if (model.Journal.PostingStatus == PostingStatus.Rejected)
            {

            }

            return model;
        }
        public void SaveNewDonatorData(AddDonatorViewModel donator, long Id)
        {
            DateTime CurrentDate = DateTime.Now;
            var Mobile = new Mobile();
            Mobile.CreationDate = CurrentDate;
            Mobile.CountryCallingCode = null;
            Mobile.Number = donator.Phone;
            Mobile.ObjectId = Id;
            Mobile.ObjectType = ObjectType.Donator;
            Mobile.IsActive = true;
            Mobile.IsMain = true;
            _MobileRepositoryRepository.Add(Mobile);

            var Email = new Mail();
            Email.CreationDate = CurrentDate;
            Email.ObjectId = Id;
            Email.ObjectType = ObjectType.Donator;
            Email.IsActive = true;
            Email.IsMain = true;
            Email.Email = donator.Email;
            _MailRepositoryRepository.Add(Email);

            var Address = new Address();
            Address.CreationDate = CurrentDate;
            Address.ObjectId = Id;
            Address.ObjectType = ObjectType.Donator;
            Address.IsActive = true;
            Address.IsMain = true;
            Address.Description = donator.Address;
            _AddressRepositoryRepository.Add(Address);
            this._unitOfWork.Commit();
        }
        public long AddExternalDonation(AddExternalDonationViewModel model)
        {
            GeneralAccount GeneralAccount = new GeneralAccount();
            GeneralAccount.CreationDate = DateTime.Now;
            GeneralAccount.Amount = model.Amount;
            GeneralAccount.Name = "External Donation";
            _GeneralAccountRepository.Add(GeneralAccount);
            _unitOfWork.Commit();
            return GeneralAccount.Id;
        }

        private void MakeHttpCallToExtrenalCaseDonationApi(int CaseId, int PaidAmount)
        {
            // Create POST data and convert it to a byte array.
            string mersalBase = System.Configuration.ConfigurationManager.AppSettings["mersal-api"];
            string mersalUrl = System.Configuration.ConfigurationManager.AppSettings["mersal-api-required-amount"];

            var client = new RestClient(mersalBase);
            var request = new RestRequest(mersalUrl, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                CaseId = CaseId,
                PaidAmount = PaidAmount
            });
            var res = client.Execute(request);
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void MakeAddTransactions(Donation model)
        {
            decimal CalculatedAmount = 0;
            string SourceType = "";
            long SourceTypeId = 0;
            DateTime CurrentDate = DateTime.Now;


            //if (model.VendorId != null)
            //{
            //    ConditionFilter<Vendor, long> Rcondition = new ConditionFilter<Vendor, long>();
            //    Rcondition.Query = x => x.Id == model.VendorId;
            //    var VendorAccountChartId = _vendorsRepository.Get(Rcondition).FirstOrDefault().AccountChartId;
            //    SourceType = "Vendor";
            //    SourceTypeId = (long)VendorAccountChartId;
            //}

            //if (model.DonatorId != null)
            //{
            //    SourceType = "Donator";
            //    SourceTypeId = (long)model.DonatorId;
            //}

            //if (model.AccountChartId != null)
            //{
            //    SourceType = "AccountChart";
            //    SourceTypeId = (long)model.AccountChartId;
            //}
            Transaction MainTranaction = new Transaction();
            MainTranaction.CreationDate = CurrentDate;
            MainTranaction.Amount = model.Amount;
            //MainTranaction.FromObjectId = SourceTypeId;
            //MainTranaction.FromObjectType = SourceType;
            MainTranaction.CreationDate = CurrentDate;
            //transaction.ToObjectId = Case.CaseId;
            //transaction.ToObjectType = "Case";
            //Case Of Donation Case
            if (model.DonationCases != null && model.DonationCases.Count != 0)
            {
                foreach (DonationCase Case in model.DonationCases)
                {
                    CalculatedAmount += Case.Amount;
                    TranactionDetails transaction = new TranactionDetails();
                    transaction.CreationDate = CurrentDate;
                    transaction.Amount = Case.Amount;
                    transaction.FromObjectId = SourceTypeId;
                    transaction.FromObjectType = SourceType;
                    //transaction.ToObjectId = Case;
                    transaction.ToObjectType = "Case";
                    transaction.CreationDate = CurrentDate;
                    //MainTranaction.TranactionsDetails.Add(transaction);
                }
            }

            //Case Of Donation CostCenter
            if (model.DonationCostCenters != null && model.DonationCostCenters.Count != 0)
            {
                foreach (DonationCostCenter CostCenter in model.DonationCostCenters)
                {
                    //  CalculatedAmount += CostCenter.Amount;
                    TranactionDetails transaction = new TranactionDetails();
                    transaction.CreationDate = CurrentDate;
                    transaction.Amount = CostCenter.Amount;
                    transaction.FromObjectId = SourceTypeId;
                    transaction.FromObjectType = SourceType;
                    ConditionFilter<CostCenter, long> condition = new ConditionFilter<CostCenter, long>
                    {
                        Query = x => x.Id == CostCenter.CostCenterId
                    };

                    var CostCenterChartId = this._CostCentersRepository.Get(condition).FirstOrDefault().AccountChartId;
                    transaction.ToObjectId = CostCenterChartId;
                    transaction.ToObjectType = "CostCenter";
                    transaction.CreationDate = CurrentDate;
                    // _TransactionsRepository.Add(transaction);
                    //MainTranaction.TranactionsDetails.Add(transaction);
                }
            }

            //Case Of Donation donationProduct
            if (model.DonationProducts != null && model.DonationProducts.Count != 0)
            {
                foreach (DonationProduct donationProduct in model.DonationProducts)
                {
                    TranactionDetails transaction = new TranactionDetails();
                    CalculatedAmount += donationProduct.Amount;
                    transaction.CreationDate = CurrentDate;
                    transaction.Amount = donationProduct.Amount;
                    transaction.FromObjectId = SourceTypeId;
                    transaction.FromObjectType = SourceType;
                    ConditionFilter<Product, long> condition = new ConditionFilter<Product, long>
                    {
                        Query = x => x.Id == donationProduct.ProductId
                    };
                    var ProductChartId = this._ProductsRepository.Get(condition).FirstOrDefault().AccountChartId;

                    transaction.ToObjectId = ProductChartId;
                    transaction.ToObjectType = "Product";
                    transaction.CreationDate = CurrentDate;
                    //MainTranaction.TranactionsDetails.Add(transaction);

                }
            }

            //Case Of DonationInventory
            if (model.DonationInventorys != null && model.DonationInventorys.Count != 0)
            {
                foreach (DonationInventory DonationInventory in model.DonationInventorys)
                {
                    TranactionDetails transaction = new TranactionDetails();
                    CalculatedAmount += DonationInventory.Amount;
                    transaction.CreationDate = CurrentDate;
                    transaction.Amount = DonationInventory.Amount;
                    transaction.FromObjectId = SourceTypeId;
                    transaction.FromObjectType = SourceType;
                    ConditionFilter<Inventory, long> condition = new ConditionFilter<Inventory, long>
                    {
                        Query = x => x.Id == DonationInventory.InventoryId
                    };
                    var ProductChartId = this._InventorysRepository.Get(condition).FirstOrDefault().AccountChartId;
                    transaction.ToObjectId = ProductChartId;
                    transaction.ToObjectType = "Inventory";
                    transaction.CreationDate = CurrentDate;
                    //MainTranaction.TranactionsDetails.Add(transaction);
                }
            }
            decimal GeneralAccountShareOfDonation = model.Amount - CalculatedAmount;
            if (GeneralAccountShareOfDonation < 0)
            {
                throw new PaymentAmountException((int)statusCodes.InvalidAmount);
            }
            else if (GeneralAccountShareOfDonation > 0)
            {
                string code = System.Configuration.ConfigurationManager.AppSettings["GeneralAccountCode"];

                ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
                {
                    Query = x => x.Code == code
                };

                var GeneralAccountChartId = this._AccountChartsRepository.Get(condition).FirstOrDefault().Id;

                TranactionDetails transaction = new TranactionDetails();
                transaction.CreationDate = CurrentDate;
                transaction.Amount = GeneralAccountShareOfDonation;
                transaction.FromObjectId = SourceTypeId;
                transaction.FromObjectType = SourceType;
                transaction.ToObjectId = GeneralAccountChartId;
                //transaction.ToObjectId = DonationInventory.InventoryId;
                transaction.ToObjectType = "GeneralAccount";
                transaction.CreationDate = CurrentDate;

                //MainTranaction.TranactionsDetails.Add(transaction);
            }
            this._transactionsRepository.Add(MainTranaction);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<DonationViewModel> Update(IEnumerable<DonationViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._DonationsRepository.Update(entityCollection).ToList();

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
        public AddDonationViewModel Update(AddDonationViewModel model)
        {
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);

            //this.ThrowExceptionIfExist(model);

            //var entity = model.ToEntity();
            //entity = this._DonationsRepository.Update(entity);

            var ar = this._DonationsRepository.Get(null).Where(x =>
                x.ParentKeyDonationId == model.Id && x.Language == Language.Arabic).FirstOrDefault();

            var en = this._DonationsRepository.Get(null).Where(x =>
                x.ParentKeyDonationId == model.Id && x.Language == Language.English).FirstOrDefault();

            ar.Description = model.DescriptionAR;
            en.Description = model.DescriptionEN;

            this._DonationsRepository.Update(ar);
            this._DonationsRepository.Update(en);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion


            return model;
        }

        /// <summary>
        /// Delete entities.
        /// </summary>
        /// <param name="collection"></param>
        public void Delete(IEnumerable<DonationViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._DonationsRepository.Delete(entityCollection);

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
            this._DonationsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(DonationViewModel model)
        {
            var entity = model.ToEntity();
            this._DonationsRepository.Delete(entity);

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
            var result = this._DonationsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException(

                    );

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
