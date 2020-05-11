#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.AutoMapperConfig;
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
    public class ExcludesService : IExcludesService
    {
        #region Data Members
        private readonly IExcludesRepository _ExcludesRepository;
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
        public ExcludesService(
            IExcludesRepository ExcludesRepository,
            IAssetsRepository AssetsRepository,
            ILanguageService languageService,
            IUnitOfWork unitOfWork)
        {
            this._ExcludesRepository = ExcludesRepository;
            this._AssetsRepository = AssetsRepository;
            this._languageService = languageService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public void ThrowExceptionIfExist(ExcludeViewModel model)
        {
            //ConditionFilter<Exclude, long> condition = new ConditionFilter<Exclude, long>
            //{
            //	Query = (entity =>
            //		entity.Name == model.Name &&
            //		entity.Id != model.Id)
            //};
            //var existEntity = this._ExcludesRepository.Get(condition).FirstOrDefault();

            //if (existEntity != null)
            //	throw new ItemAlreadyExistException();
        }

        public GenericCollectionViewModel<ExcludeViewModel> Get(ConditionFilter<Exclude, long> condition)
        {
            var entityCollection = this._ExcludesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ExcludeViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<ExcludeViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Exclude, long> condition = new ConditionFilter<Exclude, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._ExcludesRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<ExcludeViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        public ExcludeViewModel Get(long id)
        {
            var entity = this._ExcludesRepository.Get(id);
            var model = entity.ToModel();

            return model;
        }

        public GenericCollectionViewModel<ListExcludeLightViewModel> GetByFilter(AssetFilterViewModel model)
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
                x.ParentKeyAsset.IsSaled.HasValue == false
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
            var dtoCollection = entityCollection.Select(entity => entity.ToExcludeListModel()).ToList();

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
            var result = new GenericCollectionViewModel<ListExcludeLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<ExcludeLightViewModel> GetLightModel(ConditionFilter<Exclude, long> condition)
        {
            var entityCollection = this._ExcludesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<ExcludeLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        public GenericCollectionViewModel<ExcludeLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<Exclude, long> condition = new ConditionFilter<Exclude, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var entityCollection = this._ExcludesRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<ExcludeLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        public IList<ExcludeViewModel> Add(IEnumerable<ExcludeViewModel> collection)
        {
            DateTime now = DateTime.Now;
            Language lang = this._languageService.CurrentLanguage;            

            foreach (var model in collection)
            {
                Asset asset = this._AssetsRepository.Get().FirstOrDefault(s => s.Id == model.AssetId);

                if (model.IsSpeculation.HasValue)
                {
                    asset.IsExcluded = model.IsSpeculation;
                    asset.ExcludedDate = now;
                }

                if (model.IsSaled.HasValue)
                {
                    asset.IsSaled = model.IsSaled;
                    asset.SaleAmount = model.Amount;
                    asset.AccountChartId = model.AccountChartId;
                    asset.SaleDate = now;
                }

                //if (model.Amount.HasValue)
                //    asset.SaleAmount = model.Amount;

                this._AssetsRepository.Update(asset);
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._ExcludesRepository.Add(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            return collection.ToList();
        }

        public ExcludeViewModel Add(ExcludeViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = model.ToEntity();
            entity = this._ExcludesRepository.Add(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public IList<ExcludeViewModel> Update(IEnumerable<ExcludeViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._ExcludesRepository.Update(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        public ExcludeViewModel Update(ExcludeViewModel model)
        {
            this.ThrowExceptionIfExist(model);

            var entity = this._ExcludesRepository.Get(model.Id);

            //entity.LocationId = model.LocationId;
            //entity.AccountChartId = model.AccountChartId;

            entity = this._ExcludesRepository.Update(entity);


            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }

        public void Delete(IEnumerable<ExcludeViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._ExcludesRepository.Delete(entityCollection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(IEnumerable<long> collection)
        {
            this._ExcludesRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(ExcludeViewModel model)
        {
            var entity = model.ToEntity();
            this._ExcludesRepository.Delete(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        public void Delete(long id)
        {
            var result = this._ExcludesRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        #endregion
    }

}
