#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
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
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	/// <summary>
	/// Provides InventoryTransfer service for 
	/// business functionality.
	/// </summary>
	public class InventoryTransfersService : IInventoryTransfersService
	{
		#region Data Members
		private readonly IInventoryTransfersRepository _InventoryTransfersRepository;
        private readonly IInventoryTransferCostCenterRepository _InventoryTransferCostCentersRepository;
        private readonly IClosedMonthsService _closedMonthsService;
        private readonly ILanguageService _languageService;
        private readonly IProductsRepository _ProductsRepository;
        private readonly IBrandsRepository _brandsRepository;
        private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventoryTransfersService.
		/// </summary>
		/// <param name="InventoryTransfersRepository"></param>
		/// <param name="unitOfWork"></param>
		public InventoryTransfersService(
			IInventoryTransfersRepository InventoryTransfersRepository,
            IInventoryTransferCostCenterRepository InventoryTransferCostCentersRepository,
            IProductsRepository ProductsRepository,
            IClosedMonthsService closedMonthsService,
            IBrandsRepository brandsRepository,
            ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._InventoryTransfersRepository = InventoryTransfersRepository;
			this._languageService = languageService;
            this._InventoryTransferCostCentersRepository = InventoryTransferCostCentersRepository;
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
		/// <param name="model">InventoryTransfer view model</param>
		public void ThrowExceptionIfExist(InventoryTransferViewModel model)
		{
			ConditionFilter<InventoryTransfer, long> condition = new ConditionFilter<InventoryTransfer, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._InventoryTransfersRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryTransferViewModel> Get(ConditionFilter<InventoryTransfer, long> condition)
		{
			var entityCollection = this._InventoryTransfersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryTransferViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryTransferViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<InventoryTransfer, long> condition = new ConditionFilter<InventoryTransfer, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._InventoryTransfersRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryTransferViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryTransferLightViewModel> GetLightModel(ConditionFilter<InventoryTransfer, long> condition)
		{
			var entityCollection = this._InventoryTransfersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryTransferLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryTransferLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<InventoryTransfer, long> condition = new ConditionFilter<InventoryTransfer, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._InventoryTransfersRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryTransferLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a InventoryTransferViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public InventoryTransferViewModel Get(long id)
		{
			var entity = this._InventoryTransfersRepository.Get(id);
			var model = entity.ToModel();

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<InventoryTransferViewModel> Add(IEnumerable<InventoryTransferViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventoryTransfersRepository.Add(entityCollection).ToList();

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
		public InventoryTransferViewModel Add(InventoryTransferViewModel model)
		{
			this.ThrowExceptionIfExist(model);
            //this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

            var entity = model.ToEntity();
			entity = this._InventoryTransfersRepository.Add(entity);

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
		public IList<InventoryTransferViewModel> Update(IEnumerable<InventoryTransferViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventoryTransfersRepository.Update(entityCollection).ToList();

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
		public InventoryTransferViewModel Update(InventoryTransferViewModel model)
		{
			this.ThrowExceptionIfExist(model);
            //this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);

            var entity = model.ToEntity();
			entity = this._InventoryTransfersRepository.Update(entity);

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
		public void Delete(IEnumerable<InventoryTransferViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._InventoryTransfersRepository.Delete(entityCollection);

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
			this._InventoryTransfersRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(InventoryTransferViewModel model)
		{
			var entity = model.ToEntity();
			this._InventoryTransfersRepository.Delete(entity);

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
			var result = this._InventoryTransfersRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

        //public GenericCollectionViewModel<InventoryTransferLightViewModel> GetByFilter(InventoryTransferFilterViewModel model)
        //{
        //    var lang = this._languageService.CurrentLanguage;
        //    ConditionFilter<InventoryTransfer, long> condition = new ConditionFilter<InventoryTransfer, long>();
        //    if (model.Sort != null)
        //    {
        //        if (model.Sort.Count > 0)
        //        {
        //            if (model.Sort[0].Dir == "desc")
        //            {
        //                condition.Order = Order.Descending;
        //            }
        //            else
        //            {
        //                condition.Order = Order.Ascending;
        //            }
        //        }
        //        else
        //        {
        //            condition.Order = Order.Descending;
        //        }
        //    }
        //    else
        //    {
        //        condition.Order = Order.Descending;
        //    }

        //    model.DateFrom = model.DateFrom.SetTimeToNow();
        //    model.DateTo = model.DateTo.SetTimeToNow();

        //    if (model.DateFrom == null && model.DateTo == null && model.InventoryFromId == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryTransferId == null);
        //    }
        //    else if (model.DateFrom != null && model.DateTo == null && model.InventoryFromId != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryTransferId == null && x.CreationDate >= model.DateFrom && x.InventoryFromId == model.InventoryFromId);
        //    }
        //    else if (model.DateFrom != null && model.DateTo == null && model.InventoryFromId == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryTransferId == null && x.CreationDate >= model.DateFrom);
        //    }
        //    else if (model.DateFrom == null && model.DateTo != null && model.InventoryFromId != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryTransferId == null && x.CreationDate <= model.DateTo && x.InventoryFromId == model.InventoryFromId);
        //    }
        //    else if (model.DateFrom == null && model.DateTo != null && model.InventoryFromId == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryTransferId == null && x.CreationDate <= model.DateTo);
        //    }

        //    else if (model.DateFrom != null && model.DateTo != null && model.InventoryFromId == null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryTransferId == null && x.CreationDate >= model.DateFrom && x.CreationDate <= model.DateTo);
        //    }
        //    else if (model.DateFrom == null && model.DateTo == null && model.InventoryFromId != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryTransferId == null && x.InventoryFromId == model.InventoryFromId);
        //    }
        //    else if (model.DateFrom != null && model.DateTo != null && model.InventoryFromId != null)
        //    {
        //        condition.Query = (x => x.ParentKeyInventoryTransferId == null && x.CreationDate >= model.DateFrom && x.CreationDate <= model.DateTo &&
        //                                x.InventoryFromId == model.InventoryFromId);
        //    }

        //    var entityCollection = this._InventoryTransfersRepository.Get(condition).ToList();
        //    if (model.InventoryToId != null)
        //    {
        //        entityCollection = entityCollection.Where(x => x.InventoryToId == model.InventoryToId).ToList();
        //    }
        //    var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            
        //    foreach (var item in entityCollection)
        //    {
        //        var ViewModel = dtoCollection.Find(x => x.Id == item.Id);
        //        ViewModel.Description = item.ChildTranslatedInventoryTransfers.FirstOrDefault(z => z.Language == lang).Description;
        //        if (item.InventoryFromId != null)
        //        {
        //            ViewModel.InventoryFrom = item.InventoryFrom.ChildTranslatedInventorys.First(x => x.Language == lang).Name;
        //            ViewModel.InventoryTo = item.InventoryTo.ChildTranslatedInventorys.First(x => x.Language == lang).Name; ;
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
        //    var result = new GenericCollectionViewModel<InventoryTransferLightViewModel>
        //    {
        //        Collection = dtoCollection,
        //        TotalCount = total,
        //        PageIndex = model.PageIndex,
        //        PageSize = model.PageSize
        //    };

        //    return result;
        //}


        public GenericCollectionViewModel<InventoryTransferLightViewModel> GetByFilter(InventoryTransferFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<InventoryTransfer, long> condition = new ConditionFilter<InventoryTransfer, long>()
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
            IQueryable<InventoryTransfer> queryableData = this._InventoryTransfersRepository.Get(condition);

            queryableData = queryableData.Where(x => x.ParentKeyInventoryTransferId.HasValue == false);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.CreationDate >= model.DateFrom.Value);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.CreationDate <= model.DateTo.Value);

            if (model.InventoryFromId.HasValue)
                queryableData = queryableData.Where(x => x.InventoryFromId == model.InventoryFromId.Value);

            if (model.InventoryToId.HasValue)
                queryableData = queryableData.Where(x => x.InventoryToId == model.InventoryToId.Value);

            if (string.IsNullOrEmpty(model.Description) == false)
            {
                queryableData = queryableData.Where(x =>
                    x.ChildTranslatedInventoryTransfers.FirstOrDefault(y => y.Language == Language.Arabic).Description.Contains(model.Description));
            }

            if (string.IsNullOrEmpty(model.Description) == false)
            {
                queryableData = queryableData.Where(x =>
                    x.ChildTranslatedInventoryTransfers.FirstOrDefault(y => y.Language == Language.English).Description.Contains(model.Description));
            }


            var entityCollection = queryableData.ToList();
            foreach (var item in entityCollection)
            {
                item.Description = item.ChildTranslatedInventoryTransfers.FirstOrDefault(z => z.Language == lang).Description;
                if (item.InventoryTo != null)
                {
                    item.InventoryTo.Name = item.InventoryTo.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == lang).Name;
                }
                if (item.InventoryFrom != null)
                {
                    item.InventoryFrom.Name = item.InventoryFrom.ChildTranslatedInventorys.FirstOrDefault(x => x.Language == lang).Name;
                }
            }
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<InventoryTransferLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;          
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <InventoryTransferAddViewModel, AddInventoryTransfer>
        public InventoryTransferAddViewModel AddInventoryTransfer(InventoryTransferAddViewModel model)
        {
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

            DateTime CurrentDate = DateTime.Now;
            var entity = model.ToEntity();
            foreach (var item in entity.InventoryTransferCostCenter)
            {
                item.CreationDate = CurrentDate;
            }
            foreach (var item in entity.InventoryProductHistorys)
            {
                item.CreationDate = CurrentDate;
                item.InventoryId = model.InventoryToId;
            }
            foreach (var item in model.Products)
            {
                Product fromProduct= this._ProductsRepository.Get(item.Id);
                fromProduct.Quantity = fromProduct.Quantity - item.Quantity;
                this._ProductsRepository.Update(fromProduct);
                ConditionFilter<Product, long> condition = new ConditionFilter<Product, long>
                {
                    Query = (x =>x.BrandId == item.BrandId && x.InventoryId == model.InventoryToId)
                };
                var existEntity = this._ProductsRepository.Get(condition).FirstOrDefault();
                if (existEntity == null) {
                    var productEntity = item.ToEntity();
                    productEntity.InventoryId = model.InventoryToId;
                    this._ProductsRepository.Add(productEntity);
                }
                else
                {
                    existEntity.Quantity = existEntity.Quantity + item.Quantity;
                    this._ProductsRepository.Update(existEntity);
                }                   
            }
            #region translation
            entity.Description = "";
            entity.CreationDate = CurrentDate;
            entity.Code = model.Code;
            entity.Language = Language.None;

            InventoryTransfer InventoryTransferAr = new InventoryTransfer();
            InventoryTransferAr.Description = model.DescriptionAr;
            InventoryTransferAr.Language = Language.Arabic;
            InventoryTransferAr.CreationDate = CurrentDate;

            InventoryTransfer InventoryTransferEn = new InventoryTransfer();
            InventoryTransferEn.Description = model.DescriptionEn;
            InventoryTransferEn.Language = Language.English;
            InventoryTransferEn.CreationDate = CurrentDate;

            entity.ChildTranslatedInventoryTransfers.Add(InventoryTransferAr);
            entity.ChildTranslatedInventoryTransfers.Add(InventoryTransferEn);
            #endregion

            entity = this._InventoryTransfersRepository.Add(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            #region Generate New Code
            try
            {
                ConditionFilter<InventoryTransfer, long> condition = new ConditionFilter<InventoryTransfer, long>
                {
                    Query = x =>
                        x.ParentKeyInventoryTransferId == null &&
                        string.IsNullOrEmpty(x.Code) == false
                        ,
                    Order = Order.Descending
                };

                var z = this._InventoryTransfersRepository.Get(condition);
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

            entity = this._InventoryTransfersRepository.Update(entity);

            this._unitOfWork.Commit();
            #endregion

            model.Id = entity.Id;
            model.Code = entity.Code;
            //model = entity.ToModel();
            return model;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <InventoryTransferAddViewModel, AddInventoryTransfer>
        public InventoryTransferAddViewModel UpdateInventoryTransfer(InventoryTransferAddViewModel model)
        {
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);

            DateTime CurrentDate = DateTime.Now;
            var entity = this._InventoryTransfersRepository.Get(model.Id);

            //var costCenterList = entity.InventoryTransferCostCenter.ToList();

            //foreach (var item in costCenterList)
            //{
            //    item.LastModificationDate = CurrentDate;
            //    this._InventoryTransferCostCentersRepository.Delete(item);
            //}

            //if (model.InventoryTransferCostCenter != null)
            //{
            //    foreach (var item in model.InventoryTransferCostCenter)
            //    {
            //        InventoryTransferCostCenter costCenter = new InventoryTransferCostCenter();
            //        costCenter.CostCenterId = item.CostCenterId;
            //        costCenter.CreationDate = CurrentDate;
            //        entity.InventoryTransferCostCenter.Add(costCenter);
            //    }
            //}

            #region translation
            entity.LastModificationDate = CurrentDate;
            entity.ChildTranslatedInventoryTransfers.Where(x => x.Language == Language.Arabic).FirstOrDefault().Description = model.DescriptionAr;
            entity.ChildTranslatedInventoryTransfers.Where(x => x.Language == Language.English).FirstOrDefault().Description = model.DescriptionEn;
            #endregion

            entity = this._InventoryTransfersRepository.Update(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            return model;
        }


        public InventoryTransferAddViewModel GetInventoryTransfer(long id)
        {
            var entity = this._InventoryTransfersRepository.Get(id);
            var model = entity.ToFromModel();

            foreach (var item in model.Products)
            {
                Brand brand = this._brandsRepository.Get().FirstOrDefault(x => x.Id == item.BrandId);
                item.BrandName = $"{brand.Code}-{brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Name}";
            }

            return model;

        }

        #endregion
    }
}
