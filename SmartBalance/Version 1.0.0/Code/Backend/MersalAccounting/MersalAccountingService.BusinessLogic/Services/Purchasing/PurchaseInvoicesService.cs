#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Common.Extentions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
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
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
	/// <summary>
	/// Provides PurchaseInvoice service for 
	/// business functionality.
	/// </summary>
	public class PurchaseInvoicesService : IPurchaseInvoicesService
	{
		#region Data Members
		private readonly ITransactionsRepository _transactionsRepository;
		private readonly IJournalsRepository _journalsRepository;
		private readonly IJournalPostingsService _journalPostingsService;
		private readonly IPurchaseInvoiceCostCentersRepository _purchaseInvoiceCostCentersRepository;
		private readonly IPurchaseInvoicesRepository _PurchaseInvoicesRepository;
		private readonly IBrandsRepository _BrandsRepository;
		private readonly IClosedMonthsService _closedMonthsService;
		private readonly ILanguageService _languageService;
		private readonly ICurrentUserService _currentUserService;
        private readonly IAccountChartsRepository _accountChartsRepository;
		private readonly IJournalsService _journalsService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseInvoicesService.
		/// </summary>
		/// <param name="PurchaseInvoicesRepository"></param>
		/// <param name="unitOfWork"></param>
		public PurchaseInvoicesService(
			ITransactionsRepository transactionsRepository,
			IJournalsRepository journalsRepository,
			IJournalPostingsService journalPostingsService,
			IPurchaseInvoiceCostCentersRepository purchaseInvoiceCostCentersRepository,
			IPurchaseInvoicesRepository PurchaseInvoicesRepository,
			IBrandsRepository BrandsRepository,
			ILanguageService languageService,
			ICurrentUserService currentUserService,
			IClosedMonthsService closedMonthsService,
            IAccountChartsRepository accountChartsRepository,
			IJournalsService journalsService,
			IUnitOfWork unitOfWork)
		{
			this._transactionsRepository = transactionsRepository;
			this._journalsRepository = journalsRepository;
			this._journalPostingsService = journalPostingsService;
			this._purchaseInvoiceCostCentersRepository = purchaseInvoiceCostCentersRepository;
			this._PurchaseInvoicesRepository = PurchaseInvoicesRepository;
			this._BrandsRepository = BrandsRepository;
			this._languageService = languageService;
			this._currentUserService = currentUserService;
			this._closedMonthsService = closedMonthsService;
            this._accountChartsRepository = accountChartsRepository;
			this._journalsService = journalsService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">PurchaseInvoice view model</param>
		public void ThrowExceptionIfExist(PurchaseInvoiceViewModel model)
		{
			//ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
			//{
			//    Query = (entity =>
			//        entity.Code == model.Code &&
			//        entity.Id != model.Id)
			//};
			//var existEntity = this._PurchaseInvoicesRepository.Get(condition).FirstOrDefault();

			//if (existEntity != null)
			//    throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseInvoiceViewModel> Get(ConditionFilter<PurchaseInvoice, long> condition)
		{
			var entityCollection = this._PurchaseInvoicesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseInvoiceViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseInvoiceViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//	item.Language == lang)
			};
			var entityCollection = this._PurchaseInvoicesRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseInvoiceViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			foreach (var invoice in entityCollection)
			{
				var viewModel = result.Collection.FirstOrDefault(i => i.Id == invoice.Id);
				viewModel.Brands = new List<BrandLightViewModel>();
				var ProductList = invoice.Products;
				foreach (var v in ProductList)
				{
					BrandLightViewModel brandViewModel = new BrandLightViewModel
					{
						Id = v.BrandId.Value
					};
					Brand b = this._BrandsRepository.Get().FirstOrDefault(bar => bar.Id == brandViewModel.Id);
					brandViewModel.Name = b.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang).Name;
					brandViewModel.Code = b.Code;
					brandViewModel.DisplyedName = $"{b.Code}-{b.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang).Name}";
					//brandViewModel.Name = $"{brandViewModel.Code} - {brandViewModel.Name}";
					viewModel.Brands.Add(brandViewModel);
				}
			}

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseInvoiceLightViewModel> GetLightModel(ConditionFilter<PurchaseInvoice, long> condition)
		{
			var entityCollection = this._PurchaseInvoicesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseInvoiceLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IList<PurchaseInvoiceLookupViewModel> GetLookupLightModel()
		{
			//var lang = this._languageService.CurrentLanguage;
			var entityCollection = this._PurchaseInvoicesRepository.Get(null).ToList();
			var result = entityCollection.Select(entity => entity.ToLookupModel()).ToList();


			//foreach (var invoice in entityCollection)
			//{
			//    var viewModel = result.FirstOrDefault(i => i.Id == invoice.Id);
			//    viewModel.Brands = new List<BrandLightViewModel>();
			//    var ProductList = invoice.Products;
			//    foreach (var v in ProductList)
			//    {
			//        BrandLightViewModel brandViewModel = new BrandLightViewModel
			//        {
			//            Id = v.BrandId.Value

			//        };
			//        Brand b = this._BrandsRepository.Get().FirstOrDefault(bar => bar.Id == brandViewModel.Id);
			//        brandViewModel.Name = b.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang).Name;
			//        brandViewModel.Code = b.Code;
			//        brandViewModel.DisplyedName = $"{brandViewModel.Code} - {brandViewModel.Name}";
			//        viewModel.Brands.Add(brandViewModel);
			//    }
			//}


			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<PurchaseInvoiceLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			//var lang = this._languageService.CurrentLanguage;
			ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				//Query = (item =>
				//	item.Language == lang)
			};
			var entityCollection = this._PurchaseInvoicesRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<PurchaseInvoiceLightViewModel>
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
		public GenericCollectionViewModel<ListPurchasLightViewModel> GetByFilter(PurchasInvoiceFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<PurchaseInvoice, long> condition = new ConditionFilter<PurchaseInvoice, long>()
			{
				Order = Order.Descending
			};

			if (model.Sort?.Count > 0)
			{
				if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
			}

			//if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
			if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToMax();

			IQueryable<PurchaseInvoice> queryableData = this._PurchaseInvoicesRepository.Get(condition);

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
				//ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
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

		/// <summary>
		/// Gets a PurchaseInvoiceViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PurchaseInvoiceViewModel Get(long id)
		{
			var entity = this._PurchaseInvoicesRepository.Get(id);
			var model = entity.ToModel();

			foreach (var item in model.Products)
			{
				Brand brand = this._BrandsRepository.Get().FirstOrDefault(x => x.Id == item.BrandId);
				item.BrandName = $"{brand.Code}-{brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Name}";
			}

			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<PurchaseInvoiceViewModel> Add(IEnumerable<PurchaseInvoiceViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());

			var userId = this._currentUserService.CurrentUserId;
			foreach (var item in entityCollection)
			{
				item.CreatedByUserId = userId;
			}
			entityCollection = this._PurchaseInvoicesRepository.Add(entityCollection).ToList();

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
		public PurchaseInvoiceViewModel Add(PurchaseInvoiceViewModel model)
		{
			if (model.Journal == null)
			{
				this.ThrowExceptionIfExist(model);
				this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);

				var entity = model.ToEntity();
				entity.CreatedByUserId = this._currentUserService.CurrentUserId;
				DateTime now = DateTime.Now;

				if (model.PurchaseInvoiceCostCenters != null)
				{
					foreach (var item in entity.PurchaseInvoiceCostCenters)
					{
						item.CreationDate = now;
						item.PurchaseInvoice = entity;
					}
				}

				if (model.Products != null)
				{
					foreach (var item in entity.Products)
					{
						item.CreationDate = now;
						item.PurchaseInvoice = entity;
						item.InventoryId = entity.InventoryId;
					}
				}

				entity = this._PurchaseInvoicesRepository.Add(entity);

				#region Commit Changes
				this._unitOfWork.Commit();
				#endregion

				//this._journalPostingsService.TryPostAutomatic(entity.Id, MovementType.PurchaseInvoice);
              
				model = entity.ToModel();

                model.Journal = this._journalPostingsService.Post(model.Id, MovementType.PurchaseInvoice);

                model.Journal.Date = model.Date;

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
				
                var entity = this._PurchaseInvoicesRepository.Get(model.Id);
                entity.IsPosted = false;
                entity.PostingDate = DateTime.Now;
                entity.PostedByUserId = this._currentUserService.CurrentUserId;
                entity = this._PurchaseInvoicesRepository.Update(entity);
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
		public IList<PurchaseInvoiceViewModel> Update(IEnumerable<PurchaseInvoiceViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());

			var userId = this._currentUserService.CurrentUserId;
			foreach (var item in entityCollection)
			{
				if (item.FirstModifiedByUserId.HasValue == false)
					item.FirstModifiedByUserId = userId;
				else
					item.LastModifiedByUserId = userId;
			}
			entityCollection = this._PurchaseInvoicesRepository.Update(entityCollection).ToList();

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
		public PurchaseInvoiceViewModel Update(PurchaseInvoiceViewModel model)
		{
			this.ThrowExceptionIfExist(model);
			this._closedMonthsService.ValidateIfMonthIsClosed(model.Date);

			var entity = this._PurchaseInvoicesRepository.Get(model.Id);

			entity.AdditionalExpensesAmount = model.AdditionalExpensesAmount;
			entity.Code = model.Code;
			entity.Date = model.Date;
			entity.DiscountAmount = model.DiscountAmount;
			entity.HasAdditionalExpenses = model.HasAdditionalExpenses;
			entity.HasDiscount = model.HasDiscount;
			entity.InventoryId = model.InventoryId;
			entity.NetAmount = model.NetAmount;
			entity.PurchaseInvoiceTypeId = model.PurchaseInvoiceTypeId;
			entity.SafeId = model.SafeId;
			entity.VendorId = model.VendorId;
			entity.VendorInvoiceCode = model.VendorInvoiceCode;

			//var entity = model.ToEntity();

			if (entity.FirstModifiedByUserId.HasValue == false)
				entity.FirstModifiedByUserId = this._currentUserService.CurrentUserId;
			else
				entity.LastModifiedByUserId = this._currentUserService.CurrentUserId;

			entity = this._PurchaseInvoicesRepository.Update(entity);

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
		public void Delete(IEnumerable<PurchaseInvoiceViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._PurchaseInvoicesRepository.Delete(entityCollection);

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
			this._PurchaseInvoicesRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(PurchaseInvoiceViewModel model)
		{
			var entity = model.ToEntity();
			this._PurchaseInvoicesRepository.Delete(entity);

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
			var result = this._PurchaseInvoicesRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
