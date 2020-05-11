#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
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
	/// Provides Asset service for 
	/// business functionality.
	/// </summary>
	public class AssetsService : IAssetsService
	{
		#region Data Members
		private readonly IObjectCostCentersRepository _objectCostCentersRepository;
		private readonly IBrandsRepository _brandsRepository;
		private readonly IAssetsRepository _AssetsRepository;
		private readonly ILocationsRepository _locationsRepository;
		private readonly IAssetLocationsRepository _assetLocationsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IEffiencyRaiseHistoryService _EffiencyRaiseHistoryService;

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AssetsService.
		/// </summary>
		/// <param name="AssetsRepository"></param>
		/// <param name="unitOfWork"></param>
		public AssetsService(
			IObjectCostCentersRepository objectCostCentersRepository,
			IBrandsRepository brandsRepository,
			IAssetsRepository AssetsRepository,
			ILocationsRepository locationsRepository,
			IAssetLocationsRepository assetLocationsRepository,
			ILanguageService languageService,
			IEffiencyRaiseHistoryService EffiencyRaiseHistoryService,

			IUnitOfWork unitOfWork)
		{
			this._objectCostCentersRepository = objectCostCentersRepository;
			this._brandsRepository = brandsRepository;
			this._AssetsRepository = AssetsRepository;
			this._locationsRepository = locationsRepository;
			this._assetLocationsRepository = assetLocationsRepository;
			this._languageService = languageService;
			this._EffiencyRaiseHistoryService = EffiencyRaiseHistoryService;

			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Throw an exception if name is exist.
		/// </summary>
		/// <param name="model">Asset view model</param>
		public void ThrowExceptionIfExist(AssetViewModel model)
		{
			//ConditionFilter<Asset, long> condition = new ConditionFilter<Asset, long>
			//{
			//	Query = (entity =>
			//		entity.Name == model.Name &&
			//		entity.Id != model.Id)
			//};
			//var existEntity = this._AssetsRepository.Get(condition).FirstOrDefault();

			//if (existEntity != null)
			//	throw new ItemAlreadyExistException();
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AssetViewModel> Get(ConditionFilter<Asset, long> condition)
		{
			var entityCollection = this._AssetsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AssetViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AssetViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Asset, long> condition = new ConditionFilter<Asset, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._AssetsRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<AssetViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AssetLightViewModel> GetLightModel(ConditionFilter<Asset, long> condition)
		{
			var entityCollection = this._AssetsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<AssetLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public GenericCollectionViewModel<AssetLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Asset, long> condition = new ConditionFilter<Asset, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._AssetsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<AssetLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		/// <summary>
		/// Gets a AssetViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public AssetViewModel Get(long id)
		{
			var entity = this._AssetsRepository.Get(id);
			var model = entity.ToModel();
			string brandName = "";
			if (this._languageService.CurrentLanguage == Language.Arabic)
				brandName = model.Brand.NameAr;
			else if (this._languageService.CurrentLanguage == Language.English)
				brandName = model.Brand.NameEn;
			model.Brand.DisplyedName = $"{model.Brand.Code}-{brandName}";
			Location location = this._locationsRepository.Get().FirstOrDefault(x => x.Id == model.LocationId);
			model.LocationName = $"{location.Code}-{location.ChildTranslatedLocations.FirstOrDefault(x => x.Language == this._languageService.CurrentLanguage).Title}";

			var objectCostCenter = this._objectCostCentersRepository.Get(null).Where(x =>
				x.ObjectType == ObjectType.Asset &&
				x.ObjectId == id
			).FirstOrDefault();

			if (objectCostCenter != null)
			{
				model.CostCenterId = objectCostCenter.CostCenterId;
			}

			return model;
		}


		public GenericCollectionViewModel<ListAssetLightViewModel> GetByFilter(AssetFilterViewModel model)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Asset, long> condition = new ConditionFilter<Asset, long>()
			{
				Order = Order.Descending
			};

			if (model.Sort?.Count > 0)
			{
				if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
			}

			////if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
			//if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToNow();

			// The IQueryable data to query.  
			IQueryable<Asset> queryableData = this._AssetsRepository.Get(condition);

			queryableData = queryableData.Where(x =>
				x.Language == lang &&
				x.ParentKeyAsset != null &&
				x.ParentKeyAsset.IsExcluded.HasValue == false &&
				x.ParentKeyAsset.IsSaled.HasValue == false);

			if (model.AccountChartId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.AccountChartId == model.AccountChartId);

			if (model.BrandId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.BrandId == model.BrandId);

			if (model.DepreciationRateId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.DepreciationRateId == model.DepreciationRateId);

			if (model.DepreciationTypeId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.DepreciationTypeId == model.DepreciationTypeId);

			if (model.LocationId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.AssetLocations.Where(y => y.LocationId == model.LocationId).FirstOrDefault() != null);

			if (model.PurchaseInvoiceId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.PurchaseInvoiceId == model.PurchaseInvoiceId);


			if (model.DepreciationValueFrom.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.DepreciationValue >= model.DepreciationValueFrom);

			if (model.DepreciationValueTo.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.DepreciationValue <= model.DepreciationValueTo);

			//if (model.DateFrom.HasValue)
			//    queryableData = queryableData.Where(x => x.ParentKeyAsset.Date >= model.DateFrom);

			//if (model.DateTo.HasValue)
			//    queryableData = queryableData.Where(x => x.ParentKeyAsset.Date <= model.DateTo);


			var entityCollection = queryableData.ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

			//foreach (var item in entityCollection)
			//{
			//    var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyAssetId);

			//    //if (item.ParentKeyAsset != null)
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
			var result = new GenericCollectionViewModel<ListAssetLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = total,
				PageIndex = model.PageIndex,
				PageSize = model.PageSize
			};

			return result;
		}

		public IList<AssetInventoryDetailLightViewModel> GetAssetDetailsByLocation(long locationId)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Asset, long> condition = new ConditionFilter<Asset, long>
			{
				Query = (item => item.AssetLocations.Any(x => x.LocationId == locationId))
			};
			var entityCollection = this._AssetsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToAssetInventoryDetail()).ToList();

			List<Brand> brandList = new List<Brand>();

			foreach (var item in dtoCollection)
			{
				var brand = brandList.FirstOrDefault(x => x.Id == item.BrandId);
				if (brand == null)
				{
					brand = this._brandsRepository.Get(item.BrandId.Value);
				}

				item.Brand.DisplyedName = $"{item.Brand.Code} - {brand.ChildTranslatedBrands.FirstOrDefault(x => x.Language == lang)?.Name}";
			}

			return dtoCollection;
		}

		public GenericCollectionViewModel<AssetLookupViewModel> GetLookup()
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Asset, long> condition = new ConditionFilter<Asset, long>
			{
				Query = (item =>
					item.Language == lang)
			};
			var entityCollection = this._AssetsRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLookup()).ToList();
			var result = new GenericCollectionViewModel<AssetLookupViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count
			};

			return result;
		}


		/// <summary>
		/// Add entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<AssetViewModel> Add(IEnumerable<AssetViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AssetsRepository.Add(entityCollection).ToList();

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
		public AssetViewModel Add(AssetViewModel model)
		{
			this.ThrowExceptionIfExist(model);


			//LocationViewModel loc = null;
			Location location = new Location();
			if (model.Location == null && (model.LocationId == null || model.LocationId == 0))
			{
				throw new GeneralException(15);
			}
			else if (
				(model.LocationId == null || model.LocationId == 0) &&
				model.Location != null)
			{
				model.Location.Date = DateTime.Now;
				ConditionFilter<Location, long> condition = new ConditionFilter<Location, long>
				{
					Query = (e =>
						e.Code == model.Location.Code &&
						e.Id != model.Id)
				};
				var existEntity = this._locationsRepository.Get(condition).FirstOrDefault();

				if (existEntity != null)
					throw new ItemAlreadyExistException((int)ErrorCodeEnum.CodeAlreadyExist);

				location = model.Location.ToEntity();

				Location locationAr = new Location
				{
					ParentKeyLocationId = location.Id,
					Title = model.Location.TitleAr,
					Description = model.Location.DescriptionAr,
					Language = Language.Arabic
				};

				Location locationEn = new Location
				{
					ParentKeyLocationId = location.Id,
					Title = model.Location.TitleEn,
					Description = model.DescriptionEn,
					Language = Language.English
				};

				location = this._locationsRepository.Add(location);
				location.ChildTranslatedLocations.Add(locationAr);
				this._locationsRepository.Add(locationAr);
				location.ChildTranslatedLocations.Add(locationEn);
				this._locationsRepository.Add(locationEn);


				//loc = location.ToModel();
			}




			var entity = model.ToEntity();


			entity.BarCode = Guid.NewGuid().ToString();
			entity.CurrentValue = entity.Amount;

			AssetLocation assetLocation = new AssetLocation()
			{
				Date = DateTime.Now
			};

			if (model.LocationId != null)
			{
				assetLocation.LocationId = model.LocationId;
				//    entity.LocationId = model.LocationId;
				//    entity.Location = null;
			}
			else
			{
				assetLocation.Location = location;
				//    entity.Location = location;
			}

			entity.AssetLocations.Add(assetLocation);

			entity = this._AssetsRepository.Add(entity);

			this._assetLocationsRepository.Add(assetLocation);

			#region Add AssetLocation Translation           

			var assetLocationAr = new AssetLocation
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				Language = Language.Arabic
			};
			assetLocation.ChildTranslatedAssetLocations.Add(assetLocationAr);
			this._assetLocationsRepository.Add(assetLocationAr);

			var assetLocationEn = new AssetLocation
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				Language = Language.English
			};
			assetLocation.ChildTranslatedAssetLocations.Add(assetLocationEn);
			this._assetLocationsRepository.Add(assetLocationEn);
			#endregion



			var entityAr = new Asset
			{
				Id = entity.Id,
				Description = model.DescriptionAr,
				//Name = model.NameAr,
				Language = Language.Arabic
			};
			entity.ChildTranslatedAssets.Add(entityAr);
			this._AssetsRepository.Add(entityAr);

			var entityEn = new Asset
			{
				Id = entity.Id,
				Description = model.DescriptionEn,
				//Name = model.NameEn,
				Language = Language.English
			};
			entity.ChildTranslatedAssets.Add(entityEn);
			this._AssetsRepository.Add(entityEn);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			if (model.CostCenterId.HasValue)
			{
				var objectCostCenter = new ObjectCostCenter
				{
					CostCenterId = model.CostCenterId.Value,
					ObjectId = entity.Id,
					ObjectType = ObjectType.Asset
				};

				this._objectCostCentersRepository.Add(objectCostCenter);

				#region Commit Changes
				this._unitOfWork.Commit();
				#endregion
			}

			model = entity.ToModel();
			return model;
		}

		/// <summary>
		/// Update entities.
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		public IList<AssetViewModel> Update(IEnumerable<AssetViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._AssetsRepository.Update(entityCollection).ToList();

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
		public AssetViewModel Update(AssetViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = this._AssetsRepository.Get(model.Id);

			// add Effiency Raise           
			if (model.RaiseAmount != null)
			{
				var EffiencyRaise = new EffiencyRaiseHistoryViewModel();
				EffiencyRaise.RaiseAmount = model.RaiseAmount;
				EffiencyRaise.RaiseDate = model.RaiseDate;
	
				this._EffiencyRaiseHistoryService.Add(EffiencyRaise);

				entity.DepreciationValue += model.RaiseAmount;
			}

			//entity.LocationId = model.LocationId;
			//entity.AccountChartId = model.AccountChartId;

			entity.Color = model.Color;
			entity.Size = model.Size;
			entity.Status = model.Status;
			entity.Serial = model.Serial;
			entity.Model = model.Model;
			entity.Properties = model.Properties;

			entity = this._AssetsRepository.Update(entity);

			ConditionFilter<Asset, long> conditionFilter = new ConditionFilter<Asset, long>()
			{
				Query = (x =>
						x.ParentKeyAssetId == entity.Id)
			};
			var childs = this._AssetsRepository.Get(conditionFilter);

			if (childs.Count() > 0)
			{
				var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
				//ar.Name = model.NameAr;
				ar.Description = model.DescriptionAr;
				this._AssetsRepository.Update(ar);

				var en = childs.FirstOrDefault(x => x.Language == Language.English);
				//en.Name = model.NameEn;
				en.Description = model.DescriptionEn;
				this._AssetsRepository.Update(en);
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
		public void Delete(IEnumerable<AssetViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._AssetsRepository.Delete(entityCollection);

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
			this._AssetsRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		/// <summary>
		/// Delete an entity.
		/// </summary>
		/// <param name="model"></param>
		public void Delete(AssetViewModel model)
		{
			var entity = model.ToEntity();
			this._AssetsRepository.Delete(entity);

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
			var result = this._AssetsRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}
		#endregion
	}
}
