#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
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
    /// Provides InventoryMovement service for 
    /// business functionality.
    /// </summary>
    public class InventoryMovementsService : IInventoryMovementsService
    {
        #region Data Members
        private readonly IInventoryMovementTypeRepository _inventoryMovementTypeRepository;
        private readonly IJournalPostingsService _journalPostingsService;
        private readonly IInventoryMovementsRepository _InventoryMovementsRepository;
        private readonly IProductsRepository _ProductsRepository;
        private readonly IInventoryMovementCostCenterRepository _InventoryMovementCostCentersRepository;
        private readonly IInventoryProductHistoryRepository _inventoryProductHistoryRepository;
        private readonly IBrandsRepository _brandsRepository;
        private readonly IClosedMonthsService _closedMonthsService;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly IJournalsRepository _journalsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryMovementsService.
        /// </summary>
        /// <param name="journalPostingsService"></param>
        /// <param name="InventoryMovementsRepository"></param>
        /// <param name="languageService"></param>
        /// <param name="unitOfWork"></param>
        public InventoryMovementsService(
            IInventoryMovementTypeRepository inventoryMovementTypeRepository,
            IJournalPostingsService journalPostingsService,
            IInventoryMovementsRepository InventoryMovementsRepository,
            IInventoryMovementCostCenterRepository InventoryMovementCostCentersRepository,
            ILanguageService languageService,
            IProductsRepository ProductsRepository,
            IInventoryProductHistoryRepository inventoryProductHistoryRepository,
            IBrandsRepository brandsRepository,
            IClosedMonthsService closedMonthsService,
            IAccountChartsRepository accountChartsRepository,
            IJournalsRepository journalsRepository,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork)
        {
            this._inventoryMovementTypeRepository = inventoryMovementTypeRepository;
            this._journalPostingsService = journalPostingsService;
            this._InventoryMovementsRepository = InventoryMovementsRepository;
            this._InventoryMovementCostCentersRepository = InventoryMovementCostCentersRepository;
            this._languageService = languageService;
            this._ProductsRepository = ProductsRepository;
            this._inventoryProductHistoryRepository = inventoryProductHistoryRepository;
            this._brandsRepository = brandsRepository;
            this._closedMonthsService = closedMonthsService;
            this._accountChartsRepository = accountChartsRepository;
            this._journalsRepository = journalsRepository;
            this._currentUserService = currentUserService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">InventoryMovement view model</param>
        public void ThrowExceptionIfExist(InventoryMovementViewModel model)
        {
            ConditionFilter<InventoryMovement, long> condition = new ConditionFilter<InventoryMovement, long>
            {
                Query = (entity =>
                    entity.Code == model.Code &&
                    entity.Id != model.Id)
            };
            var existEntity = this._InventoryMovementsRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException();
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryMovementViewModel> Get(ConditionFilter<InventoryMovement, long> condition)
        {
            var entityCollection = this._InventoryMovementsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<InventoryMovementViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryMovementViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<InventoryMovement, long> condition = new ConditionFilter<InventoryMovement, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._InventoryMovementsRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<InventoryMovementViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryMovementLightViewModel> GetLightModel(ConditionFilter<InventoryMovement, long> condition)
        {
            var entityCollection = this._InventoryMovementsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<InventoryMovementLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryMovementViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryMovementLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<InventoryMovement, long> condition = new ConditionFilter<InventoryMovement, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._InventoryMovementsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<InventoryMovementLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a InventoryMovementViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InventoryMovementViewModel Get(long id)
        {
            var entity = this._InventoryMovementsRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<InventoryMovementViewModel> Add(IEnumerable<InventoryMovementViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._InventoryMovementsRepository.Add(entityCollection).ToList();

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
        public InventoryMovementViewModel Add(InventoryMovementViewModel model)
        {
            if (model.Journal == null)
            {
                this.ThrowExceptionIfExist(model);
                this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

                var entity = model.ToEntity();
                entity = this._InventoryMovementsRepository.Add(entity);

                #region Commit Changes
                this._unitOfWork.Commit();
                #endregion

                model = entity.ToModel();

                if (model.InventoryMovementTypeId == (int)InventoryMovementTypeEnum.InventoryOut)
                {
                    model.Journal = this._journalPostingsService.Post(model.Id, MovementType.BankMovement);

                    model.Journal.Date = model.Date.Value;

                    foreach (var Journal in model.Journal.journalDetails)
                    {
                        Journal.AccountFullCode = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == Journal.AccountId).FullCode;
                    }
                    //model.Journal.DescriptionAr = model.DescriptionAr;
                    //model.Journal.DescriptionEn = model.DescriptionEn;
                }
                else
                {
                    this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.StoreMovement);
                }

                
            }
            else if(model.Journal.PostingStatus == PostingStatus.Approved)
            {
                model.Journal.PostingStatus = PostingStatus.NeedAprove;
                Journal journal = model.Journal.ToEntity();
                journal = this._journalsRepository.Add(journal);

                Journal journalAr = new Journal
                {
                    Description = model.Journal.DescriptionAr,
                    Language = Language.Arabic,
                    ParentKeyJournal = journal
                };
                journalAr = this._journalsRepository.Add(journalAr);
                journal.ChildTranslatedJournals.Add(journalAr);

                Journal journalEn = new Journal
                {
                    Description = model.Journal.DescriptionEn,
                    Language = Language.English,
                    ParentKeyJournal = journal
                };
                journalEn = this._journalsRepository.Add(journalEn);
                journal.ChildTranslatedJournals.Add(journalEn);
                var entity = this._InventoryMovementsRepository.Get(model.Id);
                entity.IsPosted = false;
                entity.PostingDate = DateTime.Now;
                entity.PostedByUserId = this._currentUserService.CurrentUserId;
                entity = this._InventoryMovementsRepository.Update(entity);
                this._unitOfWork.Commit();
            }
            else if(model.Journal.PostingStatus == PostingStatus.Rejected)
            {

            }
            return model;
        }

        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<InventoryMovementViewModel> Update(IEnumerable<InventoryMovementViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._InventoryMovementsRepository.Update(entityCollection).ToList();

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
        public InventoryMovementViewModel Update(InventoryMovementViewModel model)
        {
            this.ThrowExceptionIfExist(model);
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

            var entity = model.ToEntity();
            entity = this._InventoryMovementsRepository.Update(entity);

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
        public void Delete(IEnumerable<InventoryMovementViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._InventoryMovementsRepository.Delete(entityCollection);

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
            this._InventoryMovementsRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(InventoryMovementViewModel model)
        {
            var entity = model.ToEntity();
            this._InventoryMovementsRepository.Delete(entity);

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
            var result = this._InventoryMovementsRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        //public GenericCollectionViewModel<InventoryMovementLightViewModel> GetByFilters(InventoryMovementFilterViewModel model)
        //{
        //    var lang = this._languageService.CurrentLanguage;
        //    ConditionFilter<InventoryMovement, long> condition = new ConditionFilter<InventoryMovement, long>()
        //    {
        //        Order = Order.Descending
        //    };

        //    if (model.Sort?.Count > 0)
        //    {
        //        if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
        //    }

        //    //model.DateFrom = model.DateFrom.SetTimeToNow();
        //    model.DateTo = model.DateTo.SetTimeToNow();

        //    if (model.DateFrom == null && model.DateTo == null && model.Inventory == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryMovement == null);
        //    }
        //    else if (model.DateFrom != null && model.DateTo == null && model.Inventory != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryMovement == null && x.CreationDate >= model.DateFrom && x.InventoryId == model.Inventory);
        //    }
        //    else if (model.DateFrom != null && model.DateTo == null && model.Inventory == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryMovement == null && x.CreationDate >= model.DateFrom);
        //    }
        //    else if (model.DateFrom == null && model.DateTo != null && model.Inventory != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryMovement == null && x.CreationDate <= model.DateTo && x.InventoryId == model.Inventory);
        //    }
        //    else if (model.DateFrom == null && model.DateTo != null && model.Inventory == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryMovement == null && x.CreationDate <= model.DateTo);
        //    }

        //    else if (model.DateFrom != null && model.DateTo != null && model.Inventory == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryMovement == null && x.CreationDate >= model.DateFrom && x.CreationDate <= model.DateTo);
        //    }
        //    else if (model.DateFrom == null && model.DateTo == null && model.Inventory != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryMovement == null && x.InventoryId == model.Inventory);
        //    }
        //    else if (model.DateFrom != null && model.DateTo != null && model.Inventory != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryMovement == null && x.CreationDate >= model.DateFrom && x.CreationDate <= model.DateTo &&
        //                                x.InventoryId == model.Inventory);
        //    }

        //    var entityCollection = this._InventoryMovementsRepository.Get(condition).ToList();
        //    var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
        //    if (model.InventoryMovementTypeId != null)
        //    {
        //        entityCollection = entityCollection.Where(x => x.InventoryMovementTypeId == model.InventoryMovementTypeId).ToList();
        //    }
        //    foreach (var item in entityCollection)
        //    {
        //        var ViewModel = dtoCollection.Find(x => x.Id == item.Id);
        //        ViewModel.Description = item.ChildTranslatedInventoryMovements.FirstOrDefault(z => z.Language == lang).Description;
        //        if (item.Inventory != null)
        //        {
        //            ViewModel.Inventory = item.Inventory.ChildTranslatedInventorys.First(x => x.Language == lang).Name; ;
        //        }
        //        if (item.InventoryMovementType != null)
        //        {
        //            ViewModel.InventoryMovementType = item.InventoryMovementType.ChildTranslatedInventoryMovementTypes.FirstOrDefault(x => x.Language == lang).Name; ;
        //        }
        //    }
        //    if (model.Filters != null)
        //    {
        //        foreach (var item in model.Filters)
        //        {
        //            switch (item.Field)
        //            {
        //                case "description":
        //                    dtoCollection = dtoCollection.Where(x => x.Description.Contains(item.Value)).ToList();
        //                    break;
        //                case "code":
        //                    dtoCollection = dtoCollection.Where(x => x.Code.Contains(item.Value)).ToList();
        //                    break;                  
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    var total = dtoCollection.Count();
        //    dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
        //    var result = new GenericCollectionViewModel<InventoryMovementLightViewModel>
        //    {
        //        Collection = dtoCollection,
        //        TotalCount = total,
        //        PageIndex = model.PageIndex,
        //        PageSize = model.PageSize
        //    };

        //    return result;
        //}

        public GenericCollectionViewModel<InventoryMovementLightViewModel> GetByFilter(InventoryMovementFilterViewModel model)
        {

            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<InventoryMovement, long> condition = new ConditionFilter<InventoryMovement, long>()
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
            IQueryable<InventoryMovement> queryableData = this._InventoryMovementsRepository.Get(condition);

            queryableData = queryableData.Where(x => x.ParentKeyInventoryMovementId.HasValue == false);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.CreationDate >= model.DateFrom.Value);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.CreationDate <= model.DateTo.Value);

            if (model.Inventory.HasValue)
                queryableData = queryableData.Where(x => x.InventoryId == model.Inventory.Value);

            if (model.InventoryMovementTypeId.HasValue)
                queryableData = queryableData.Where(x => x.InventoryMovementTypeId == model.InventoryMovementTypeId.Value);

            if (string.IsNullOrEmpty(model.Description) == false)
            {
                queryableData = queryableData.Where(x =>
                    x.ChildTranslatedInventoryMovements.FirstOrDefault(y => y.Language == Language.Arabic).Description.Contains(model.Description));
            }

            if (string.IsNullOrEmpty(model.Description) == false)
            {
                queryableData = queryableData.Where(x =>
                    x.ChildTranslatedInventoryMovements.FirstOrDefault(y => y.Language == Language.English).Description.Contains(model.Description));
            }


            var entityCollection = queryableData.ToList();
            foreach (var item in entityCollection)
            {
                item.Description = item.ChildTranslatedInventoryMovements.FirstOrDefault(z => z.Language == lang).Description;
                if (item.Inventory != null)
                {
                    item.Inventory.Name = item.Inventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == lang).Name;
                }
                
                if(item.InventoryMovementType != null)
                {
                    item.InventoryMovementType.Name = item.InventoryMovementType.ChildTranslatedInventoryMovementTypes.FirstOrDefault(z => z.Language == lang).Name;
                }
            }
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<InventoryMovementLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        public InventoryMovementAddViewModel GetInventoryMovement(long id)
        {
            var entity = this._InventoryMovementsRepository.Get(id);
            var model = entity.ToFromModel();

            foreach (var product in model.Products)
            {
                Brand brand = this._brandsRepository.Get().FirstOrDefault(x => x.Id == product.BrandId);
                string brandName = brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Name;
                product.BrandName = $"{brand.Code}-{brandName}";
            }

            return model;
        }

        public InventoryMovementAddViewModel AddInventoryMovement(InventoryMovementAddViewModel model)
        {
            if (model.Journal == null)
            {
                this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

                DateTime CurrentDate = DateTime.Now;
                var entity = model.ToEntity();

                foreach (var item in entity.InventoryMovementCostCenter)
                {
                    item.CreationDate = CurrentDate;
                }

                var movementTypeList = this._inventoryMovementTypeRepository.Get(null).ToList();

                foreach (var item in entity.InventoryProductHistorys)
                {
                    item.CreationDate = CurrentDate;
                    item.InventoryId = model.InventoryId;

                    var movementType = movementTypeList.FirstOrDefault(x => x.Id == model.InventoryMovementTypeId);
                    if (movementType.Type == InventoryMovementTypeEnum.GiftsIn ||
                        movementType.Type == InventoryMovementTypeEnum.InventoryIn ||
                        movementType.Type == InventoryMovementTypeEnum.PositiveInventoryDifferences)
                    {
                        var product = new Product
                        {
                            BrandId = item.BrandId,
                            InventoryId = item.InventoryId,
                            MeasurementUnitId = item.MeasurementUnitId,
                            NetValue = item.NetValue,
                            Price = item.Price,
                            Quantity = item.Quantity
                        };
                        this._ProductsRepository.Add(product);
                    }
                    else if (movementType.Type == InventoryMovementTypeEnum.GiftsOut ||
                        movementType.Type == InventoryMovementTypeEnum.InventoryOut ||
                        movementType.Type == InventoryMovementTypeEnum.NegativeInventoryDifferences ||
                        movementType.Type == InventoryMovementTypeEnum.Consists)
                    {

                    }
                    else if (movementType.Type == InventoryMovementTypeEnum.Reservation)
                    {
                        var existProduct = this._ProductsRepository.Get(null).Where(x =>
                            x.BrandId == item.BrandId && x.MeasurementUnitId == item.MeasurementUnitId);

                        if (existProduct.Count() > 0)
                        {

                        }
                        else
                        {
                            var product = new Product
                            {
                                BrandId = item.BrandId,
                                InventoryId = item.InventoryId,
                                MeasurementUnitId = item.MeasurementUnitId,
                                NetValue = item.NetValue,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                LockedCount = item.Quantity
                            };
                            this._ProductsRepository.Add(product);
                        }
                    }
                    else if (movementType.Type == InventoryMovementTypeEnum.ReservationRebate)
                    {

                    }
                }


                //foreach (var item in model.Products)
                //{
                //   var productEntity = item.ToEntity();
                //   productEntity.InventoryId = model.InventoryId;
                //   this._ProductsRepository.Add(productEntity);             
                //}


                #region translation
                entity.Description = "";
                entity.CreationDate = CurrentDate;
                entity.Code = model.Code;
                entity.Date = model.Date;
                entity.Language = Language.None;

                InventoryMovement InventoryMovementAr = new InventoryMovement
                {
                    Description = model.DescriptionAr,
                    Language = Language.Arabic,
                    CreationDate = CurrentDate
                };

                InventoryMovement InventoryMovementEn = new InventoryMovement
                {
                    Description = model.DescriptionEn,
                    Language = Language.English,
                    CreationDate = CurrentDate
                };

                entity.ChildTranslatedInventoryMovements.Add(InventoryMovementAr);
                entity.ChildTranslatedInventoryMovements.Add(InventoryMovementEn);
                #endregion


                entity = this._InventoryMovementsRepository.Add(entity);

                #region Commit Changes
                this._unitOfWork.Commit();
                #endregion

                #region Generate New Code
                try
                {
                    ConditionFilter<InventoryMovement, long> condition = new ConditionFilter<InventoryMovement, long>
                    {
                        Query = x =>
                            x.ParentKeyInventoryMovement == null &&
                            string.IsNullOrEmpty(x.Code) == false
                            ,
                        Order = Order.Descending
                    };

                    var z = this._InventoryMovementsRepository.Get(condition);
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

                entity = this._InventoryMovementsRepository.Update(entity);

                this._unitOfWork.Commit();
                #endregion

                model.Id = entity.Id;
                model.Code = entity.Code;
                //model = entity.ToModel();
                if(movementTypeList.FirstOrDefault(x => x.Id == model.InventoryMovementTypeId).Type == InventoryMovementTypeEnum.InventoryOut)
                {
                    model.Journal = this._journalPostingsService.Post(model.Id, MovementType.StoreMovement);

                    model.Journal.Date = model.Date.Value;

                    foreach (var Journal in model.Journal.journalDetails)
                    {
                        AccountChart accountChart = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == Journal.AccountId);
                        if(accountChart != null)
                        Journal.AccountFullCode = accountChart.FullCode;
                    }
                    model.Journal.DescriptionAr = model.DescriptionAr;
                    model.Journal.DescriptionEn = model.DescriptionEn;
                }

            }
            else if(model.Journal.PostingStatus == PostingStatus.Approved)
            {
                model.Journal.PostingStatus = PostingStatus.NeedAprove;
                Journal journal = model.Journal.ToEntity();
                journal = this._journalsRepository.Add(journal);

                Journal journalAr = new Journal
                {
                    Description = model.Journal.DescriptionAr,
                    Language = Language.Arabic,
                    ParentKeyJournal = journal
                };
                journalAr = this._journalsRepository.Add(journalAr);
                journal.ChildTranslatedJournals.Add(journalAr);

                Journal journalEn = new Journal
                {
                    Description = model.Journal.DescriptionEn,
                    Language = Language.English,
                    ParentKeyJournal = journal
                };
                journalEn = this._journalsRepository.Add(journalEn);
                journal.ChildTranslatedJournals.Add(journalEn);
                var entity = this._InventoryMovementsRepository.Get(model.Id);
                entity.IsPosted = false;
                entity.PostingDate = DateTime.Now;
                entity.PostedByUserId = this._currentUserService.CurrentUserId;
                entity = this._InventoryMovementsRepository.Update(entity);
                this._unitOfWork.Commit();
            }
            else if(model.Journal.PostingStatus == PostingStatus.Rejected)
            {

            }
            return model;
        }

        public InventoryMovementAddViewModel UpdateInventoryMovement(InventoryMovementAddViewModel model)
        {
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

            DateTime CurrentDate = DateTime.Now;
            var entity = this._InventoryMovementsRepository.Get(model.Id);

            //var costCenterList = entity.InventoryMovementCostCenter.ToList();

            //if (costCenterList.Count > 0)
            //{
            //    foreach (var item in costCenterList)
            //    {
            //        item.LastModificationDate = CurrentDate;
            //        this._InventoryMovementCostCentersRepository.Delete(item);
            //    }
            //    #region Commit Changes
            //    this._unitOfWork.Commit();
            //    #endregion
            //}

            //if (model.InventoryMovementCostCenter != null)
            //{
            //    var list = model.InventoryMovementCostCenter.ToList();

            //    foreach (var item in list)
            //    {
            //        InventoryMovementCostCenter costCenter = new InventoryMovementCostCenter();
            //        costCenter.CostCenterId = item.CostCenterId;
            //        costCenter.CreationDate = CurrentDate;
            //        entity.InventoryMovementCostCenter.Add(costCenter);
            //    }
            //}
                foreach (var item in model.Products)
                {
                var products = this._inventoryProductHistoryRepository.Get().Where(x => x.InventoryMovementId == entity.Id);
                foreach(var product in products)
                {
                    product.Price = item.Price;
                    this._inventoryProductHistoryRepository.Update(product);
                }
                
            }

            #region translation
            entity.LastModificationDate = CurrentDate;
            entity.ReferenceNumber = model.ReferenceNumber;
            entity.InventoryMovementTypeId = model.InventoryMovementTypeId;
            entity.ChildTranslatedInventoryMovements.Where(x => x.Language == Language.Arabic).FirstOrDefault().Description = model.DescriptionAr;
            entity.ChildTranslatedInventoryMovements.Where(x => x.Language == Language.English).FirstOrDefault().Description = model.DescriptionEn;
            #endregion

            entity = this._InventoryMovementsRepository.Update(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            return model;
        }
        #endregion
    }
}
