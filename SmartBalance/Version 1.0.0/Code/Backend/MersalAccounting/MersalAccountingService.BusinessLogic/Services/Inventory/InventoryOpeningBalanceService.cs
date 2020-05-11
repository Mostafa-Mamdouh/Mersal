#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides InventoryOpeningBalance service for 
    /// business functionality.
    /// </summary>
    public class InventoryOpeningBalanceService : IInventoryOpeningBalanceService
    {
        #region Data Members
        private readonly IJournalPostingsService _journalPostingsService;
        private readonly IInventoryOpeningBalanceCostCenterRepository _InventoryOpeningBalanceCostCentersRepository;
        private readonly IInventoryOpeningBalanceRepository _InventoryOpeningBalancesRepository;
        private readonly IClosedMonthsService _closedMonthsService;
        private readonly ILanguageService _languageService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IProductsRepository _ProductsRepository;
        private readonly IBrandsRepository _brandsRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type InventoryOpeningBalancesService.
        /// </summary>
        /// <param name="InventoryOpeningBalancesRepository"></param>
        /// <param name="unitOfWork"></param>
        public InventoryOpeningBalanceService(
            IJournalPostingsService journalPostingsService,
            IInventoryOpeningBalanceCostCenterRepository InventoryOpeningBalanceCostCentersRepository,
            IInventoryOpeningBalanceRepository InventoryOpeningBalancesRepository,
            ILanguageService languageService,
            ICurrentUserService currentUserService,
            IClosedMonthsService closedMonthsService,
            IUnitOfWork unitOfWork,
            IProductsRepository ProductsRepository,
            IBrandsRepository brandsRepository)
        {
            this._journalPostingsService = journalPostingsService;
            this._InventoryOpeningBalanceCostCentersRepository = InventoryOpeningBalanceCostCentersRepository;
            this._InventoryOpeningBalancesRepository = InventoryOpeningBalancesRepository;
            this._languageService = languageService;
            this._currentUserService = currentUserService;
            this._ProductsRepository = ProductsRepository;
            this._closedMonthsService = closedMonthsService;
            this._brandsRepository = brandsRepository;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">InventoryOpeningBalance view model</param>
        public void ThrowExceptionIfExist(InventoryOpeningBalanceViewModel model)
        {
            //ConditionFilter<InventoryOpeningBalance, long> condition = new ConditionFilter<InventoryOpeningBalance, long>
            //{
            //    Query = (entity =>
            //        entity.Code == model.Code &&
            //        entity.Id != model.Id)
            //};
            //var existEntity = this._InventoryOpeningBalancesRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //    throw new ItemAlreadyExistException();
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryOpeningBalanceViewModel> Get(ConditionFilter<InventoryOpeningBalance, long> condition)
        {
            var entityCollection = this._InventoryOpeningBalancesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<InventoryOpeningBalanceViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryOpeningBalanceViewModel> Get(int? pageIndex, int? pageSize)
        {
            //var lang = this._languageService.CurrentLanguage;
            ConditionFilter<InventoryOpeningBalance, long> condition = new ConditionFilter<InventoryOpeningBalance, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //	item.Language == lang)
            };
            var entityCollection = this._InventoryOpeningBalancesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<InventoryOpeningBalanceViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetLightModel(ConditionFilter<InventoryOpeningBalance, long> condition)
        {
            var entityCollection = this._InventoryOpeningBalancesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }



        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            //var lang = this._languageService.CurrentLanguage;
            ConditionFilter<InventoryOpeningBalance, long> condition = new ConditionFilter<InventoryOpeningBalance, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                //Query = (item =>
                //	item.Language == lang)
            };
            var entityCollection = this._InventoryOpeningBalancesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
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
        //public GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetByFilters(InventoryOpeningBalanceFilterViewModel model)
        //{
        //    var lang = this._languageService.CurrentLanguage;
        //    ConditionFilter<InventoryOpeningBalance, long> condition = new ConditionFilter<InventoryOpeningBalance, long>()
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
        //        condition.Query = (x => x.ParentKeyInventoryOpeningBalanceId == null);
        //    }
        //    else if (model.DateFrom != null && model.DateTo == null && model.Inventory != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryOpeningBalanceId == null && x.CreationDate >= model.DateFrom && x.InventoryId == model.Inventory);
        //    }
        //    else if (model.DateFrom != null && model.DateTo == null && model.Inventory == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryOpeningBalanceId == null && x.CreationDate >= model.DateFrom);
        //    }
        //    else if (model.DateFrom == null && model.DateTo != null && model.Inventory != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryOpeningBalanceId == null && x.CreationDate <= model.DateTo && x.InventoryId == model.Inventory);
        //    }
        //    else if (model.DateFrom == null && model.DateTo != null && model.Inventory == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryOpeningBalanceId == null && x.CreationDate <= model.DateTo);
        //    }

        //    else if (model.DateFrom != null && model.DateTo != null && model.Inventory == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryOpeningBalanceId == null && x.CreationDate >= model.DateFrom && x.CreationDate <= model.DateTo);
        //    }
        //    else if (model.DateFrom == null && model.DateTo == null && model.Inventory != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryOpeningBalanceId == null && x.InventoryId == model.Inventory);
        //    }
        //    else if (model.DateFrom != null && model.DateTo != null && model.Inventory != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryOpeningBalanceId == null && x.CreationDate >= model.DateFrom && x.CreationDate <= model.DateTo &&
        //                                x.InventoryId == model.Inventory);
        //    }

        //    var entityCollection = this._InventoryOpeningBalancesRepository.Get(condition).ToList();
        //    var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();

        //    foreach (var item in entityCollection)
        //    {
        //        var ViewModel = dtoCollection.Find(x => x.Id == item.Id);
        //        ViewModel.Description = item.ChildTranslatedInventoryOpeningBalance.FirstOrDefault(z => z.Language == lang).Description;
        //        if (item.Inventory != null)
        //        {
        //            ViewModel.Inventory = item.Inventory.ChildTranslatedInventorys.First(x => x.Language == lang).Name; ;
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
        //    var result = new GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel>
        //    {
        //        Collection = dtoCollection,
        //        TotalCount = total,
        //        PageIndex = model.PageIndex,
        //        PageSize = model.PageSize
        //    };

        //    return result;
        //}


        public GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetByFilter(InventoryOpeningBalanceFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<InventoryOpeningBalance, long> condition = new ConditionFilter<InventoryOpeningBalance, long>()
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
            IQueryable<InventoryOpeningBalance> queryableData = this._InventoryOpeningBalancesRepository.Get(condition);

            queryableData = queryableData.Where(x => x.ParentKeyInventoryOpeningBalanceId.HasValue == false);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.Date >= model.DateFrom.Value);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.Date <= model.DateTo.Value);

            if (model.Inventory.HasValue)
                queryableData = queryableData.Where(x => x.InventoryId == model.Inventory.Value);

            if (string.IsNullOrEmpty(model.Description) == false)
            {
                queryableData = queryableData.Where(x =>
                    x.ChildTranslatedInventoryOpeningBalance.FirstOrDefault(y => y.Language == Language.Arabic).Description.Contains(model.Description));
            }

            if (string.IsNullOrEmpty(model.Description) == false)
            {
                queryableData = queryableData.Where(x =>
                    x.ChildTranslatedInventoryOpeningBalance.FirstOrDefault(y => y.Language == Language.English).Description.Contains(model.Description));
            }


            var entityCollection = queryableData.ToList();
            foreach (var item in entityCollection)
            {
                item.Description = item.ChildTranslatedInventoryOpeningBalance.FirstOrDefault(z => z.Language == lang).Description;
                if (item.Inventory != null)
                {
                    item.Inventory.Name = item.Inventory.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == lang).Name;
                }
            }
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InventoryOpeningBalanceViewModel Get(long id)
        {
            var entity = this._InventoryOpeningBalancesRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }


        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by vendor id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryOpeningBalanceLookupViewModel> GetOpeningBalancesByVendorID(long id)
        {
            ConditionFilter<InventoryOpeningBalance, long> condition = new ConditionFilter<InventoryOpeningBalance, long>() {
            Query = (x => x.VendorId == id)
            };
            var entityCollection = this._InventoryOpeningBalancesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLookupModel()).ToList();

            foreach (var item in dtoCollection)
            {
                foreach (var product in item.Products)
                {

                    Brand brand = this._brandsRepository.Get().FirstOrDefault(x => x.Id == product.BrandId);
                    product.BrandName = $"{brand.Code}-{brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Name}";
                }
            }
            var result = new GenericCollectionViewModel<InventoryOpeningBalanceLookupViewModel>
            {
                Collection = dtoCollection,
         
            };
            return result;
        }



        public InventoryOpeningBalanceAddViewModel GetOpeningBalances(long id)
        {
            var entity = this._InventoryOpeningBalancesRepository.Get(id);
            var model = entity.ToFromModel();

            foreach (var item in model.Products)
            {
                Brand brand = this._brandsRepository.Get().FirstOrDefault(x => x.Id == item.BrandId);
                item.BrandName = $"{brand.Code}-{brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Name}";
            }

            return model;

        }
        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<InventoryOpeningBalanceViewModel> Add(IEnumerable<InventoryOpeningBalanceViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());

            var userId = this._currentUserService.CurrentUserId;

            entityCollection = this._InventoryOpeningBalancesRepository.Add(entityCollection).ToList();

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
        public InventoryOpeningBalanceViewModel Add(InventoryOpeningBalanceViewModel model)
        {
            this.ThrowExceptionIfExist(model);
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

            var entity = model.ToEntity();
            DateTime now = DateTime.Now;

            if (model.InventoryOpeningBalanceCostCenter != null)
            {
                foreach (var item in entity.InventoryOpeningBalanceCostCenter)
                {
                    item.CreationDate = now;
                    item.InventoryOpeningBalance = entity;
                }
            }

            if (model.Products != null)
            {
                foreach (var item in entity.Products)
                {
                    item.CreationDate = now;
                    item.InventoryOpeningBalance = entity;
                }
            }

            entity = this._InventoryOpeningBalancesRepository.Add(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            //  this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.InventoryOpeningBalance);

            model = entity.ToModel();
            return model;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// p<InventoryOpeningBalanceAddViewModel, InventoryOpeningBalance>
        public InventoryOpeningBalanceAddViewModel AddInventoryOpeningBalance(InventoryOpeningBalanceAddViewModel model)
        {
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);

            DateTime CurrentDate = DateTime.Now;
            var entity = model.ToEntity();
            foreach (var item in entity.Products)
            {
                item.CreationDate = CurrentDate;
                item.InventoryId = long.Parse(model.InventoryId);
            }
            foreach (var item in entity.InventoryOpeningBalanceCostCenter)
            {
                item.CreationDate = CurrentDate;
            }
            #region translation
            entity.Description = "";
            entity.CreationDate = CurrentDate;
            entity.Code = model.Code;
            entity.Language = Language.None;

            InventoryOpeningBalance InventoryOpeningBalanceAr = new InventoryOpeningBalance();
            InventoryOpeningBalanceAr.Description = model.DescriptionAr;
            InventoryOpeningBalanceAr.Language = Language.Arabic;
            InventoryOpeningBalanceAr.CreationDate = CurrentDate;

            InventoryOpeningBalance InventoryOpeningBalanceEn = new InventoryOpeningBalance();
            InventoryOpeningBalanceEn.Description = model.DescriptionEn;
            InventoryOpeningBalanceEn.Language = Language.English;
            InventoryOpeningBalanceEn.CreationDate = CurrentDate;

            entity.ChildTranslatedInventoryOpeningBalance.Add(InventoryOpeningBalanceAr);
            entity.ChildTranslatedInventoryOpeningBalance.Add(InventoryOpeningBalanceEn);
            #endregion
            //foreach (var item in entity.Products.ToList())
            //{
            //    ConditionFilter<Product, long> ProductCondition = new ConditionFilter<Product, long>();
            //    long InventoryId = long.Parse(model.InventoryId);
            //    ProductCondition.Query = x => x.InventoryOpeningBalance.InventoryId == InventoryId && x.BrandId==item.BrandId;
            //    var product = this._ProductsRepository.Get(ProductCondition).FirstOrDefault();
            //    if (product != null)
            //    {
            //        product.Quantity += item.Quantity; 
            //        this._ProductsRepository.Update(product);
            //        entity.Products.Remove(item);                                    
            //    }       
            //}            
            entity = this._InventoryOpeningBalancesRepository.Add(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            #region Generate New Code
            try
            {
                ConditionFilter<InventoryOpeningBalance, long> condition = new ConditionFilter<InventoryOpeningBalance, long>
                {
                    Query = x =>
                        x.ParentKeyInventoryOpeningBalanceId == null &&
                        string.IsNullOrEmpty(x.Code) == false
                        ,
                    Order = Order.Descending
                };

                var z = this._InventoryOpeningBalancesRepository.Get(condition);
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

            entity = this._InventoryOpeningBalancesRepository.Update(entity);

            this._unitOfWork.Commit();
            #endregion

            model.Id = entity.Id;
            model.Code = entity.Code;
            //model = entity.ToModel();
            return model;
        }

        /// <summary>
        /// update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// p<InventoryOpeningBalanceAddViewModel, InventoryOpeningBalance>
        public InventoryOpeningBalanceAddViewModel UpdateInventoryOpeningBalance(InventoryOpeningBalanceAddViewModel model)
        {
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);

            DateTime CurrentDate = DateTime.Now;
            var entity = this._InventoryOpeningBalancesRepository.Get(model.Id);
            foreach (var item in entity.Products.ToList())
            {
                item.LastModificationDate = CurrentDate;
                foreach (var itm in model.Products)
                {
                    if (item.Id == itm.Id)
                    {
                        item.BrandId = itm.BrandId;
                        item.Quantity = itm.Quantity;
                        item.MeasurementUnitId = itm.MeasurementUnitId;
                        item.Price = itm.Price;
                        item.NetValue = itm.NetValue;
                        item.NetValue = itm.NetValue;

                    }
                    if (!(itm.Id > 0))
                    {
                        Product product = new Product();
                        product.BrandId = itm.BrandId;
                        product.Quantity = itm.Quantity;
                        product.MeasurementUnitId = itm.MeasurementUnitId;
                        product.Price = itm.Price;
                        product.NetValue = itm.NetValue;
                        product.NetValue = itm.NetValue;
                        product.CreationDate = CurrentDate;
                        entity.Products.Add(product);
                    }
                }
            }
            foreach (var item in entity.InventoryOpeningBalanceCostCenter.ToList())
            {
                item.LastModificationDate = CurrentDate;
                this._InventoryOpeningBalanceCostCentersRepository.Delete(item);
            }
            if (model.InventoryOpeningBalanceCostCenter != null)
            {
                foreach (var item in model.InventoryOpeningBalanceCostCenter)
                {
                    InventoryOpeningBalanceCostCenter costCenter = new InventoryOpeningBalanceCostCenter();
                    costCenter.CostCenterId = item.CostCenterId;
                    costCenter.CreationDate = CurrentDate;
                    entity.InventoryOpeningBalanceCostCenter.Add(costCenter);
                }
            }
            #region translation
            entity.LastModificationDate = CurrentDate;
            entity.ChildTranslatedInventoryOpeningBalance.Where(x => x.Language == Language.Arabic).FirstOrDefault().Description = model.DescriptionAr;
            entity.ChildTranslatedInventoryOpeningBalance.Where(x => x.Language == Language.English).FirstOrDefault().Description = model.DescriptionEn;
            #endregion

            entity = this._InventoryOpeningBalancesRepository.Update(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            return model;
        }




        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<InventoryOpeningBalanceViewModel> Update(IEnumerable<InventoryOpeningBalanceViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());

            var userId = this._currentUserService.CurrentUserId;

            entityCollection = this._InventoryOpeningBalancesRepository.Update(entityCollection).ToList();

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
        public InventoryOpeningBalanceViewModel Update(InventoryOpeningBalanceViewModel model)
        {
            this.ThrowExceptionIfExist(model);
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

            var entity = this._InventoryOpeningBalancesRepository.Get(model.Id);
            entity.Code = model.Code;
            entity.Description = model.Description;
            entity.InventoryId = model.InventoryId;

            //var entity = model.ToEntity();


            entity = this._InventoryOpeningBalancesRepository.Update(entity);

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
        public void Delete(IEnumerable<InventoryOpeningBalanceViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._InventoryOpeningBalancesRepository.Delete(entityCollection);

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
            this._InventoryOpeningBalancesRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(InventoryOpeningBalanceViewModel model)
        {
            var entity = model.ToEntity();
            this._InventoryOpeningBalancesRepository.Delete(entity);

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
            var result = this._InventoryOpeningBalancesRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        #endregion
    }
}
