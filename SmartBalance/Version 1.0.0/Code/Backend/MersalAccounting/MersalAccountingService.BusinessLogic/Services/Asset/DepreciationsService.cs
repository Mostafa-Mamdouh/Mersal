#region using..
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.AutoMapperConfig;
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
	public class DepreciationsService : IDepreciationsService
	{
		#region Data Members
		private readonly IDepreciationsRepository _DepreciationRepository;
		private readonly IAssetsRepository _AssetsRepository;
		private readonly ILanguageService _languageService;
		private readonly IUnitOfWork _unitOfWork;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AssetsService.
		/// </summary>
		/// <param name="AssetsRepository"></param>
		/// <param name="unitOfWork"></param>
		public DepreciationsService(
			IDepreciationsRepository DepreciationRepository,
			IAssetsRepository AssetsRepository,
			ILanguageService languageService,
			IUnitOfWork unitOfWork)
		{
			this._DepreciationRepository = DepreciationRepository;
			this._AssetsRepository = AssetsRepository;
			this._languageService = languageService;
			this._unitOfWork = unitOfWork;
		}
		#endregion

		#region Methods

		public void ThrowExceptionIfExist(DepreciationViewModel model)
		{
			//ConditionFilter<Depreciation, long> condition = new ConditionFilter<Depreciation, long>
			//{
			//	Query = (entity =>
			//		entity.Name == model.Name &&
			//		entity.Id != model.Id)
			//};
			//var existEntity = this._DepreciationRepository.Get(condition).FirstOrDefault();

			//if (existEntity != null)
			//	throw new ItemAlreadyExistException();
		}

		public GenericCollectionViewModel<DepreciationViewModel> Get(ConditionFilter<Depreciation, long> condition)
		{
			var entityCollection = this._DepreciationRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<DepreciationViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		public GenericCollectionViewModel<DepreciationViewModel> Get(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Depreciation, long> condition = new ConditionFilter<Depreciation, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._DepreciationRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			var result = new GenericCollectionViewModel<DepreciationViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		public DepreciationViewModel Get(long id)
		{
			var entity = this._DepreciationRepository.Get(id);
			var model = entity.ToModel();

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
				x.ParentKeyAsset.IsSaled.HasValue == false &&
				x.ParentKeyAsset.CurrentValue > 0
				);

			if (model.AccountChartId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.AccountChartId == model.AccountChartId);

			if (model.BrandId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.BrandId == model.BrandId);

			if (model.DepreciationRateId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.DepreciationRateId == model.DepreciationRateId);

			if (model.DepreciationTypeId.HasValue)
				queryableData = queryableData.Where(x => x.ParentKeyAsset.DepreciationTypeId == model.DepreciationTypeId);

            if (model.LocationId.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyAsset.AssetLocations.Where(y => y.LocationId == model.LocationId).Count() > 0);

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

		public GenericCollectionViewModel<DepreciationLightViewModel> GetLightModel(ConditionFilter<Depreciation, long> condition)
		{
			var entityCollection = this._DepreciationRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<DepreciationLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		public GenericCollectionViewModel<DepreciationLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
		{
			var lang = this._languageService.CurrentLanguage;
			ConditionFilter<Depreciation, long> condition = new ConditionFilter<Depreciation, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var entityCollection = this._DepreciationRepository.Get(condition).ToList();
			var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
			var result = new GenericCollectionViewModel<DepreciationLightViewModel>
			{
				Collection = dtoCollection,
				TotalCount = dtoCollection.Count,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}

		public IList<DepreciationViewModel> Add(IEnumerable<DepreciationViewModel> collection)
		{
			Language lang = this._languageService.CurrentLanguage;
			IList<Asset> FailedToUpdate = new List<Asset>();
			IList<Asset> assetsToUpdate = new List<Asset>();
			List<Depreciation> depreciations = new List<Depreciation>();
			IList<DepreciationViewModel> DepreciationViewModels = collection.ToList();
			DateTime now = DateTime.Now;
			//DateTime depreciationDate = DateTime.Now;

			foreach (var model in collection)
			{
				Asset asset = this._AssetsRepository.Get(model.AssetId);

                DateTime startDepreciationDate;
                if (asset.StartDepreciationDate.HasValue)
                {
                    startDepreciationDate = asset.StartDepreciationDate.Value;
                }
                else
                {
                    startDepreciationDate = asset.PurchaseDate.Value;
                }
                switch (asset.DepreciationRate.DepreciationRateCode)
				{
					case DepreciationRateCodeEnum.Day:
						{
							if (asset.LastDepreciationDate == null)
								model.NextDepreciationDate = startDepreciationDate;
							else
								model.NextDepreciationDate = asset.LastDepreciationDate.Value.AddDays(1);
						}
						break;
					case DepreciationRateCodeEnum.Month:
						{
							if (asset.LastDepreciationDate == null)
								model.NextDepreciationDate = startDepreciationDate.AddMonths(1);
							else
								model.NextDepreciationDate = asset.LastDepreciationDate.Value.AddMonths(1);
						}
						break;
					case DepreciationRateCodeEnum.Year:
						{
							if (asset.LastDepreciationDate == null)
								model.NextDepreciationDate = startDepreciationDate.AddYears(1);
							else
								model.NextDepreciationDate = asset.LastDepreciationDate.Value.AddYears(1);
						}
						break;
					default:
						break;
				}

				//switch (asset.DepreciationRate.DepreciationRateCode)
				//{
				//	case MersalAccountingService.Common.Enums.DepreciationRateCodeEnum.Day:
				//		depreciationDate = DateTime.Now.AddDays(1);
				//		break;
				//	case MersalAccountingService.Common.Enums.DepreciationRateCodeEnum.Month:
				//		depreciationDate = DateTime.Now.AddMonths(1);
				//		break;
				//	case MersalAccountingService.Common.Enums.DepreciationRateCodeEnum.Year:
				//		depreciationDate = DateTime.Now.AddYears(1);
				//		break;
				//	default:
				//		break;
				//}

				if (model.NextDepreciationDate > now)
				//if (asset.LastDepreciationDate <= depreciationDate)
				{
					FailedToUpdate.Add(asset);
					DepreciationViewModel depreciationViewModel = DepreciationViewModels.FirstOrDefault(x => x.AssetId == asset.Id);
					DepreciationViewModels.Remove(depreciationViewModel);
					//model.AccountChart = asset.AccountChart.ToModel();
					BrandViewModel brand = asset.Brand.ChildTranslatedBrands.FirstOrDefault(c => c.Language == lang).ToModel();
					DepreciationRateViewModel depreciation = asset.DepreciationRate.ToModel();
					if (lang == Language.Arabic)
					{
						model.BrandName = brand.NameAr;
						model.DepreciationRateName = depreciation.NameAr;
					}
					else if (lang == Language.English)
					{
						model.BrandName = brand.NameEn;
						model.DepreciationRateName = depreciation.NameEn;
					}

					model.CurrentValue = asset.CurrentValue;
					model.Successed = false;
				}
				else
				{
					asset.CurrentValue -= asset.DepreciationValue;
					if (asset.CurrentValue < 0) asset.CurrentValue = 0;

					asset.LastDepreciationDate = now;
					assetsToUpdate.Add(asset);
					depreciations.Add(new Depreciation { AssetId = asset.Id });
					//model.AccountChart = asset.AccountChart.ToModel();
					BrandViewModel brand = asset.Brand.ChildTranslatedBrands.FirstOrDefault(c => c.Language == lang).ToModel();
					DepreciationRateViewModel depreciation = asset.DepreciationRate.ToModel();
					if (lang == Language.Arabic)
					{
						model.BrandName = brand.NameAr;
						model.DepreciationRateName = depreciation.NameAr;
					}
					else if (lang == Language.English)
					{
						model.BrandName = brand.NameEn;
						model.DepreciationRateName = depreciation.NameEn;
					}
					model.CurrentValue = asset.CurrentValue;
					model.Successed = true;

					switch (asset.DepreciationRate.DepreciationRateCode)
					{
						case DepreciationRateCodeEnum.Day:
							{
								model.NextDepreciationDate = asset.LastDepreciationDate.Value.AddDays(1);
							}
							break;
						case DepreciationRateCodeEnum.Month:
							{
								model.NextDepreciationDate = asset.LastDepreciationDate.Value.AddMonths(1);
							}
							break;
						case DepreciationRateCodeEnum.Year:
							{
								model.NextDepreciationDate = asset.LastDepreciationDate.Value.AddYears(1);
							}
							break;
						default:
							break;
					}
				}

				//if (asset.CurrentValue <= 0)
				//{

				//}

				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = DepreciationViewModels.Select(model => model.ToEntity());
			entityCollection = this._DepreciationRepository.Add(depreciations).ToList();
			this._AssetsRepository.Update(assetsToUpdate);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			//var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return collection.ToList();
		}

		public DepreciationViewModel Add(DepreciationViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = model.ToEntity();
			entity = this._DepreciationRepository.Add(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		public IList<DepreciationViewModel> Update(IEnumerable<DepreciationViewModel> collection)
		{
			foreach (var model in collection)
			{
				this.ThrowExceptionIfExist(model);
			}

			var entityCollection = collection.Select(model => model.ToEntity());
			entityCollection = this._DepreciationRepository.Update(entityCollection).ToList();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
			return modelCollection;
		}

		public DepreciationViewModel Update(DepreciationViewModel model)
		{
			this.ThrowExceptionIfExist(model);

			var entity = this._DepreciationRepository.Get(model.Id);

			//entity.LocationId = model.LocationId;
			//entity.AccountChartId = model.AccountChartId;

			entity = this._DepreciationRepository.Update(entity);


			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion

			model = entity.ToModel();
			return model;
		}

		public void Delete(IEnumerable<DepreciationViewModel> collection)
		{
			var entityCollection = collection.Select(model => model.ToEntity());
			this._DepreciationRepository.Delete(entityCollection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		public void Delete(IEnumerable<long> collection)
		{
			this._DepreciationRepository.Delete(collection);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		public void Delete(DepreciationViewModel model)
		{
			var entity = model.ToEntity();
			this._DepreciationRepository.Delete(entity);

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		public void Delete(long id)
		{
			var result = this._DepreciationRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			#region Commit Changes
			this._unitOfWork.Commit();
			#endregion
		}

		#endregion
	}
}
