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
    /// Provides PurchaseRebate service for 
    /// business functionality.
    /// </summary>
    public class PurchaseRebatesService : IPurchaseRebatesService
    {
		#region Data Members
		private readonly ITransactionsRepository _transactionsRepository;
		private readonly IJournalsRepository _journalsRepository;
		private readonly IProductsRepository _productsRepository;
        private readonly IJournalPostingsService _journalPostingsService;
        private readonly IPurchaseRebatesRepository _PurchaseRebatesRepository;
        private readonly IClosedMonthsService _closedMonthsService;
        private readonly IBrandsRepository _brandsRepository;
        private readonly IAccountChartsRepository _accountChartsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILanguageService _languageService;
		private readonly IJournalsService _journalsService;
		private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PurchaseRebatesService.
        /// </summary>
        /// <param name="journalPostingsService"></param>
        /// <param name="PurchaseRebatesRepository"></param>
        /// <param name="languageService"></param>
        /// <param name="unitOfWork"></param>
        public PurchaseRebatesService(
            ITransactionsRepository transactionsRepository,
            IJournalsRepository journalsRepository,
            IProductsRepository productsRepository,
            IJournalPostingsService journalPostingsService,
            IPurchaseRebatesRepository PurchaseRebatesRepository,
            IClosedMonthsService closedMonthsService,
            IBrandsRepository brandsRepository,
            IAccountChartsRepository accountChartsRepository,
			IJournalsService journalsService,
			ICurrentUserService currentUserService,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
			this._transactionsRepository = transactionsRepository;
			this._journalsRepository = journalsRepository;
			this._productsRepository = productsRepository;
            this._journalPostingsService = journalPostingsService;
            this._PurchaseRebatesRepository = PurchaseRebatesRepository;
            this._closedMonthsService = closedMonthsService;
            this._brandsRepository = brandsRepository;
            this._accountChartsRepository = accountChartsRepository;
			this._journalsService = journalsService;
            this._currentUserService = currentUserService;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">PurchaseRebate view model</param>
        public void ThrowExceptionIfExist(PurchaseRebateViewModel model)
        {
            ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>
            {
                Query = (entity =>
                    entity.Code == model.Code &&
                    entity.Id != model.Id)
            };
            var existEntity = this._PurchaseRebatesRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException();
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseRebateViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<PurchaseRebateViewModel> Get(ConditionFilter<PurchaseRebate, long> condition)
        {
            var entityCollection = this._PurchaseRebatesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<PurchaseRebateViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseRebateViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<PurchaseRebateViewModel> Get(int? pageIndex, int? pageSize)
        {
            ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._PurchaseRebatesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<PurchaseRebateViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseRebateViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<PurchaseRebateLightViewModel> GetLightModel(ConditionFilter<PurchaseRebate, long> condition)
        {
            var entityCollection = this._PurchaseRebatesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<PurchaseRebateLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseRebateViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<PurchaseRebateLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._PurchaseRebatesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<PurchaseRebateLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a PurchaseRebateViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PurchaseRebateViewModel Get(long id)
        {
            var entity = this._PurchaseRebatesRepository.Get(id);
            var model = entity.ToModel();

            foreach (var item in model.PurchaseRebateProducts)
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
        public IList<PurchaseRebateViewModel> Add(IEnumerable<PurchaseRebateViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._PurchaseRebatesRepository.Add(entityCollection).ToList();

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
        public PurchaseRebateViewModel Add(PurchaseRebateViewModel model)
        {
			if (model.Journal == null)
			{
				//this.ThrowExceptionIfExist(model);
				this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);


				DateTime CurrentDate = DateTime.Now;
				var entity = model.ToEntity();
				entity.CreationDate = CurrentDate;

				foreach (var item in entity.PurchaseRebateProducts)
				{
					item.CreationDate = CurrentDate;
				}

				foreach (var item in entity.PurchaseRebateCostCenters)
				{
					item.CreationDate = CurrentDate;
				}

				entity = this._PurchaseRebatesRepository.Add(entity);


				#region Update Products
				try
				{
					if (string.IsNullOrEmpty(model.Code) == false)
					{
						long code = long.Parse(model.Code);
						var products = this._productsRepository.Get(null).Where(x => x.PurchaseInvoiceId == code);

						if (products.Count() > 0)
						{
							foreach (var item in entity.PurchaseRebateProducts)
							{

								var product = this._productsRepository.Get().Where(x => x.BrandId == item.BrandId && x.MeasurementUnitId == item.MeasurementUnitId); //model.PurchaseRebateProducts.FirstOrDefault(x => x.ProductId == item.ProductId);
								foreach (var p in product)
								{
									if (p.Quantity < item.Quantity)
									{
										throw new Exception();
									}
									else if (p.Quantity > item.Quantity)
									{
										p.Quantity = item.Quantity;
										this._productsRepository.Update(p);
									}
									else if (p.Quantity == item.Quantity)
									{
										this._productsRepository.Delete(p);
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{

				}
				#endregion


				#region Commit Changes
				this._unitOfWork.Commit();
				#endregion

				//this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.PurchaseRebate);

				model = entity.ToModel();

                model.Journal = this._journalPostingsService.Post(model.Id, MovementType.PurchaseRebate);

                model.Journal.Date = model.Date.Value;

                foreach (var Journal in model.Journal.journalDetails)
                {
                    Journal.AccountFullCode = this._accountChartsRepository.Get().FirstOrDefault(x => x.Id == Journal.AccountId).FullCode;
                }
                //model.Journal.DescriptionAr = model.DescriptionAr;
                //model.Journal.DescriptionEn = model.DescriptionEn;
            }
            else if (model.Journal.PostingStatus == PostingStatus.Approved)
			{				
				this._journalsService.AddJournal(model.Journal, PostingStatus.NeedAprove);			

                var entity = this._PurchaseRebatesRepository.Get(model.Id);
                entity.IsPosted = false;
                entity.PostingDate = DateTime.Now;
                entity.PostedByUserId = this._currentUserService.CurrentUserId;
                entity = this._PurchaseRebatesRepository.Update(entity);
                this._unitOfWork.Commit();
            }
			else if (model.Journal.PostingStatus == PostingStatus.Rejected)
			{

			}

			return model;
        }

        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<PurchaseRebateViewModel> Update(IEnumerable<PurchaseRebateViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._PurchaseRebatesRepository.Update(entityCollection).ToList();

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
        public PurchaseRebateViewModel Update(PurchaseRebateViewModel model)
        {
            this.ThrowExceptionIfExist(model);
            this._closedMonthsService.ValidateIfMonthIsClosed(model.Date.Value);


            var entity = model.ToEntity();
            entity = this._PurchaseRebatesRepository.Update(entity);

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
        public void Delete(IEnumerable<PurchaseRebateViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._PurchaseRebatesRepository.Delete(entityCollection);

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
            this._PurchaseRebatesRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(PurchaseRebateViewModel model)
        {
            var entity = model.ToEntity();
            this._PurchaseRebatesRepository.Delete(entity);

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
            var result = this._PurchaseRebatesRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public GenericCollectionViewModel<ListPurchasLightViewModel> GetByFilter(PurchasInvoiceFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<PurchaseRebate, long> condition = new ConditionFilter<PurchaseRebate, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            //if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

            IQueryable<PurchaseRebate> queryableData = this._PurchaseRebatesRepository.Get(condition);

            //queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyVendor != null);

            if (string.IsNullOrEmpty(model.Id) == false)
                queryableData = queryableData.Where(x => x.Id.ToString().Contains(model.Id));

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

            if (model.Vendor.HasValue)
                queryableData = queryableData.Where(x => x.VendorId == model.Vendor);

            if (model.Inventory.HasValue)
                queryableData = queryableData.Where(x => x.InventoryId == model.Inventory);

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.Date <= model.DateTo);

            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();
            foreach (var item in entityCollection)
            {
                var ViewModel = dtoCollection.Find(x => x.Id == item.Id);
                if (item.Vendor != null)
                {
                    ViewModel.Vendor = item.Vendor.ChildTranslatedVendors.First(x => x.Language == lang).Name;
                }
                if (item.Inventory != null)
                {
                    ViewModel.Inventory = item.Inventory.ChildTranslatedInventorys.First(x => x.Language == lang).Name; ;
                }
            }
            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListPurchasLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }
        #endregion
    }
}
