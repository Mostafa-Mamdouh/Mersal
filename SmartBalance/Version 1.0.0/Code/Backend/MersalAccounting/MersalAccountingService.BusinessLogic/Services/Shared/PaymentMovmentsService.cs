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
using MersalAccountingService.Core.Models.ViewModels.PaymentMovment;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides PaymentMovment service for 
    /// business functionality.
    /// </summary>
    public class PaymentMovmentsService : IPaymentMovmentsService
    {
        #region Data Members
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IJournalsRepository _journalsRepository;
        private readonly IJournalPostingsService _journalPostingsService;
        private readonly IPaymentMovmentsRepository _PaymentMovmentsRepository;
        private readonly IReceivingMehtodsRepository _ReceivingMehtodsRepository;
        private readonly IInventorysRepository _InventorysRepository;
        private readonly ICostCentersRepository _CostCentersRepository;
        private readonly IBranchsRepository _BranchsRepository;
        private readonly IVendorsRepository _vendorsRepository;
        private readonly ISettingsService _settingsService;
        private readonly ISafesRepository _safesRepository;
        private readonly IBanksRepository _banksRepository;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly IMobilesRepository _MobileRepositoryRepository;
        private readonly IMailsRepository _MailRepositoryRepository;
        private readonly IAddresssRepository _AddressRepositoryRepository;
        private readonly ICasesRepository _CasesRepository;
        private readonly IDonatorRepository _DonatorRepository;
        private readonly ILanguageService _languageService;
        private readonly IClosedMonthsService _closedMonthsService;
        private readonly IClosedReceiptService _closedReceiptService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IBankAccountChartRepository _bankAccountChartRepository;
        private readonly IDonationTypesRepository _donationTypesRepository;
        private readonly IJournalsService _journalsService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PaymentMovmentsService.
        /// </summary>
        /// <param name="PaymentMovmentsRepository"></param>
        /// <param name="unitOfWork"></param>
        public PaymentMovmentsService(
            ITransactionsRepository transactionsRepository,
            IJournalsRepository journalsRepository,
            IJournalPostingsService journalPostingsService,
            IPaymentMovmentsRepository PaymentMovmentsRepository,
            ILanguageService languageService,
            IReceivingMehtodsRepository ReceivingMehtodsRepository,
            ICostCentersRepository CostCentersRepository,
            IBranchsRepository branchsRepository,
            IInventorysRepository InventorysRepository,
            IVendorsRepository vendorsRepository,
            ISettingsService settingsService,
            ISafesRepository safesRepository,
            IBanksRepository banksRepository,
            IMobilesRepository MobileRepository,
            IMailsRepository MailRepository,
            IAddresssRepository AddressRepository,
            IAccountChartsRepository accountChartsRepository,
            IDonatorRepository donatorRepository,
            ICasesRepository casesRepository,
            IClosedMonthsService closedMonthsService,
            IClosedReceiptService closedReceiptService,
            ICurrentUserService currentUserService,
            IBankAccountChartRepository bankAccountChartRepository,
            IDonationTypesRepository donationTypesRepository,
            IJournalsService journalsService,
            IUnitOfWork unitOfWork
            )
        {
            this._transactionsRepository = transactionsRepository;
            this._journalsRepository = journalsRepository;
            this._journalPostingsService = journalPostingsService;
            this._PaymentMovmentsRepository = PaymentMovmentsRepository;
            this._ReceivingMehtodsRepository = ReceivingMehtodsRepository;
            this._InventorysRepository = InventorysRepository;
            this._BranchsRepository = branchsRepository;
            this._CostCentersRepository = CostCentersRepository;
            this._vendorsRepository = vendorsRepository;
            this._languageService = languageService;
            this._settingsService = settingsService;
            this._safesRepository = safesRepository;
            this._banksRepository = banksRepository;
            this._accountChartsRepository = accountChartsRepository;
            this._MobileRepositoryRepository = MobileRepository;
            this._MailRepositoryRepository = MailRepository;
            this._AddressRepositoryRepository = AddressRepository;
            this._DonatorRepository = donatorRepository;
            this._CasesRepository = casesRepository;
            this._closedMonthsService = closedMonthsService;
            this._closedReceiptService = closedReceiptService;
            this._currentUserService = currentUserService;
            this._bankAccountChartRepository = bankAccountChartRepository;
            this._donationTypesRepository = donationTypesRepository;
            this._journalsService = journalsService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">PaymentMovment view model</param>
        public void ThrowExceptionIfExist(PaymentMovmentViewModel model)
        {
            //ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
            //{
            //    Query = (entity =>
            //        //entity.Name == model.Name &&
            //        entity.Id != model.Id)
            //};
            //var existEntity = this._PaymentMovmentsRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //    throw new ItemAlreadyExistException((int)statusCodes.ItemAlreadyExsist);
        }

        public void ValidateAddViewModel(AddPaymentMovmentViewModel model)
        {
            if (string.IsNullOrEmpty(model.LiquidationNumber))
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


                    if (
                        model.FromBankId != null
                        && !string.IsNullOrEmpty(model.ChequeNumber)
                        && model.Duedate != null

                        )
                        Valid = true;
                    else
                        Valid = false;
                }
                //visa
                else if (PaymenCode == Convert.ToString(3))
                {

                    if (model.VisaBankId != null && !string.IsNullOrEmpty(model.VisaNumber))
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
            }

            #region Description
            if (string.IsNullOrEmpty(model.DescriptionAR) || string.IsNullOrWhiteSpace(model.DescriptionAR))
            {
                throw new DescriptionException((int)statusCodes.InvalidDescription);
            }
            #endregion

            #region Validate branch 
            if (model.BranchId == 0 || model.BranchId == null)
            {
                throw new ItemNotFoundException((int)statusCodes.InvalidBranch);
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

          

            #region validate Amount
            decimal calculatedAmount = 0;
            if (model.CostCenters != null && model.CostCenters.Count != 0)
            {
                foreach (AddPaymentMovmentCostCenterViewModel CostCenter in model.CostCenters)
                {
                    calculatedAmount += CostCenter.Amount;
                }
            }



            //Case Of PaymentMovmentInventorys
            if (model.Inventorys != null && model.Inventorys.Count != 0)
            {
                foreach (AddPaymentMovmentInventoryViewModel PaymentMovmentInventory in model.Inventorys)
                {
                    calculatedAmount += PaymentMovmentInventory.Amount;
                }
            }
            if (model.Amount < calculatedAmount)
            {
                throw new PaymentAmountException((int)statusCodes.InvalidAmount);
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

        /// <summary>
        /// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<ListPaymentMovmentLightViewModel> GetLightModel(int? pageIndex, int? pageSize,
            int? branchId, DateTime? dateFrom, DateTime? dateTo, decimal? amountFrom, decimal? amountTo)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            condition.Order = Order.Descending;
            if (branchId != null && dateFrom != null && dateTo != null && amountFrom != null && amountTo != null)
            {
                condition.Query = x => x.ParentKeyPaymentMovment == null
                && x.Date >= dateFrom && x.Date <= dateTo && x.BranchId == branchId
                && x.Amount >= amountFrom && x.Amount <= amountTo
                ;
            }
            else if (branchId == null && amountFrom == null && amountTo == null)
            {
                condition.Query = x => x.ParentKeyPaymentMovment == null
                && x.Date >= dateFrom && x.Date <= dateTo;

            }
            else if (amountFrom != null && amountTo != null && branchId == null)
            {
                condition.Query = x => x.ParentKeyPaymentMovment == null
               && x.Date >= dateFrom && x.Date <= dateTo
                   && x.Amount >= amountFrom && x.Amount <= amountTo;
            }
            else if (amountFrom == null && amountTo == null && branchId != null)
            {
                condition.Query = x => x.ParentKeyPaymentMovment == null
               && x.Date >= dateFrom && x.Date <= dateTo
                   && x.BranchId == branchId;
            }
            else
            {
                condition.Query = x => x.ParentKeyPaymentMovment == null;
            }
            var entityCollection = this._PaymentMovmentsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            foreach (var PaymentMovment in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == PaymentMovment.Id);
                dtoCollection.Find(x => x.Id == PaymentMovment.Id).Amount = PaymentMovment.Amount + " " + PaymentMovment.Currency.ChildTranslatedCurrencys.FirstOrDefault(x => x.Language == lang).Name;

                //if (PaymentMovment.Vendor != null)
                //{
                //    ViewModel.SourceType = SourceType.vendor;
                //    ViewModel.Source = PaymentMovment.Vendor.ChildTranslatedVendors.First(x => x.Language == lang).Name;
                //}

                //if (PaymentMovment.AccountChart != null)
                //{
                //    ViewModel.SourceType = SourceType.AccountChart;
                //    ViewModel.Source = PaymentMovment.AccountChart.Code;
                //}

                ViewModel.PaymentMethod = PaymentMovment.ReceivingMethod.ChildTranslatedReceivingMethods.First(x => x.Language == lang).Name;
            }
            var result = new GenericCollectionViewModel<ListPaymentMovmentLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = _PaymentMovmentsRepository.GetCount(condition.Query),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            return result;
        }


        /// <summary>
        /// Gets a GenericCollectionViewModel of DonationViewModel by pagination.
        /// </summary>
        /// <returns></returns>
        public GenericCollectionViewModel<ListPaymentMovmentLightViewModel> GetReceiptModel(FinancialViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

            IQueryable<PaymentMovment> queryableData = this._PaymentMovmentsRepository.Get(condition);

            queryableData = queryableData.Where(x => x.ParentKeyPaymentMovmentId.HasValue == false);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.Date <= model.DateTo);

            if (model.AmountFrom.HasValue)
                queryableData = queryableData.Where(x => x.Amount >= model.AmountFrom);

            if (model.AmountTo.HasValue)
                queryableData = queryableData.Where(x => x.Amount <= model.AmountTo);

            if (model.Branch.HasValue)
                queryableData = queryableData.Where(x => x.BranchId == model.Branch);

            if (model.Payment.HasValue)
            {
                queryableData = queryableData.Where(x =>
                    x.ReceivingMethodId.HasValue && x.ReceivingMethodId.Value == model.Payment);
            }

            if (string.IsNullOrEmpty(model.DelegateManReciptNumber) == false)
                queryableData = queryableData.Where(x => x.DelegateManReciptNumber == model.DelegateManReciptNumber);

            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            foreach (var PaymentMovment in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == PaymentMovment.Id);
                ViewModel.Amount = PaymentMovment.Amount.ToString() + " " + PaymentMovment.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;

                var branch = PaymentMovment.Branch.ChildTranslatedBranchs.FirstOrDefault(x => x.Language == lang);
                if (branch != null)
                {
                    ViewModel.Branch = branch.Name;
                }

                //if (PaymentMovment.Vendor != null)
                //{
                //    ViewModel.SourceType = SourceType.vendor;
                //    ViewModel.Source = PaymentMovment.Vendor.ChildTranslatedVendors.First(x => x.Language == lang).Name;

                //}
                //if (PaymentMovment.AccountChart != null)
                //{
                //    ViewModel.SourceType = SourceType.AccountChart;
                //    string fullCode = PaymentMovment.AccountChart.FullCode;
                //    AccountChart translatedAccount = PaymentMovment.AccountChart.ChildTranslatedAccountCharts.FirstOrDefault(x => x.Language == lang);
                //    if (translatedAccount != null)
                //    {
                //        fullCode = fullCode + "-" + translatedAccount.Name;
                //    }
                //    ViewModel.Source = $"{fullCode}";

                //    //ViewModel.Source = PaymentMovment.AccountChart.Code;
                //}
                //if (PaymentMovment.Donator != null)
                //{
                //    ViewModel.SourceType = SourceType.Donator;
                //    dtoCollection.Find(x => x.Id == PaymentMovment.Id).Source = PaymentMovment.Donator.Name;
                //}

                if (PaymentMovment.ReceivingMethod != null)
                {
                    ViewModel.PaymentMethod = PaymentMovment.ReceivingMethod.ChildTranslatedReceivingMethods.First(x => x.Language == lang).Name; 
                }
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
                        //    dtoCollection = dtoCollection.Where(x => x.Amount.Equals(Convert.ToDecimal(item.Value))).ToList();
                        //    break;
                        default:
                            break;
                    }
                }
            }
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListPaymentMovmentLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }


        public AddPaymentMovmentViewModel Get(long id)
        {
            Language lang = this._languageService.CurrentLanguage;
            var entity = this._PaymentMovmentsRepository.Get(id);
            if (entity == null)
            {
                throw new ItemNotFoundException((int)statusCodes.notFound);
            }
            AddPaymentMovmentViewModel model = entity.ToAddModel();
            //if (entity.PaymentMovmentVendors.Count >0)
            //{
            //    model.SourceType = SourceType.vendor;
            //}
            //else if (entity.AccountChart != null)
            //{
            //    model.SourceType = SourceType.AccountChart;
            //}
            //else if (entity.DonatorId != null)
            //{
            //    model.SourceType = SourceType.Donator;
            //    model.DonatoinTypesLevel = new List<long>();
            //    model.DonatoinTypesLevel.Add(entity.DonationTypeId.Value);
            //    var d = entity.DonationType;
            //    while (d.ParentId.HasValue)
            //    {
            //        var e = this._donationTypesRepository.Get().FirstOrDefault(x => x.Id == d.ParentId);
            //        model.DonatoinTypesLevel.Add(e.Id);
            //        d = e;
            //    }
            //}
            return model;
        }

        public List<string> GetPaymentCodes()
        {
            return this._PaymentMovmentsRepository.Get().Where(x => x.ParentKeyPaymentMovment == null).Select(x => x.Code).ToList();
        }


        public AddPaymentMovmentViewModel Update(AddPaymentMovmentViewModel model)
        {
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);

            var ar = this._PaymentMovmentsRepository.Get(null).Where(x =>
            x.ParentKeyPaymentMovmentId == model.Id && x.Language == Language.Arabic).FirstOrDefault();

            var en = this._PaymentMovmentsRepository.Get(null).Where(x =>
                x.ParentKeyPaymentMovmentId == model.Id && x.Language == Language.English).FirstOrDefault();

            ar.Description = model.DescriptionAR;
            en.Description = model.DescriptionEN;

            this._PaymentMovmentsRepository.Update(ar);
            this._PaymentMovmentsRepository.Update(en);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion


            return model;
        }

