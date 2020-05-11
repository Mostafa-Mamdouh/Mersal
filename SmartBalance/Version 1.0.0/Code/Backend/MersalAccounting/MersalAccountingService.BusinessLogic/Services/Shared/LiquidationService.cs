#region using...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    public class LiquidationService : ILiquidationService
    {
        #region Data Members
        private readonly ILiquidationRepository _LiquidationsRepository;
        private readonly IJournalPostingsService _journalPostingsService;
        private readonly IJournalsService _journalsService;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITestamentRepository _testamentRepository;
        private readonly IAdvancesRepository _advancesRepository;
        private readonly ILiquidationDetailRepository _liquidationDetailRepository;
        private readonly IPaymentMovmentsService _paymentMovmentsService;
        //private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type LiquidationsService.
        /// </summary>
        /// <param name="LiquidationsRepository"></param>
        /// <param name="unitOfWork"></param>
        public LiquidationService(
            ILiquidationRepository LiquidationsRepository,
            IJournalPostingsService journalPostingsService,
            IJournalsService journalsService,
            IAccountChartsRepository accountChartsRepository,
            ICurrentUserService currentUserService,
            ITestamentRepository testamentRepository,
            IAdvancesRepository advancesRepository,
            ILiquidationDetailRepository liquidationDetailRepository,
            IPaymentMovmentsService paymentMovmentsService,
            //ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._LiquidationsRepository = LiquidationsRepository;
            this._journalPostingsService = journalPostingsService;
            this._journalsService = journalsService;
            this._accountChartsRepository = accountChartsRepository;
            this._currentUserService = currentUserService;
            this._testamentRepository = testamentRepository;
            this._advancesRepository = advancesRepository;
            this._liquidationDetailRepository = liquidationDetailRepository;
            this._paymentMovmentsService = paymentMovmentsService;
            //this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">Liquidation view model</param>
        public void ThrowExceptionIfExist(LiquidationViewModel model)
        {
            ConditionFilter<Liquidation, long> condition = new ConditionFilter<Liquidation, long>
            {
                Query = (entity =>
                    entity.Id != model.Id)
            };
            var existEntity = this._LiquidationsRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException();
        }

        //public GenericCollectionViewModel<ListLiquidationsLightViewModel> GetByFilter(LiquidationFilterViewModel model)
        //{
        //    var lang = this._languageService.CurrentLanguage;
        //    ConditionFilter<Liquidation, int> condition = new ConditionFilter<Liquidation, int>()
        //    {
        //        Order = Order.Descending
        //    };

        //    if (model.Sort?.Count > 0)
        //    {
        //        if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
        //    }

        //    //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
        //    //if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

        //    // The IQueryable data to query.  
        //    IQueryable<Liquidation> queryableData = this._LiquidationsRepository.Get(condition);

        //    queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyLiquidation != null);

        //    if (string.IsNullOrEmpty(model.Name) == false)
        //        queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

        //    var entityCollection = queryableData.ToList();
        //    var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

        //    //foreach (var item in entityCollection)
        //    //{
        //    //	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyBrandId);
        //    //	//ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
        //    //	//if (item.ParentKeyBankMovement.Bank != null)
        //    //	//{
        //    //	//	ViewModel.BankName = item.ParentKeyBankMovement.Bank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
        //    //	//}
        //    //	//if (item.ParentKeyBankMovement.JournalType != null)
        //    //	//{
        //    //	//	ViewModel.JournalTypeName = item.ParentKeyBankMovement.JournalType.ChildTranslatedJournalTypes.First(x => x.Language == lang).Name; ;
        //    //	//}
        //    //}

        //    var total = dtoCollection.Count();
        //    dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
        //    var result = new GenericCollectionViewModel<ListDiscountPercentegesLightViewModel>
        //    {
        //        Collection = dtoCollection,
        //        TotalCount = total,
        //        PageIndex = model.PageIndex,
        //        PageSize = model.PageSize
        //    };

        //    return result;
        //}

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<LiquidationViewModel> Get(ConditionFilter<Liquidation, long> condition)
        {
            var entityCollection = this._LiquidationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<LiquidationViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<LiquidationViewModel> Get(int? pageIndex, int? pageSize)
        {
            //var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Liquidation, long> condition = new ConditionFilter<Liquidation, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
                //Query = (item =>
                //    item.Language == lang)
            };
            var entityCollection = this._LiquidationsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<LiquidationViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        //public GenericCollectionViewModel<LiquidationLightViewModel> GetLightModel(ConditionFilter<Liquidation, int> condition)
        //{
        //    var entityCollection = this._LiquidationsRepository.Get(condition).ToList();
        //    var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
        //    var result = new GenericCollectionViewModel<LiquidationLightViewModel>
        //    {
        //        Collection = dtoCollection,
        //        TotalCount = dtoCollection.Count,
        //        PageIndex = condition.PageIndex,
        //        PageSize = condition.PageSize
        //    };

        //    return result;
        //}

        /// <summary>
        /// Gets a GenericCollectionViewModel of LiquidationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //public GenericCollectionViewModel<LiquidationLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        //{
        //    var lang = this._languageService.CurrentLanguage;
        //    ConditionFilter<Liquidation, int> condition = new ConditionFilter<Liquidation, int>
        //    {
        //        PageIndex = pageIndex,
        //        PageSize = pageSize,
        //        Query = (item =>
        //            item.Language == lang)
        //    };
        //    var entityCollection = this._LiquidationsRepository.Get(condition).ToList();
        //    var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
        //    var result = new GenericCollectionViewModel<LiquidationLightViewModel>
        //    {
        //        Collection = dtoCollection,
        //        TotalCount = dtoCollection.Count,
        //        PageIndex = pageIndex,
        //        PageSize = pageSize
        //    };

        //    return result;
        //}

        /// <summary>
        /// Gets a LiquidationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LiquidationViewModel Get(long id)
        {
            //Language lang = this._languageService.CurrentLanguage;
            var entity = this._LiquidationsRepository.Get(id);

            var model = entity.ToModel();

            return model;
        }

        public List<LiquidationDetailViewModel> GetUnliquidation(long costCenterId, long? liquidationType, bool? isClosed)
        {
            IQueryable<Advance> advances = this._advancesRepository.Get().Where(x => x.CostCenterId == costCenterId);

            if(isClosed.HasValue)
            {
                advances = advances.Where(x => x.IsClosed == isClosed);
            }

            if(liquidationType.HasValue)
            {
                advances = advances.Where(x => x.Testament.AdvancesTypeId == liquidationType);
            }

            return advances.ToList().Select(x => x.ToLiquidationDetailModel()).ToList();
        }

        public string GenerateNewCode(string lastCode)
        {
            long newCode = 0;
            try
            {
                if (string.IsNullOrEmpty(lastCode) || lastCode == "null")
                {
                    ConditionFilter<LiquidationDetail, long> condition = new ConditionFilter<LiquidationDetail, long>
                    {
                        Query = x =>
                            string.IsNullOrEmpty(x.LiquidationNumber) == false
                            ,
                        Order = Order.Descending
                    };

                    var z = this._liquidationDetailRepository.Get(condition);
                    var lastEntity = z.FirstOrDefault();
                    newCode = 1;

                    if (lastEntity != null)
                    {
                        try
                        {
                            lastCode = lastEntity.LiquidationNumber;
                        }
                        catch
                        {
                            newCode = lastEntity.Id;
                        }
                    }
                }

                newCode = long.Parse(lastCode) + 1;

                //entity.Code = newCode.ToString();
            }
            catch
            {
                //entity.Code = entity.Id.ToString();
                newCode = 1;
            }
            return newCode.ToString();
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<LiquidationViewModel> Add(IEnumerable<LiquidationViewModel> collection)
        {
            //foreach (var model in collection)
            //{
            //    this.ThrowExceptionIfExist(model);
            //}

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._LiquidationsRepository.Add(entityCollection).ToList();

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
        public LiquidationViewModel Add(LiquidationViewModel model)
        {
            //this.ThrowExceptionIfExist(model);

            if (model.Journal == null)
            {
                var entity = model.ToEntity();

                foreach (var item in entity.LiquidationDetails)
                {
                    item.CreationDate = DateTime.Now;
                    var advance = this._advancesRepository.Get().FirstOrDefault(x => x.Id == item.AdvanceId);
                    if (advance != null)
                    {
                        advance.CurrentAmount -= item.Amount;
                        if (advance.CurrentAmount <= 0)
                        {
                            advance.IsClosed = true;
                        }
                        this._advancesRepository.Update(advance); 
                    }
                }

                entity = this._LiquidationsRepository.Add(entity);


                #region Commit Changes
                this._unitOfWork.Commit();
                #endregion
                model.Id = entity.Id;

                //this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.PaymentMovement);
                model.Journal = this._journalPostingsService.Post(model.Id, MovementType.Liquidation);

                if (model.PaymentMovements != null)
                {
                    foreach (var paymentMovement in model.PaymentMovements)
                    {
                        var journals = this._paymentMovmentsService.Add(paymentMovement).Journal.journalDetails.Where(x => x.IsCreditor == false);

                        foreach (var journal in journals)
                        {
                            model.Journal.journalDetails.Add(journal);
                        }
                    }
                }

                model.Journal.Date = entity.CreationDate;

                foreach (var Journal in model.Journal.journalDetails)
                {
                    Journal.AccountFullCode = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == Journal.AccountId)?.FullCode;
                }
            }
            else if(model.Journal.PostingStatus == MersalAccountingService.Common.Enums.PostingStatus.Approved)
            {
                this._journalsService.AddJournal(model.Journal, PostingStatus.NeedAprove);
                var entity = this._LiquidationsRepository.Get(model.Id);
                if (entity != null)
                {
                    entity.IsPosted = false;
                    entity.PostingDate = DateTime.Now;
                    entity.PostedByUserId = this._currentUserService.CurrentUserId;
                    entity = this._LiquidationsRepository.Update(entity);
                }

                this._unitOfWork.Commit();
            }
            else if(model.Journal.PostingStatus == MersalAccountingService.Common.Enums.PostingStatus.Rejected)
            {

            }
            
            return model;
        }

        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<LiquidationViewModel> Update(IEnumerable<LiquidationViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._LiquidationsRepository.Update(entityCollection).ToList();

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
        public LiquidationViewModel Update(LiquidationViewModel model)
        {
            //this.ThrowExceptionIfExist(model);

            var entity = this._LiquidationsRepository.Get(model.Id);

            entity = this._LiquidationsRepository.Update(entity);

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
        public void Delete(IEnumerable<LiquidationViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._LiquidationsRepository.Delete(entityCollection);

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
            this._LiquidationsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(LiquidationViewModel model)
        {
            var entity = model.ToEntity();
            this._LiquidationsRepository.Delete(entity);

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
            var result = this._LiquidationsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
