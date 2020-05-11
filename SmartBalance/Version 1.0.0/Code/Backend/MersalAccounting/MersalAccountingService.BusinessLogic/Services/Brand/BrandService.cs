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
	/// Provides Brand service for 
	/// business functionality.
	/// </summary>
	public class BrandService : IBrandsService
	{
		#region Data Members
		private readonly IBrandsRepository _BrandsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type BrandsService.
		/// </summary>
		/// <param name="BrandsRepository"></param>
		/// <param name="unitOfWork"></param>
		public BrandService(
			IBrandsRepository BrandsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._BrandsRepository = BrandsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Brand view model</param>
		public void ThrowExceptionIfExist(BrandViewModel model)
		{
			ConditionFilter<Brand, long> condition = new ConditionFilter<Brand, long>
			{
				Query = (entity =>
					entity.Code == model.Code &&
					entity.Id != model.Id)
			};
			var existEntity = this._BrandsRepository.Get(condition).FirstOrDefault();

			if (existEntity != null)
				throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BrandViewModel> Get(ConditionFilter<Brand, long> condition)
		{
			var entityCollection = this._BrandsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BrandViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BrandViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Brand, long> condition = new ConditionFilter<Brand, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._BrandsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<BrandViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BrandLightViewModel> GetLightModel(ConditionFilter<Brand, long> condition)
		{
			var entityCollection = this._BrandsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<BrandLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of BrandViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<BrandLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Brand, long> condition = new ConditionFilter<Brand, long>
			{
				PageIndex = pageIndex,

				PageSize = pageSize,
				Query = (item =>
                    item.ParentKeyBrandId != null &&
					item.Language == lang &&
                    item.ParentKeyBrand.ParentBrandId == null)
			};
			var entityCollection = this._BrandsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            //foreach (var item in dtoCollection)
            //{
            //    foreach (var child in item.ChildBrands)
            //    {
            //        string name = "";
            //        if (lang == Language.Arabic)
            //            name = child.NameAr;
            //        else if (lang == Language.English)
            //            name = child.NameEn;
            //        child.DisplyedName = $"{child.Code}-{name}";
            //    }
            //}
			var result = new GenericCollectionViewModel<BrandLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a BrandViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public BrandViewModel Get(long id)
		{
			var entity = this._BrandsRepository.Get(id);
			var model = entity.ToModel();
            if(entity.ParentBrandId != null)
            {
                Brand brand = entity.ParentBrand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage);
                model.ParentBrandName = $"{brand.ParentKeyBrand.Code}-{brand.Name}";
            }
			return model;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<ListBrandsLightViewModel> GetByFilter(BrandFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Brand, long> condition = new ConditionFilter<Brand, long>()
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
			IQueryable<Brand> queryableData = this._BrandsRepository.Get(condition);

			queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyBrand != null);

			if (string.IsNullOrEmpty(model.Code) == false)
				queryableData = queryableData.Where(x => x.ParentKeyBrand.Code.Contains(model.Code));

			if (string.IsNullOrEmpty(model.Name) == false)
				queryableData = queryableData.Where(x => x.Name.Contains(model.Name));

			if (model.DateFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBrand.Date >= model.DateFrom);

			if (model.DateTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyBrand.Date <= model.DateTo);

			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyBrandId);
			//	//ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
			//	//if (item.ParentKeyBankMovement.Bank != null)
			//	//{
			//	//	ViewModel.BankName = item.ParentKeyBankMovement.Bank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
			//	//}
			//	//if (item.ParentKeyBankMovement.JournalType != null)
			//	//{
			//	//	ViewModel.JournalTypeName = item.ParentKeyBankMovement.JournalType.ChildTranslatedJournalTypes.First(x => x.Language == lang).Name; ;
			//	//}
			//}

			var total = dtoCollection.Count();
			dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
			var result = new GenericCollectionViewModel<ListBrandsLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}

        public List<BrandLightViewModel> GetChildren(long brandId)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Brand, long> condition = new ConditionFilter<Brand, long>
            {
                Query = (item =>
                    item.ParentKeyBrandId != null &&
                    item.Language == lang &&
                    item.ParentKeyBrand.ParentBrandId == brandId)
            };
            var entityCollection = this._BrandsRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            return dtoCollection;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<BrandViewModel> Add(IEnumerable<BrandViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BrandsRepository.Add(entityCollection).ToList();

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
		public BrandViewModel Add(BrandViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._BrandsRepository.Add(entity);

			var entityAr = new Brand
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				Name = model.NameAr,
				Language = Language.Arabic
			};
			entity.ChildTranslatedBrands.Add(entityAr);
			this._BrandsRepository.Add(entityAr);

			var entityEn = new Brand
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				Name = model.NameEn,
				Language = Language.English
			};
			entity.ChildTranslatedBrands.Add(entityEn);
			this._BrandsRepository.Add(entityEn);

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
		public IList<BrandViewModel> Update(IEnumerable<BrandViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._BrandsRepository.Update(entityCollection).ToList();

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
		public BrandViewModel Update(BrandViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			//var entity = model.ToEntity();
			var entity = this._BrandsRepository.Get(model.Id);
			entity.Code = model.Code;
			entity.Date = model.Date;
            entity.ParentBrandId = model.ParentBrandId;

			entity = this._BrandsRepository.Update(entity);

			ConditionFilter<Brand, long> conditionFilter = new ConditionFilter<Brand, long>()
			{
				Query = (x =>
						x.ParentKeyBrandId == entity.Id)
			};
			var childs = this._BrandsRepository.Get(conditionFilter);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				ar.Name = model.NameAr;
				ar.Description = model.DescriptionAr;
				this._BrandsRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				en.Name = model.NameEn;
				en.Description = model.DescriptionEn;
				this._BrandsRepository.Update(en);
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
		public void Delete(IEnumerable<BrandViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._BrandsRepository.Delete(entityCollection);
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
			this._BrandsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(BrandViewModel model)
		{
			var entity = model.ToEntity();
			this._BrandsRepository.Delete(entity);

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
			var result = this._BrandsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

        public IList<BrandLightViewModel> GetLookup()
        {
            var entityCollection = this._BrandsRepository.Get().ToList();
            var lookup = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            return lookup;
        }
        #endregion
    }
}