#if detailsDiffrentModel
        public DetailsPaymentMovmentViewModel Get(long id)
        {
            Language lang = this._languageService.CurrentLanguage;
            var entity = this._PaymentMovmentsRepository.Get(id);
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
            if (entity.DelegateMan != null)
            {
                model.DelegateManName = entity.DelegateMan.Name;
            }
            
            model.DescriptionAR = entity.ChildTranslatedPaymentMovments.FirstOrDefault(x => x.Language == Language.Arabic).Description;
            model.DescriptionEN = entity.ChildTranslatedPaymentMovments.FirstOrDefault(x => x.Language == Language.English).Description;


        #region Determine Source Type
            if (entity.AccountChart != null)
            {
                model.SourceType = SourceType.AccountChart;
            }
            else if (entity.Vendor != null)
            {
                model.SourceType = SourceType.vendor;
            }

        
            if (entity.Vendor != null)
            {
                model.VendorName = entity.Vendor.ChildTranslatedVendors.FirstOrDefault(x => x.Language == lang).Name;
                model.VenderAccountNumber = entity.Vendor.AccountChart.Code;
            }
        #endregion

        #region collections
            if (entity.PaymentMovmentCostCenters != null && entity.PaymentMovmentCostCenters.Count != 0)
            {
                List<DetailsPaymentMovmentCostCenterViewModel> CostCenterList = new List<DetailsPaymentMovmentCostCenterViewModel>();
                foreach (var CostCenter in entity.PaymentMovmentCostCenters)
                {
                    DetailsPaymentMovmentCostCenterViewModel cs = new DetailsPaymentMovmentCostCenterViewModel();
                    cs.Name = CostCenter.CostCenter.ChildTranslatedCostCenters.FirstOrDefault(x => x.Language == lang).Name;
                    cs.Amount = CostCenter.Amount;
                    cs.Id = CostCenter.CostCenter.Id;
                    CostCenterList.Add(cs);
                }
                model.CostCenters = CostCenterList;
            }

            if (entity.PaymentMovmentInventorys != null && entity.PaymentMovmentInventorys.Count != 0)
            {
                List<DetailsPaymentMovmentInventoryViewModel> InventoriesList = new List<DetailsPaymentMovmentInventoryViewModel>();

                foreach (var Inventory in entity.PaymentMovmentInventorys)
                {
                    DetailsPaymentMovmentInventoryViewModel inv = new DetailsPaymentMovmentInventoryViewModel();
                    inv.Name = Inventory.Inventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == lang).Name;
                    inv.Amount = Inventory.Amount;
                    inv.Id = Inventory.Inventory.Id;
                    InventoriesList.Add(inv);
                }
                model.Inventorys = InventoriesList;
            }

           
        #endregion



            return model;
        }
