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
	/// Provides Inventory service for 
	/// business functionality.
	/// </summary>
	public class InventorysService : IInventorysService
    {
		#region Data Members
		private readonly IInventorysRepository _InventorysRepository;
        private readonly IProductsRepository _ProductsRepository;
        private readonly IBrandsRepository _brandsRepository;
        private readonly IAddresssRepository _AddresssRepository;
        private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type InventorysService.
		/// </summary>
		/// <param name="InventorysRepository"></param>
		/// <param name="unitOfWork"></param>
		public InventorysService(
			IInventorysRepository InventorysRepository,
			ILanguageService languageService,
            IProductsRepository ProductsRepository,
            IBrandsRepository brandsRepository,
            IAddresssRepository AddresssRepository,
            IUnitOfWork unitOfWork)
		{
			this._InventorysRepository = InventorysRepository;
            this._ProductsRepository = ProductsRepository;
            this._brandsRepository = brandsRepository;
            this._languageService = languageService;
            this._AddresssRepository = AddresssRepository;
            this._unitOfWork = unitOfWork;
		}
        #endregion

        #region Methods

        public GenericCollectionViewModel<ListInventoryLightViewModel> GetByFilter(InventoryFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Inventory, long> condition = new ConditionFilter<Inventory, long>()
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
            IQueryable<Inventory> queryableData = this._InventorysRepository.Get(condition);

            //queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyInventory != null);
            queryableData = queryableData.Where(x => x.ParentKeyInventoryId == null);

            if (string.IsNullOrEmpty(model.Code) == false)
                queryableData = queryableData.Where(x => x.Code.Contains(model.Code));

            if (string.IsNullOrEmpty(model.NameAr) == false)
                queryableData = queryableData.Where(x => x.ChildTranslatedInventorys.FirstOrDefault(c => c.Language == Language.Arabic).Name.Contains(model.NameAr));

            if (string.IsNullOrEmpty(model.NameEn) == false)
                queryableData = queryableData.Where(x => x.ChildTranslatedInventorys.FirstOrDefault(c => c.Language == Language.English).Name.Contains(model.NameEn));

            if (model.DateFrom.HasValue)
                queryableData = queryableData.Where(x => x.Date >= model.DateFrom);

            if (model.DateTo.HasValue)
                queryableData = queryableData.Where(x => x.Date <= model.DateTo);


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //    var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyInventoryId);

            //    //if (item.ParentKeyBank != null)
            //    //{
            //    //    ViewModel.BankName = item.ParentKeyBank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
            //    //}              
            //}
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
            var result = new GenericCollectionViewModel<ListInventoryLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">Inventory view model</param>
        public void ThrowExceptionIfExist(InventoryViewModel model)
		{
            ConditionFilter<Inventory, long> condition = new ConditionFilter<Inventory, long>
            {
                Query = (entity =>
                    entity.Code == model.Code &&
                    entity.Id != model.Id)
            };
            var existEntity = this._InventorysRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
        }

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryViewModel> Get(ConditionFilter<Inventory, long> condition)
		{
			var entityCollection = this._InventorysRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Inventory, long> condition = new ConditionFilter<Inventory, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._InventorysRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}


        public List<ProductLightViewModel> GetInventoryProduct(long id)
        {
            ConditionFilter<Product, long> condition = new ConditionFilter<Product, long>();
            //a.InventoryOpeningBalance.InventoryId == id ||  (a.PurchaseInvoiceId !=null && a.PurchaseInvoice.InventoryId == id)
            condition.Query = (a => (a.InventoryOpeningBalance.InventoryId == id || a.PurchaseInvoice.InventoryId == id||a.InventoryId==id)&&a.Quantity>0);
            var list = this._ProductsRepository.Get(condition).ToList();
            var result = list.Select(entity => entity.ToLightModel()).ToList();
            foreach (var item in result)
            {
                Brand brand = this._brandsRepository.Get().FirstOrDefault(x => x.Id == item.BrandId);
                item.BrandName = $"{brand.Code}-{brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Name}";
            }

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryViewModel by condition.
        /// </summary>in
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<InventoryLightViewModel> GetLightModel(ConditionFilter<Inventory, long> condition)
		{
			var entityCollection = this._InventorysRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<InventoryLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Inventory, long> condition = new ConditionFilter<Inventory, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._InventorysRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<InventoryLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}
        /// <summary>
        /// Gets a ProductLookUpViewModel.
        /// </summary>
        /// <param>no params </param>
        /// <returns> a list of ProductLookUpViewModel </returns>
        public List<InventoryLightViewModel> GetLookUp()
        {
            var lang = this._languageService.CurrentLanguage;

            ConditionFilter<Inventory, long> condition = new ConditionFilter<Inventory, long>
            {
                Query = (item =>
                item.Language == lang )
            };
            var entityCollection = this._InventorysRepository.Get(condition).ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();

            return lookup;
        }
        /// <summary>
        /// Gets a InventoryViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InventoryViewModel Get(long id)
		{
			var entity = this._InventorysRepository.Get(id);
            var model = entity.ToModel();
            Address address = this._AddresssRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Inventory);
            if (address != null) model.Address = address.Description;
			return model;
		}

		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<InventoryViewModel> Add(IEnumerable<InventoryViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventorysRepository.Add(entityCollection).ToList();

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
		public InventoryViewModel Add(InventoryViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._InventorysRepository.Add(entity);

            var entityAr = new Inventory()
            {
                Id = entity.Id,
                Name = model.NameAr,
                Description = model.DescriptionAr,
                Language = Language.Arabic
            };
            entity.ChildTranslatedInventorys.Add(entityAr);
            this._InventorysRepository.Add(entityAr);

            var entityEn = new Inventory()
            {
                Id = entity.Id,
                Name = model.NameEn,
                Description = model.DescriptionEn,
                Language = Language.English
            };
            entity.ChildTranslatedInventorys.Add(entityEn);
            this._InventorysRepository.Add(entityEn);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            Address address = this._AddresssRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Inventory);
            if (address == null)
            {
                address = new Address
                {
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.Inventory,
                    Description = model.Address,
                    IsActive = true,
                    IsMain = true
                };
                this._AddresssRepository.Add(address);
            }
            else
            {
                address.Description = model.Address;
                this._AddresssRepository.Update(address);
            }

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
		public IList<InventoryViewModel> Update(IEnumerable<InventoryViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._InventorysRepository.Update(entityCollection).ToList();

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
		public InventoryViewModel Update(InventoryViewModel model)
		{
			this.ThrowExceptionIfExist(model);

            var entity = this._InventorysRepository.Get(model.Id);//model.ToEntity();
            entity.Code = model.Code;
            entity.Date = model.Date;

			entity = this._InventorysRepository.Update(entity);


            ConditionFilter<Inventory, long> conditionFilter = new ConditionFilter<Inventory, long>()
            {
                Query = (x =>
                        x.ParentKeyInventoryId == entity.Id)
            };
            var childs = this._InventorysRepository.Get(conditionFilter);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                ar.Name = model.NameAr;
                ar.Description = model.DescriptionAr;
                this._InventorysRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                en.Name = model.NameEn;
                en.Description = model.DescriptionEn;
                this._InventorysRepository.Update(en);
            }

            Address address = this._AddresssRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.Inventory);
            if (address == null)
            {
                address = new Address
                {
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.Inventory,
                    Description = model.Address,
                    IsActive = true,
                    IsMain = true
                };
                this._AddresssRepository.Add(address);
            }
            else
            {
                address.Description = model.Address;
                this._AddresssRepository.Update(address);
            }

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
		public void Delete(IEnumerable<InventoryViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._InventorysRepository.Delete(entityCollection);

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
			this._InventorysRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(InventoryViewModel model)
		{
			var entity = model.ToEntity();
			this._InventorysRepository.Delete(entity);

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
			var result = this._InventorysRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