#endif

#if condition
        /// <summary>
        /// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<PaymentMovmentViewModel> Get(ConditionFilter<PaymentMovment, long> condition)
		{
			var entityCollection = this._PaymentMovmentsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PaymentMovmentViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PaymentMovmentLightViewModel> GetLightModel(ConditionFilter<PaymentMovment, long> condition)
		{
			var entityCollection = this._PaymentMovmentsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PaymentMovmentLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PaymentMovmentViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PaymentMovmentLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._PaymentMovmentsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PaymentMovmentLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a PaymentMovmentViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PaymentMovmentViewModel Get(long id)
		{
			var entity = this._PaymentMovmentsRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}
        /// <summary>
		/// Gets a PaymentMovmentViewModel Lookup.
		/// </summary>
		/// <param></param>
		/// <returns> List<PaymentMovmentLightViewModel> </returns>
        public List<PaymentMovmentLightViewModel> GetLookUp()
        {
            var lang = this._languageService.CurrentLanguage;

            ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
            {
                Query = (item =>
                item.Language == lang)
            };
            var entityCollection = this._PaymentMovmentsRepository.Get(condition).ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            return lookup;
        }

        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<PaymentMovmentViewModel> Add(IEnumerable<PaymentMovmentViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PaymentMovmentsRepository.Add(entityCollection).ToList();

        #region Commit Changes
			this._unitOfWork.Commit();
        #endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}
#endif
        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AddPaymentMovmentViewModel Add(AddPaymentMovmentViewModel model)
        {
            if (model.Journal == null)
            {
                this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);

                ValidateAddViewModel(model);

                if (model.DelegateManId.HasValue && string.IsNullOrEmpty(model.DelegateManReciptNumber) == false && model.DocumentId.HasValue)
                {
                    ClosedReceiptViewModel closedReceipt = new ClosedReceiptViewModel
                    {
                        DocumentId = model.DocumentId.Value,
                        ReceiptNumber = int.Parse(model.DelegateManReciptNumber)
                    };
                    this._closedReceiptService.Add(closedReceipt);
                }

                var entity = model.ToEntity();
                DateTime CurrentDate = DateTime.Now;
                decimal CalculatedAmount = 0;

                if (model.VendorId != null)
                {
                    foreach (var Vendor in model.VendorId)
                    {
                        entity.PaymentMovmentVendors.Add(new PaymentMovmentVendor { CreationDate = DateTime.Now, VendorId = Vendor, PaymentMovment = entity });
                    } 
                }


                if (model.AccountChartId != null)
                {
                    foreach (var accountChart in model.AccountChartId)
                    {
                        entity.PaymentMovmentAccountCharts.Add(new PaymentMovmentAccountChart { CreationDate = DateTime.Now, AccountChartId = accountChart, PaymentMovment = entity });
                    }
                }

                if (model.DonatorId != null)
                {
                    foreach (var donatorId in model.DonatorId)
                    {
                        entity.PaymentMovementDonators.Add(new PaymentMovementDonator { CreationDate = DateTime.Now, DonatorId = donatorId, PaymentMovment = entity });
                    }
                }

                if (model.NotificationsDiscount != null)
                {
                    foreach (var notificationDiscount in model.NotificationsDiscount)
                    {
                        entity.PaymentMovmentNotificationDiscounts.Add(new PaymentMovmentNotificationDiscount { CreationDate = DateTime.Now,DiscountAmount=notificationDiscount.DiscountAmount
                            ,DiscountPercentageId= notificationDiscount.DiscountPercentageId,InvoiceAmount= notificationDiscount.InvoiceAmount,NotificationReceiptNumber= notificationDiscount.NotificationReceiptNumber, PaymentMovment = entity });
                    }
                }




                //if (model.SourceType == SourceType.Donator)
                //{
                //    if (model.Donator != null && model.DonatorId == null)
                //    {
                //        //in case of new Donator 
                //        Donator Donator = new Donator
                //        {
                //            Name = model.Donator.Name,
                //            //	AccountChartId = model.Donator.accountChartId,
                //            //Phone = model.Donator.phone,
                //            CreationDate = CurrentDate
                //        };
                //        if (model.Donator.AccountChartId == 0)
                //        {
                //            Donator.AccountChartId = null;
                //        }
                //        else
                //        {
                //            Donator.AccountChartId = model.Donator.AccountChartId;
                //        }
                //        //ConditionFilter<AccountChart, long> condition = new ConditionFilter<AccountChart, long>
                //        //{
                //        //    Query = x => x.Code == "DonatorAccount"
                //        //};
                //        //Donator.AccountChartId = _AccountChartsRepository.Get(condition).FirstOrDefault().Id;
                //        //entity.Donator = Donator;
                //        Donator = this._DonatorRepository.Add(Donator);

                //        SaveNewDonatorData(model.Donator, Donator.Id);
                //       // entity.DonatorId = Donator.Id;
                //    }
                //}

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

                    if (string.IsNullOrEmpty(model.LiquidationNumber))
                    {
                        if (entity.SafeAccountChartId.HasValue)
                        {
                            //var safe = this._safesRepository.Get(entity.SafeId.Value);


                            //if (entity.AccountChart != null)
                            //    accountChart = entity.AccountChart;
                            //else
                            //    accountChart = this._accountChartsRepository.Get(entity.SafeAccountChartId.Value);
                        }
                        else if (entity.ChequeToBankId.HasValue)
                        {
                            var bank = this._banksRepository.Get(entity.ChequeToBankId.Value);

                            if (bank.BankAccountCharts.Count == 0)
                                throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                            //if (bank.AccountChart != null)
                            //    accountChart = bank.AccountChart;
                            //else
                            //    accountChart = this._accountChartsRepository.Get(bank.AccountChartId.Value);
                            var acc = this._bankAccountChartRepository.Get().Where(x => x.BankId == bank.Id).FirstOrDefault(x => x.AccountChart.CurrencyId == entity.CurrencyId);
                            //entity.
                            if (acc != null)
                                accountChart = acc.AccountChart;
                            else
                            {
                                throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                            }
                        }
                        else if (entity.BankId.HasValue)
                        {
                            var bank = this._banksRepository.Get(entity.BankId.Value);

                            if (bank.BankAccountCharts.Count == 0)
                                throw new GeneralException((int)ErrorCodeEnum.ThisBankDonotHaveAccountChart);

                            //if (bank.AccountChart != null)
                            //    accountChart = bank.AccountChart;
                            //else
                            //    accountChart = this._accountChartsRepository.Get(bank.AccountChartId.Value);
                            var acc = this._bankAccountChartRepository.Get().Where(x => x.BankId == bank.Id).FirstOrDefault(x => x.AccountChart.CurrencyId == entity.CurrencyId);

                            if (acc != null)
                                accountChart = acc.AccountChart;
                            else
                            {
                                throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                            }
                        }
                        entity.ReceivingMethodId = null;
                    }

                    if (entity.CurrencyId != accountChart.CurrencyId)
                    {
                        throw new GeneralException((int)ErrorCodeEnum.AccountCurrencyMismatch);
                    }

                    #endregion

                    #region الطرف المدين
                    //if (entity.VendorId.HasValue)
                    //{
                    //    var vendor = this._vendorsRepository.Get(entity.VendorId.Value);

                    //    if (vendor.AccountChart != null)
                    //        accountChart = vendor.AccountChart;
                    //    else
                    //        accountChart = this._accountChartsRepository.Get(vendor.AccountChartId.Value);
                    //}
                    //if (entity.AccountChartId.HasValue)
                    //{
                    //    accountChart = this._accountChartsRepository.Get(entity.AccountChartId.Value);
                    //}

                    if (entity.CurrencyId != accountChart.CurrencyId)
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
                            PaymentCase PaymentCase = new PaymentCase();
                            PaymentCase.CaseId = CheckCase;
                            PaymentCase.Amount = Case.Amount;
                            PaymentCase.CreationDate = CurrentDate;
                            entity.PaymentCases.Add(PaymentCase);
                        }
                        else
                        {
                            Case NewCase = new Case();
                            NewCase.Name = Case.Name;
                            NewCase.ExternalId = Case.CaseId;
                            NewCase.CreationDate = CurrentDate;
                            PaymentCase PaymentCase = new PaymentCase();
                            PaymentCase.CreationDate = CurrentDate;
                            PaymentCase.Case = NewCase;
                            PaymentCase.Amount = Case.Amount;
                            entity.PaymentCases.Add(PaymentCase);
                        }

                    }
                }


                #endregion

                #region translation
                entity.Description = "";
                entity.Language = null;

                PaymentMovment PaymentMovmentAr = new PaymentMovment();
                PaymentMovmentAr.Description = model.DescriptionAR;
                PaymentMovmentAr.Language = Language.Arabic;
                PaymentMovmentAr.CreationDate = CurrentDate;
                PaymentMovmentAr.Date = CurrentDate;

                PaymentMovment PaymentMovmentEn = new PaymentMovment();
                PaymentMovmentEn.Description = model.DescriptionEN;
                PaymentMovmentEn.Language = Language.English;
                PaymentMovmentEn.CreationDate = CurrentDate;
                PaymentMovmentEn.Date = CurrentDate;

                entity.ChildTranslatedPaymentMovments.Add(PaymentMovmentAr);
                entity.ChildTranslatedPaymentMovments.Add(PaymentMovmentEn);
                #endregion

                #region new Donation

                #endregion
                if (string.IsNullOrEmpty(model.LiquidationNumber) == false)
                    entity.ReceivingMethodId = null;

                entity = this._PaymentMovmentsRepository.Add(entity);


                #region Commit Changes
                this._unitOfWork.Commit();
                //entity.code = entity.Id.ToString();
                //entity = this._PaymentMovmentsRepository.Update(entity);
                //this._unitOfWork.Commit();
                //PaymentMovmentAddTransAction(entity);
                #endregion

                #region Save Donator Info If New Donator Region
                if (model.Donator != null && model.DonatorId == null)
                {
                    //SaveNewDonatorData(model.Donator, entity.Donator.Id);
                }
                #endregion

                #region  Generate New ReciptNumber
                if (string.IsNullOrEmpty(entity.ReciptNumber) == true)
                {
                    entity.ReciptNumber = this.GenerateNewReciptNumber();
                }

                entity = this._PaymentMovmentsRepository.Update(entity);
                #endregion

                #region Generate New Code
                try
                {
                    ConditionFilter<PaymentMovment, long> condition = new ConditionFilter<PaymentMovment, long>
                    {
                        Query = x =>
                            x.ParentKeyPaymentMovmentId == null &&
                            string.IsNullOrEmpty(x.Code) == false
                            ,
                        Order = Order.Descending
                    };

                    var z = this._PaymentMovmentsRepository.Get(condition);
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

                entity = this._PaymentMovmentsRepository.Update(entity);

                this._unitOfWork.Commit();
                #endregion

                model.Id = entity.Id;
                model.code = entity.Code;

                //this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.PaymentMovement);
                model.Journal = this._journalPostingsService.Post(model.Id, MovementType.PaymentMovement);

                model.Journal.Date = model.Date;

                foreach (var Journal in model.Journal.journalDetails)
                {
                    Journal.AccountFullCode = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == Journal.AccountId).FullCode;
                }
                //model.Journal.DescriptionAr = model.DescriptionAR;
                //model.Journal.DescriptionEn = model.DescriptionEN;

            }
            else if (model.Journal.PostingStatus == PostingStatus.Approved)
            {
                this._journalsService.AddJournal(model.Journal, PostingStatus.NeedAprove);

                var entity = this._PaymentMovmentsRepository.Get(model.Id);
                if (entity != null)
                {
                    entity.IsPosted = false;
                    entity.PostingDate = DateTime.Now;
                    entity.PostedByUserId = this._currentUserService.CurrentUserId;
                    entity = this._PaymentMovmentsRepository.Update(entity);
                }

                this._unitOfWork.Commit();
            }
            else if (model.Journal.PostingStatus == PostingStatus.Rejected)
            {

            }

            return model;
        }

        public string GenerateNewReciptNumber()
        {
            DateTime now = DateTime.Now;
            string year = string.Format("{0:d4}", now.Year);
            string month = year.Substring(3, 1) + year.Substring(2, 1); //string.Format("{0:d2}", now.Month);
            string day = year.Substring(1, 1) + year.Substring(0, 1);//string.Format("{0:d2}", now.Day);
            string count = string.Format("{0:d6}", 1);
            // xxxx xx xx xxxxxx
            string newReciptNumber = $"{year}{month}{day}{count}";

            try
            {
                var latest = this._PaymentMovmentsRepository
                    .Get(null)
                    .OrderByDescending(item => item.Id)
                    .Where(x => x.ParentKeyPaymentMovmentId == null)
                    .FirstOrDefault();

                if (latest != null &&
                    string.IsNullOrEmpty(latest.ReciptNumber) == false)
                {
                    string latestYear = latest.ReciptNumber.Substring(0, 4);

                    if (year == latestYear)
                    {
                        try
                        {
                            string latestCountString = latest.ReciptNumber.Substring(8);

                            int latestCount = int.Parse(latestCountString);
                            latestCount++;
                            count = string.Format("{0:d6}", latestCount);
                            newReciptNumber = $"{year}{month}{day}{count}";
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch
            {

            }

            return newReciptNumber;
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

        //        public void PaymentMovmentAddTransAction(PaymentMovment model)
        //        {

        //            string SourceType = "";
        //            long SourceTypeId = 0;
        //            DateTime CurrentDate = DateTime.Now;

        //            DateTime CuurentDate = DateTime.Now;

        //            if (model.VendorId != null)
        //            {
        //                ConditionFilter<Vendor, long> Rcondition = new ConditionFilter<Vendor, long>();
        //                Rcondition.Query = x => x.Id == model.VendorId;
        //                var VendorAccountChartId = _vendorsRepository.Get(Rcondition).FirstOrDefault().AccountChartId;
        //                SourceType = "Vendor";
        //                SourceTypeId =(long)VendorAccountChartId;
        //            }

        //            if (model.AccountChartId != null)
        //            {
        //                SourceType = "AccountChart";
        //                SourceTypeId = (long)model.AccountChartId;
        //            }
        //            Transaction MainTranaction = new Transaction();
        //            MainTranaction.CreationDate = CuurentDate;
        //            MainTranaction.Amount = model.Amount;
        //            //MainTranaction.FromObjectId = SourceTypeId;
        //            //MainTranaction.FromObjectType = SourceType;
        //            MainTranaction.CreationDate = CurrentDate;
        //            //transaction.ToObjectId = Case.CaseId;
        //            //transaction.ToObjectType = "Case";
        //            //Case Of PaymentMovment Case


        //            //Case Of PaymentMovment CostCenter
        //            if (model.PaymentMovmentCostCenters != null && model.PaymentMovmentCostCenters.Count != 0)
        //            {
        //                foreach (PaymentMovmentCostCenter CostCenter in model.PaymentMovmentCostCenters)
        //                {

        //                    TranactionDetails transaction = new TranactionDetails();
        //                    transaction.CreationDate = CuurentDate;
        //                    transaction.Amount = CostCenter.Amount;
        //                    transaction.FromObjectId = SourceTypeId;
        //                    transaction.FromObjectType = SourceType;
        //                    ConditionFilter<CostCenter, long> condition = new ConditionFilter<CostCenter, long>
        //                    {
        //                        Query = x => x.Id == CostCenter.CostCenterId
        //                    };

        //                    var CostCenterChartId = this._CostCentersRepository.Get(condition).FirstOrDefault().AccountChartId;
        //                    transaction.ToObjectId = CostCenterChartId;
        //                    transaction.ToObjectType = "CostCenter";
        //                    transaction.CreationDate = CurrentDate;
        //                    // _TransactionsRepository.Add(transaction);
        //                   // MainTranaction.TranactionsDetails.Add(transaction);
        //                }
        //            }



        //            //Case Of PaymentMovmentInventorys
        //            if (model.PaymentMovmentInventorys != null && model.PaymentMovmentInventorys.Count != 0)
        //            {
        //                foreach (PaymentMovmentInventory PaymentMovmentInventory in model.PaymentMovmentInventorys)
        //                {
        //                    TranactionDetails transaction = new TranactionDetails();

        //                    transaction.CreationDate = CuurentDate;
        //                    transaction.Amount = PaymentMovmentInventory.Amount;
        //                    transaction.FromObjectId = SourceTypeId;
        //                    transaction.FromObjectType = SourceType;
        //                    ConditionFilter<Inventory, long> condition = new ConditionFilter<Inventory, long>
        //                    {
        //                        Query = x => x.Id == PaymentMovmentInventory.InventoryId
        //                    };
        //                    var InventoryChartId = this._InventorysRepository.Get(condition).FirstOrDefault().AccountChartId;
        //                    transaction.ToObjectId = InventoryChartId;
        //                    transaction.ToObjectType = "Inventory";
        //                    transaction.CreationDate = CurrentDate;
        //                   // MainTranaction.TranactionsDetails.Add(transaction);
        //                }
        //            }

        //            this._TransactionsRepository.Add(MainTranaction);

        //#region Commit Changes
        //            this._unitOfWork.Commit();
        //#endregion
        //        }

#if condtionMethodCompleted
        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<PaymentMovmentViewModel> Update(IEnumerable<PaymentMovmentViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._PaymentMovmentsRepository.Update(entityCollection).ToList();

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
		public PaymentMovmentViewModel Update(PaymentMovmentViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._PaymentMovmentsRepository.Update(entity);

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
		public void Delete(IEnumerable<PaymentMovmentViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._PaymentMovmentsRepository.Delete(entityCollection);

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
			this._PaymentMovmentsRepository.Delete(collection);

        #region Commit Changes
			this._unitOfWork.Commit();
        #endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(PaymentMovmentViewModel model)
		{
			var entity = model.ToEntity();
			this._PaymentMovmentsRepository.Delete(entity);

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
			var result = this._PaymentMovmentsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

        #region Commit Changes
			this._unitOfWork.Commit();
        #endregion
		}
#endif


        #endregion
    }
}
